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
        FilteredElementCollector windowCollector;
        UIDocument localDoc;

        List<FamilySymbol> wallToWindows = new List<FamilySymbol>();

        List<Family> doorFamilies = new List<Family>();
        Dictionary<Element, string> doorElementsDictionary = new Dictionary<Element, string>();

        List<Family> windowFamilies = new List<Family>();
        Dictionary<Element, string> windowElementsDictionary = new Dictionary<Element, string>();

        List<Family> deleteParametersDoors = new List<Family>();
        List<Family> deleteParametersWindows = new List<Family>();

        List<Element> doors = new List<Element>();

        public string UserSelection = "";
        public string UserDeleteParameter = "";

        public MatchFireDoorWallForm(UIDocument doc)
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;

            localDoc = doc;

            doorCollector = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Doors).WhereElementIsNotElementType();
            windowCollector = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Windows).WhereElementIsNotElementType();


            buttonCancel.Enabled = false;

            StatusLabel.Visible = false;

            comboBoxMapToParam.Items.Add("Map To New Parameter");
            comboBoxMapToParam.Items.Add("Map/Delete Existing Parameter");

            comboBoxMapToParam.SelectedIndex = 0;
            parameterNameInput.Text = "Fire_Rating";
         

        }


        #region Buttons

        private void WallToDoor_Click(object sender, EventArgs e)
        {

            DoorToWall.Enabled = false;
            WindowToWall.Enabled = false;
            DeleteFireRatingsDoors.Enabled = false;
            DeleteFireRatingsWindow.Enabled = false;
           
            buttonCancel.Enabled = true;

            StatusLabel.Visible = true;


            if (comboBoxMapToParam.SelectedIndex == 0)
            {
                UserSelection = parameterNameInput.Text;
            }

            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
                this.DoorToWall.Enabled = false;
                

            }


          
        }

        private void DeleteFireRatings_Click(object sender, EventArgs e)
        {
            DoorToWall.Enabled = false;
            WindowToWall.Enabled = false;
            DeleteFireRatingsDoors.Enabled = false;
            DeleteFireRatingsWindow.Enabled = false;

            if (!this.backgroundWorker3.IsBusy)
            {
                this.backgroundWorker3.RunWorkerAsync();
            }

            comboBoxMapToParam.SelectedIndex = 0;
        }

        private void DeleteFireRatingsWindow_Click(object sender, EventArgs e)
        {

            DoorToWall.Enabled = false;
            WindowToWall.Enabled = false;
            DeleteFireRatingsDoors.Enabled = false;
            DeleteFireRatingsWindow.Enabled = false;


            if (!this.backgroundWorker4.IsBusy)
            {
                this.backgroundWorker4.RunWorkerAsync();
            }



        }


        private void WindowToWall_Click(object sender, EventArgs e)
        {

            DoorToWall.Enabled = false;
            WindowToWall.Enabled = false;
            DeleteFireRatingsDoors.Enabled = false;
            DeleteFireRatingsWindow.Enabled = false;
            buttonCancel.Enabled = true;
            StatusLabel.Visible = true;

            if(comboBoxMapToParam.SelectedIndex == 0)
            {
                UserSelection = parameterNameInput.Text;
            }


            if (!this.backgroundWorker2.IsBusy)
            {
                this.backgroundWorker2.RunWorkerAsync();
                this.WindowToWall.Enabled = false;

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

            string stringParamWall = "empty";

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

             
                stringParamWall = wallType.get_Parameter(BuiltInParameter.FIRE_RATING).AsString(); //getting wall rating

                if(stringParamWall == null)
                {
                    stringParamWall = "No Value";
                }


                ParameterSet parameters = door.Parameters;  //Finds All walls which needs to be changed

                ElementId typeID = famIns.GetTypeId(); //get type id of the family instance

                FamilySymbol fam = localDoc.Document.GetElement(typeID) as FamilySymbol; // get the instance as a Family Symbol

                //wallToDoors.Add(fam);

                //  wallToDoors2.Add(fam.Family,stringParamWall);

                doorFamilies.Add(fam.Family);
                doorElementsDictionary.Add(Ele, stringParamWall);


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
             
                    RevitServices.Transactions.TransactionManager.Instance.ForceCloseTransaction();

                    var distinctItems = doorFamilies.GroupBy(x => x.Id).Select(y => y.First()); //Make List Have Only Unique Families

                    Document famDoc;

                    foreach (var item in distinctItems)
                    {

                        famDoc = localDoc.Document.EditFamily(item); //get the family property of the family
                        FamilyManager familyManager = famDoc.FamilyManager;

                        using (Transaction t = new Transaction(famDoc, "Set Parameter")) //Change Door values
                        {
                            t.Start();

                            try
                            {
                                if(comboBoxMapToParam.SelectedIndex != 1) //If mapping to existing paramter skip creating a new one
                                {
                                    FamilyParameter newParam = familyManager.AddParameter(UserSelection, BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.Text, true);

                                }
                             


                            }
                            catch
                            {
                                //silent catch to continue if Fire_Rating is already on a door from a previous activation
                            }


                            t.Commit();

                            LoadOpts famLoadOptions = new LoadOpts();
                            Autodesk.Revit.DB.Family newFam = famDoc.LoadFamily(localDoc.Document, famLoadOptions);

                        }

                    }


                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter")) //Change Door values
                    {

                        t.Start();

                        foreach (var item in doorElementsDictionary)
                        {

                            ParameterSet ps = item.Key.Parameters;
             
                            foreach (Parameter p in ps)
                            {
                                if (p.Definition.Name == UserSelection)
                                {
                                    p.Set(item.Value);
                                }

                            }


                        }


                        t.Commit();
                    }


                    MessageBox.Show("The Task Has Been Completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //ChangeWindow.Clear();
            //ChangeDoors.Clear();


            doorElementsDictionary.Clear();

            DoorToWall.Enabled = true;
            WindowToWall.Enabled = true;
            DeleteFireRatingsDoors.Enabled = true;
            DeleteFireRatingsWindow.Enabled = true;

            buttonCancel.Enabled = false;
            StatusLabel.Visible = false;


        }



        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = doorCollector.Count();

            string stringParamWindow = "empty";

            foreach (Element Ele in windowCollector)
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

                if (backgroundWorker2.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                Autodesk.Revit.DB.Element window = Ele as Autodesk.Revit.DB.Element;
                ElementId typeId = window.GetTypeId();
                Autodesk.Revit.DB.Element windowType = localDoc.Document.GetElement(typeId);   //Gets All the Doors

                FamilyInstance famIns = window as FamilyInstance;                 //Covnvert to family instance to get the host of the door
                Element eleHost = famIns.Host;                                  //doors Host
                Autodesk.Revit.DB.Element wallHost = eleHost as Element;        //convert host back to an element
                ElementId typeIdW = wallHost.GetTypeId();                       //get the type Id of the host as an element
                Autodesk.Revit.DB.Element wallType = localDoc.Document.GetElement(typeIdW);   //Use the type ID to find that specific element


                stringParamWindow = wallType.get_Parameter(BuiltInParameter.FIRE_RATING).AsString(); //getting wall rating


                if (stringParamWindow == null)
                {
                    stringParamWindow = "No Value";
                }


                ParameterSet parameters = window.Parameters;  //Finds All walls which needs to be changed

                ElementId typeID = famIns.GetTypeId(); //get type id of the family instance

                FamilySymbol fam = localDoc.Document.GetElement(typeID) as FamilySymbol; // get the instance as a Family Symbol



              //  wallToWindows.Add(fam);

                windowFamilies.Add(fam.Family);
                windowElementsDictionary.Add(Ele,stringParamWindow);




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
                    RevitServices.Transactions.TransactionManager.Instance.ForceCloseTransaction();

                    var distinctItems = windowFamilies.GroupBy(x => x.Id).Select(y => y.First()); //Make List Have Only Unique Families

                    Document famDoc;

                    foreach (var item in distinctItems)
                    {

                        famDoc = localDoc.Document.EditFamily(item); //get the family property of the family
                        FamilyManager familyManager = famDoc.FamilyManager;

                        using (Transaction t = new Transaction(famDoc, "Set Parameter")) //Change Door values
                        {
                            t.Start();

                            try
                            {

                                FamilyParameter newParam = familyManager.AddParameter(UserSelection, BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.Text, true);


                            }
                            catch
                            {
                                //silent catch to continue if Fire_Rating is already on a door from a previous activation
                            }


                            t.Commit();

                            LoadOpts famLoadOptions = new LoadOpts();
                            Autodesk.Revit.DB.Family newFam = famDoc.LoadFamily(localDoc.Document, famLoadOptions);

                        }

                    }


                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter")) //Change Door values
                    {

                        t.Start();

                        foreach (var item in windowElementsDictionary)
                        {

                            ParameterSet ps = item.Key.Parameters;
             
                            foreach (Parameter p in ps)
                            {
                                if (p.Definition.Name == UserSelection)
                                {
                                    p.Set(item.Value);
                                }

                            }


                        }


                        t.Commit();
                    }


                    MessageBox.Show("The Task Has Been Completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            windowElementsDictionary.Clear();

            DoorToWall.Enabled = true;
            WindowToWall.Enabled = true;
            DeleteFireRatingsDoors.Enabled = true;
            DeleteFireRatingsWindow.Enabled = true;


            buttonCancel.Enabled = false;
            StatusLabel.Visible = false;




        }
        



        #endregion

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = doorCollector.Count();


            foreach (Element Ele in doorCollector)
            {

                i += 100 / max;

                if (i <= 100)
                {
                    backgroundWorker3.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker3.ReportProgress((int)i);
                }

                if (backgroundWorker3.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                //

                Autodesk.Revit.DB.Element door = Ele as Autodesk.Revit.DB.Element;
                ElementId typeId = door.GetTypeId();
                Autodesk.Revit.DB.Element doorType = localDoc.Document.GetElement(typeId);   //Gets All the Doors

                FamilyInstance famIns = door as FamilyInstance;                 //Covnvert to family instance to get the host of the door
                Element eleHost = famIns.Host;                                  //doors Host
                Autodesk.Revit.DB.Element wallHost = eleHost as Element;        //convert host back to an element
                ElementId typeIdW = wallHost.GetTypeId();                       //get the type Id of the host as an element
                Autodesk.Revit.DB.Element wallType = localDoc.Document.GetElement(typeIdW);   //Use the type ID to find that specific element

                ParameterSet parameters = doorType.Parameters;  //Finds All walls which needs to be changed

                ElementId typeID = famIns.GetTypeId(); //get type id of the family instance

                FamilySymbol fam = localDoc.Document.GetElement(typeID) as FamilySymbol; // get the instance as a Family Symbol


                deleteParametersDoors.Add(fam.Family);
                //wallToDoors.Add(fam);


            }



        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    RevitServices.Transactions.TransactionManager.Instance.ForceCloseTransaction();

               

                    var distinctItems = deleteParametersDoors.GroupBy(x => x.Id).Select(y => y.First()); //Sorts the list into only unique items

                    foreach (var item in distinctItems)
                    {

                        Document famDoc = localDoc.Document.EditFamily(item); //get the family property of the family
                        FamilyManager familyManager = famDoc.FamilyManager;

                        using (Transaction t = new Transaction(famDoc, "Set Parameter")) //Change Door values
                        {
                            t.Start();

                            try
                            {
                  
                                FamilyParameter param = familyManager.get_Parameter(UserDeleteParameter);
          
                                familyManager.RemoveParameter(param);


                            }
                            catch
                            {
                                //silent catch to continue if Fire_Rating is already on a door from a previous activation
                            }

                            t.Commit();

                            LoadOpts famLoadOptions = new LoadOpts();
                            Autodesk.Revit.DB.Family newFam = famDoc.LoadFamily(localDoc.Document, famLoadOptions);

                        }

                    }



                    MessageBox.Show("The Task Has Been Completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            DoorToWall.Enabled = true;
            WindowToWall.Enabled = true;
            DeleteFireRatingsDoors.Enabled = true;
            DeleteFireRatingsWindow.Enabled = true;

            buttonCancel.Enabled = false;
            StatusLabel.Visible = false;

            deleteParametersDoors.Clear();
 

        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = windowCollector.Count();


            foreach (Element Ele in windowCollector)
            {

                i += 100 / max;

                if (i <= 100)
                {
                    backgroundWorker4.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker4.ReportProgress((int)i);
                }

                if (backgroundWorker4.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                Autodesk.Revit.DB.Element window = Ele as Autodesk.Revit.DB.Element;
                ElementId windowID = window.GetTypeId();
                Autodesk.Revit.DB.Element windowType = localDoc.Document.GetElement(windowID);                  

                FamilyInstance famInsWin = window as FamilyInstance;                                          
                Element eleHostWin = famInsWin.Host;                                                        
                Autodesk.Revit.DB.Element wallHostWin = eleHostWin as Element;                             
                ElementId typeIdForWindow = wallHostWin.GetTypeId();                                        
                Autodesk.Revit.DB.Element wallTypeWindow = localDoc.Document.GetElement(typeIdForWindow);  

                ParameterSet parametersWindow = windowType.Parameters; 

                ElementId typeIDW = famInsWin.GetTypeId(); 

                FamilySymbol famW = localDoc.Document.GetElement(typeIDW) as FamilySymbol; // get the instance as a Family Symbol


                deleteParametersWindows.Add(famW.Family);






            }

        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    RevitServices.Transactions.TransactionManager.Instance.ForceCloseTransaction();


                    var distinctItems = deleteParametersWindows.GroupBy(x => x.Id).Select(y => y.First()); //Sorts the list into only unique items

                    foreach (var item in distinctItems)
                    {

                        Document famDoc = localDoc.Document.EditFamily(item); //get the family property of the family
                        FamilyManager familyManager = famDoc.FamilyManager;

                        using (Transaction t = new Transaction(famDoc, "Set Parameter")) //Change Door values
                        {
                            t.Start();

                            try
                            {
                 

                                FamilyParameter param = familyManager.get_Parameter(UserDeleteParameter);

                                familyManager.RemoveParameter(param);


                            }
                            catch
                            {
                                //silent catch to continue if Fire_Rating is already on a door from a previous activation
                            }

                            t.Commit();

                            LoadOpts famLoadOptions = new LoadOpts();
                            Autodesk.Revit.DB.Family newFam = famDoc.LoadFamily(localDoc.Document, famLoadOptions);

                        }

                    }



                    MessageBox.Show("The Task Has Been Completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar1.Value = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DoorToWall.Enabled = true;
            WindowToWall.Enabled = true;
            DeleteFireRatingsDoors.Enabled = true;
            DeleteFireRatingsWindow.Enabled = true;

            deleteParametersWindows.Clear();

            buttonCancel.Enabled = false;
            StatusLabel.Visible = false;


        }


        class LoadOpts : IFamilyLoadOptions
        {
            public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
            {
                overwriteParameterValues = true;
                return true;
            }

            public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
            {
                throw new NotImplementedException();
            }
        }

        private void comboBoxMapToParam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxMapToParam.SelectedIndex == 0) //Map To New
            {
                parameterNameInput.Visible = true;
                comboBoxParameterList.Visible = false;
                DeleteFireRatingsDoors.Enabled = false;
                DeleteFireRatingsWindow.Enabled = false;


            }
            else //Map To Existing
            {

                DeleteFireRatingsDoors.Enabled = true;
                DeleteFireRatingsWindow.Enabled = true;

                parameterNameInput.Visible = false;
                comboBoxParameterList.Visible = true;
                comboBoxParameterList.Items.Clear();


                UpdateParameterList();

            }
            



        }

        private void comboBoxParameterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSelection = comboBoxParameterList.Text;
            UserDeleteParameter = comboBoxParameterList.Text;
        }

        private void parameterNameInput_TextChanged(object sender, EventArgs e)
        {
            UserSelection = parameterNameInput.Text;
        }


        private void UpdateParameterList()
        {
            List<Parameter> P = new List<Parameter>();


            foreach (var item in doorCollector)
            {

                foreach (Parameter a in item.Parameters)
                {
                    P.Add(a);

                }

            }

            var distinct = P.GroupBy(x => x.Definition.Name).Select(y => y.FirstOrDefault()).OrderBy(n => n.Definition.Name);


            foreach (Parameter item in distinct)
            {
                comboBoxParameterList.Items.Add(item.Definition.Name);
            }

            comboBoxParameterList.SelectedIndex = 0;

        }

    }
    }
