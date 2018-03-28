using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DesignTechRibbon.Revit.EssentialTools.MatchFireDoorWall
{
    public partial class MatchFireDoorWallForm : System.Windows.Forms.Form
    {


        FilteredElementCollector doorCollector;
        FilteredElementCollector WallCollector;

        UIDocument localDoc;

        List<Tuple<Parameter, string>> ChangeWall= new List<Tuple<Parameter, string>>();
        List<Tuple<Parameter, string>> ChangeDoor = new List<Tuple<Parameter, string>>();

        public string stringParamWall = "empty";
        public string stringParamDoor = "empty";


        List<Element> doors = new List<Element>();

        public MatchFireDoorWallForm(UIDocument doc)
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;

            localDoc = doc;

            doorCollector = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Doors).WhereElementIsNotElementType();
            WallCollector = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType();


            buttonCancel.Enabled = false;

            StatusLabel.Visible = false;

        }


        #region Buttons

        private void DoorToWall_Click(object sender, EventArgs e)
        {

            DoorToWall.Enabled = false;
            WallToDoor.Enabled = false;
            buttonCancel.Enabled = true;

            StatusLabel.Visible = true;

            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
                this.DoorToWall.Enabled = false;
                

            }
        }

        private void WallToDoor_Click(object sender, EventArgs e)
        {

            DoorToWall.Enabled = false;
            WallToDoor.Enabled = false;
            buttonCancel.Enabled = true;
            StatusLabel.Visible = true;

            if (!this.backgroundWorker2.IsBusy)
            {
                this.backgroundWorker2.RunWorkerAsync();
                this.WallToDoor.Enabled = false;

            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            this.Close();
        }



        #endregion


        #region Background Workers

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = doorCollector.Count();


            foreach (Element Ele in doorCollector)
            {

                i += 100 / max;

                if (i <= 100)
                {
                    backgroundWorker1.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker1.ReportProgress((int)i);
                }

                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                Autodesk.Revit.DB.Element door = Ele as Autodesk.Revit.DB.Element;
                ElementId typeId = door.GetTypeId();
                Autodesk.Revit.DB.Element doorType = localDoc.Document.GetElement(typeId);   //Gets All the Doors

                FamilyInstance famIns = door as FamilyInstance;                 //Covnvert to family instance to get the host of the door
                Element eleHost = famIns.Host;                                  //doors Host
                Autodesk.Revit.DB.Element wallHost = eleHost as Element;        //convert host back to an element
                ElementId typeIdW = wallHost.GetTypeId();                       //get the type Id of the host as an element
                Autodesk.Revit.DB.Element wallType = localDoc.Document.GetElement(typeIdW);   //Use the type ID to find that specific element


                stringParamDoor = doorType.get_Parameter(BuiltInParameter.FIRE_RATING).AsString(); //getting wall rating


                ParameterSet parameters = wallType.Parameters;  //Finds All walls which needs to be changed
                foreach (Parameter param in parameters)
                {

                    if (param.Definition.Name.Equals("Fire Rating") && param.AsString() != "")
                    {
                        ChangeDoor.Add(new Tuple<Parameter, string>(param, stringParamDoor));

                    }
                }


            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (e.Cancelled)
                {
                    MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {


                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter")) //Change Door values
                    {
                        t.Start();

                        foreach (Tuple<Parameter,string> param in ChangeDoor)
                        {
                            param.Item1.Set(param.Item2);
                        }


                        t.Commit();
                    }

            
                    MessageBox.Show("The Task Has Been Completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            ChangeDoor.Clear();
            ChangeWall.Clear();

            WallToDoor.Enabled = true;
            DoorToWall.Enabled = true;
            buttonCancel.Enabled = false;
            StatusLabel.Visible = false;


        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            double i = 0;
            double max = doorCollector.Count();


            foreach (Element Ele in doorCollector)
            {

                i += 100 / max;

                if (i <= 100)
                {
                    backgroundWorker2.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker2.ReportProgress((int)i);
                }

                Autodesk.Revit.DB.Element wall = Ele as Autodesk.Revit.DB.Element;
                ElementId typeId = wall.GetTypeId();
                Autodesk.Revit.DB.Element wallType = localDoc.Document.GetElement(typeId);   //Gets All the Walls

                FamilyInstance famIns = wall as FamilyInstance;                 //Covnvert to family instance to get the host of the wall
                Element eleHost = famIns.Host;                                  //doors Host
                Autodesk.Revit.DB.Element doorHost = eleHost as Element;        //convert host back to an element
                ElementId typeIdD = doorHost.GetTypeId();                       //get the type Id of the host as an element
                Autodesk.Revit.DB.Element doorType = localDoc.Document.GetElement(typeIdD);   //Use the type ID to find that specific element


                stringParamWall = doorType.get_Parameter(BuiltInParameter.FIRE_RATING).AsString(); //getting door rating


                ParameterSet parameters = wallType.Parameters;  //Finds All the Doors Paramaters which need to change
                foreach (Parameter param in parameters)
                {

                    if (param.Definition.Name.Equals("Fire Rating") && param.AsString() != "")
                    {
                        ChangeWall.Add(new Tuple<Parameter, string>(param, stringParamWall));

                    }
                }

 


            }




        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (e.Cancelled)
                {

                    MessageBox.Show("The task has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {


                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter")) //Change Door values
                    {
                        t.Start();
         

                        foreach (Tuple<Parameter, string> param in ChangeWall)
                        {
                            param.Item1.Set(param.Item2);
                        }


                        t.Commit();
                    }


                    MessageBox.Show("The task has been completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            ChangeDoor.Clear();
            ChangeWall.Clear();

            WallToDoor.Enabled = true;
            DoorToWall.Enabled = true;
            buttonCancel.Enabled = false;
            StatusLabel.Visible = false;


        }


        #endregion

   
    }



}
