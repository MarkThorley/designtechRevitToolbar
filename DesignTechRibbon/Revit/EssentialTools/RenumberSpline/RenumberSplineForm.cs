using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using DesignTechRibbon.Revit.MessageBoxForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalLength;

namespace DesignTechRibbon.Revit.EssentialTools.RenumberSpline
{
    public partial class RenumberSplineForm : System.Windows.Forms.Form
    {
        UIDocument localDoc;
        FilteredElementCollector collSplines;
        FilteredElementCollector collDoors;
        FilteredElementCollector collWindows;
        FilteredElementCollector collWalls;
        FilteredElementCollector collRooms;
        FilteredElementCollector collLevels;
        ElementId currentViewID;

        Element localSpline;

        IList<XYZ> tessellation;
        Dictionary<int, XYZ> splinePoints;

        Dictionary<Element, XYZ> doorPoints = new Dictionary<Element, XYZ>();
        Dictionary<Element, XYZ> windowPoints = new Dictionary<Element, XYZ>();
        Dictionary<Element, XYZ> roomPoints = new Dictionary<Element, XYZ>();

        List<Element> allViewportsOnSheet = new List<Element>();

        List<Tuple<double, Element, XYZ, XYZ>> orderedPoints = new List<Tuple<double, Element, XYZ, XYZ>>();
        List<ElementId> LevelViewID = new List<ElementId>();

        string byDoors = "By Doors";
        string byWindows = "By Windows";
        string byRooms = "By Rooms";
        string currentLevel = "Current Level";
        string allLevels = "All Levels";


        public RenumberSplineForm(UIDocument doc)
        {

            InitializeComponent();
            localDoc = doc;

            FormCollection fc = Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc) //tries looking for the Open Form to get the spline from
            {
                if (frm.Name == "SelectionForm")
                {
                    SelectionForm sf = frm as SelectionForm;

                    localSpline = sf.MyProperty;
                    frm.Close();
                    break;

                }
            }



            // localSpline = a.MyProperty;
            currentViewID = localDoc.ActiveView.GenLevel.Id;


            collSplines = new FilteredElementCollector(localDoc.Document, localDoc.ActiveView.Id).WherePasses(new ElementClassFilter(typeof(CurveElement)));

            collDoors = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Doors).WhereElementIsNotElementType();

            collWindows = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Windows).WhereElementIsNotElementType();

            collRooms = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType();

            collLevels = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType();

            collWalls = new FilteredElementCollector(localDoc.Document).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType();


            foreach (var item in collLevels)    //Document to level collection to levels ID
            {
                LevelViewID.Add(localDoc.Document.GetElement(item.Id).Id);
            }

            SplineCancelButton.Enabled = false;
            StatusLabel.Visible = false;

            SelectElementBox.Items.Add(byDoors);
            SelectElementBox.Items.Add(byWindows);
            SelectElementBox.Items.Add(byRooms);
            SelectElementBox.SelectedIndex = 0;

            SelectLevelBox.Items.Add(currentLevel);
            SelectLevelBox.Items.Add(allLevels);
            SelectLevelBox.SelectedIndex = 0;


            comboBoxZeroPad.Items.Add("0");
            comboBoxZeroPad.Items.Add("1");
            comboBoxZeroPad.Items.Add("2");
            comboBoxZeroPad.Items.Add("3");
            comboBoxZeroPad.Items.Add("4");
            comboBoxZeroPad.Items.Add("5");
            comboBoxZeroPad.Items.Add("6");
            comboBoxZeroPad.Items.Add("7");
            comboBoxZeroPad.Items.Add("8");
            comboBoxZeroPad.Items.Add("9");
            comboBoxZeroPad.SelectedIndex = 0;


        }

        #region Buttons

        private void StartButton_Click(object sender, EventArgs e)
        {

            StatusLabel.Text = "In Progress";
            CloseButton.Text = "Close";

            if (SelectElementBox.SelectedItem.ToString() == byDoors && SelectLevelBox.SelectedItem.ToString() == currentLevel)
            {
                if (!this.backgroundWorker1.IsBusy)
                {
                    StatusLabel.Visible = true;
                    this.backgroundWorker1.RunWorkerAsync();
                    ButtonsDisabled();
                }

            }
            if (SelectElementBox.SelectedItem.ToString() == byDoors && SelectLevelBox.SelectedItem.ToString() == allLevels)
            {
                if (!this.backgroundWorker2.IsBusy)
                {
                    StatusLabel.Visible = true;
                    this.backgroundWorker2.RunWorkerAsync();
                    ButtonsDisabled();
                }

            }



            if (SelectElementBox.SelectedItem.ToString() == byWindows && SelectLevelBox.SelectedItem.ToString() == currentLevel)
            {
                if (!this.backgroundWorker3.IsBusy)
                {
                    StatusLabel.Visible = true;
                    this.backgroundWorker3.RunWorkerAsync();
                    ButtonsDisabled();
                }

            }

            if (SelectElementBox.SelectedItem.ToString() == byWindows && SelectLevelBox.SelectedItem.ToString() == allLevels)
            {
                if (!this.backgroundWorker4.IsBusy)
                {
                    StatusLabel.Visible = true;
                    this.backgroundWorker4.RunWorkerAsync();
                    ButtonsDisabled();
                }

            }


            if (SelectElementBox.SelectedItem.ToString() == byRooms && SelectLevelBox.SelectedItem.ToString() == currentLevel)
            {
                if (!this.backgroundWorker5.IsBusy)
                {
                    StatusLabel.Visible = true;
                    this.backgroundWorker5.RunWorkerAsync();
                    ButtonsDisabled();
                }


            }

            if (SelectElementBox.SelectedItem.ToString() == byRooms && SelectLevelBox.SelectedItem.ToString() == allLevels)
            {
                if (!this.backgroundWorker6.IsBusy)
                {
                    StatusLabel.Visible = true;
                    this.backgroundWorker6.RunWorkerAsync();
                    ButtonsDisabled();
                }

            }


        }


        private void SplineCancelButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Visible = false;
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            backgroundWorker3.CancelAsync();
            backgroundWorker4.CancelAsync();
            backgroundWorker5.CancelAsync();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            backgroundWorker3.CancelAsync();
            backgroundWorker4.CancelAsync();
            backgroundWorker5.CancelAsync();
            this.Close();
        }

        void ButtonsEnabled()
        {
            SplineCancelButton.Enabled = false;

        }

        void ButtonsDisabled()
        {
            SplineCancelButton.Enabled = true;

        }

        #endregion


        #region Background Workers


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            double i = 0;
            double max = doorPoints.Count;

            foreach (Element E in collDoors)
            {


                if (E.LevelId == currentViewID)
                {
                    LocationPoint getDoorPoint = E.Location as LocationPoint;


                    if (getDoorPoint == null)
                    {

                        if (checkBoxCurtainWalls.Checked == true) //Add curtain walls to the list
                        {
                            Autodesk.Revit.DB.Element door = E as Autodesk.Revit.DB.Element;
                            ElementId typeId = door.GetTypeId();
                            Autodesk.Revit.DB.Element doorType = localDoc.Document.GetElement(typeId);   //Gets All the Doors

                            FamilyInstance famIns = door as FamilyInstance;                 //Covnvert to family instance to get the host of the door
                            Wall eleHost = famIns.Host as Wall;                             //doors Host

                            LocationCurve LC = eleHost.Location as LocationCurve;
                            Curve C = LC.Curve;

                            Line L = C as Line;

                            doorPoints.Add(E, L.Origin as Autodesk.Revit.DB.XYZ);

                        }
                        else
                        {
                            //Dont add any doors with null points (The doors on curtain walls)

                        }



                    }
                    else
                    {
                        doorPoints.Add(E, getDoorPoint.Point as Autodesk.Revit.DB.XYZ);
                    }


                }

            }

            Curve curve = (localSpline as CurveElement).GeometryCurve;

            tessellation = curve.Tessellate();

            splinePoints = new Dictionary<int, XYZ>(1);

            double stepsize = 5.0;
            double dist = 0.0;

            XYZ p = curve.GetEndPoint(0);
            int count = 0;

            foreach (XYZ q in tessellation)
            {
                if (0 == splinePoints.Count)
                {
                    splinePoints.Add(count, p);
                    dist = 0.0;
                    count++;
                }
                else
                {
                    dist += p.DistanceTo(q);

                    if (dist >= stepsize)
                    {
                        splinePoints.Add(count++, q);
                        dist = 0;
                    }
                    p = q;
                }


            }

            foreach (KeyValuePair<Element, XYZ> door in doorPoints)
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



                double shortestLength = 0;
                XYZ closestPoint = new XYZ(0, 0, 0);



                for (int x = 0; x < splinePoints.Count; x++) //finds the shortest lenght door to point
                {

                    if (x == 0) // apply to first door in loop
                    {
                        shortestLength = door.Value.DistanceTo(splinePoints[0]);
                        closestPoint = splinePoints[0];


                    }
                    else
                    {

                        if (door.Value.DistanceTo(splinePoints[x]) < shortestLength)// if there is a shorter door
                        {
                            closestPoint = splinePoints[x];
                            shortestLength = door.Value.DistanceTo(splinePoints[x]);// add the door 

                        }


                    }
                }


                foreach (var item in splinePoints)
                {


                    if (closestPoint == item.Value)
                    {
                        //Spline point num/Door Element/Door Point/Closest point on spline
                        orderedPoints.Add(new Tuple<double, Element, XYZ, XYZ>(item.Key, door.Key, door.Value, closestPoint));
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

                DTMessage mb = new DTMessage();

                if (e.Cancelled)
                {
                    //MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    // MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter"))
                    {

                        t.Start();

                        //var sort = from element in orderedPoints //sort by distance to the door
                        //           orderby element.Item1 ascending
                        //           select element;

                        orderedPoints = orderedPoints.OrderBy(a => a.Item2.LevelId.IntegerValue).ThenBy(b => b.Item1).ToList();


                        string paddingNumber = orderedPoints.ToList().Count.ToString();

                        //int zeroes = paddingNumber.Count(char.IsNumber);

                        int zeroes = Convert.ToInt32(comboBoxZeroPad.SelectedItem.ToString());


                        for (int x = 0; x < orderedPoints.ToList().Count; x++)
                        {
                            orderedPoints.ToList()[x].Item2.get_Parameter(BuiltInParameter.ALL_MODEL_MARK).Set(PrefixString.Text + x.ToString().PadLeft(zeroes, '0') + SuffixString.Text);

                        }




                        t.Commit();

                    }


                    StatusLabel.Text = "Completed";
                    CloseButton.Text = "Finish";
                    progressBar1.Value = 0;
                    doorPoints.Clear();
                    orderedPoints.Clear();
                    ButtonsEnabled();
      

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }

        }





        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = doorPoints.Count;

            foreach (Element E in collDoors)
            {

                LocationPoint getDoorPoint = E.Location as LocationPoint;

                if (getDoorPoint == null)
                {

                    if (checkBoxCurtainWalls.Checked == true) //Add curtain walls to the list
                    {
                        Autodesk.Revit.DB.Element door = E as Autodesk.Revit.DB.Element;
                        ElementId typeId = door.GetTypeId();
                        Autodesk.Revit.DB.Element doorType = localDoc.Document.GetElement(typeId);   //Gets All the Doors

                        FamilyInstance famIns = door as FamilyInstance;                 //Covnvert to family instance to get the host of the door
                        Wall eleHost = famIns.Host as Wall;                             //doors Host

                        LocationCurve LC = eleHost.Location as LocationCurve;
                        Curve C = LC.Curve;

                        Line L = C as Line;

                        doorPoints.Add(E, L.Origin as Autodesk.Revit.DB.XYZ);

                    }
                    else
                    {
                        //Dont add any doors with null points (The doors on curtain walls)

                    }



                }
                else
                {
                    doorPoints.Add(E, getDoorPoint.Point as Autodesk.Revit.DB.XYZ);
                }



            }

            Curve curve = (localSpline as CurveElement).GeometryCurve;

            tessellation = curve.Tessellate();

            splinePoints = new Dictionary<int, XYZ>(1);

            double stepsize = 5.0;
            double dist = 0.0;

            XYZ p = curve.GetEndPoint(0);
            int count = 0;

            foreach (XYZ q in tessellation)
            {
                if (0 == splinePoints.Count)
                {
                    splinePoints.Add(count, p);
                    dist = 0.0;
                    count++;
                }
                else
                {
                    dist += p.DistanceTo(q);

                    if (dist >= stepsize)
                    {
                        splinePoints.Add(count++, q);
                        dist = 0;
                    }
                    p = q;
                }


            }

            foreach (KeyValuePair<Element, XYZ> door in doorPoints)
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



                double shortestLength = 0;
                XYZ closestPoint = new XYZ(0, 0, 0);



                for (int x = 0; x < splinePoints.Count; x++) //finds the shortest lenght door to point
                {

                    if (x == 0) // apply to first door in loop
                    {
                        shortestLength = door.Value.DistanceTo(splinePoints[0]);
                        closestPoint = splinePoints[0];

                    }
                    else
                    {
                        // error
                        if (door.Value.DistanceTo(splinePoints[x]) < shortestLength)// if there is a shorter door
                        {
                            closestPoint = splinePoints[x];
                            shortestLength = door.Value.DistanceTo(splinePoints[x]);// add the door 

                        }


                    }
                }


                foreach (var item in splinePoints)
                {
                    if (closestPoint == item.Value)
                    {
                        //Spline point num/Door Element/Door Point/Closest point on spline
                        orderedPoints.Add(new Tuple<double, Element, XYZ, XYZ>(item.Key, door.Key, door.Value, closestPoint));
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
                DTMessage mb = new DTMessage();

                if (e.Cancelled)
                {
                    // MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    //MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter"))
                    {

                        t.Start();

                        orderedPoints = orderedPoints.OrderBy(a => a.Item2.LevelId.IntegerValue).ThenBy(b => b.Item1).ToList();

                        string paddingNumber = orderedPoints.ToList().Count.ToString();

                        //int zeroes = paddingNumber.Count(char.IsNumber);

                        int zeroes = Convert.ToInt32(comboBoxZeroPad.SelectedItem.ToString());

                        for (int x = 0; x < orderedPoints.ToList().Count; x++)
                        {
                            orderedPoints.ToList()[x].Item2.get_Parameter(BuiltInParameter.ALL_MODEL_MARK).Set(PrefixString.Text + x.ToString().PadLeft(zeroes, '0') + SuffixString.Text);
                        }

                        t.Commit();

                    }


                    StatusLabel.Text = "Completed";
                    CloseButton.Text = "Finish";
                    progressBar1.Value = 0;
                    doorPoints.Clear();
                    orderedPoints.Clear();
                    ButtonsEnabled();
        

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }


        }



        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = windowPoints.Count;

            foreach (Element E in collWindows)
            {

                if (E.LevelId == currentViewID)
                {
                    LocationPoint getWindowPoint = E.Location as LocationPoint;

                    windowPoints.Add(E, getWindowPoint.Point as Autodesk.Revit.DB.XYZ);
                }

            }

            Curve curve = (localSpline as CurveElement).GeometryCurve;

            tessellation = curve.Tessellate();

            splinePoints = new Dictionary<int, XYZ>(1);

            double stepsize = 5.0;
            double dist = 0.0;

            XYZ p = curve.GetEndPoint(0);
            int count = 0;

            foreach (XYZ q in tessellation)
            {
                if (0 == splinePoints.Count)
                {
                    splinePoints.Add(count, p);
                    dist = 0.0;
                    count++;
                }
                else
                {
                    dist += p.DistanceTo(q);

                    if (dist >= stepsize)
                    {
                        splinePoints.Add(count++, q);
                        dist = 0;
                    }
                    p = q;
                }


            }

            foreach (KeyValuePair<Element, XYZ> window in windowPoints)
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



                double shortestLength = 0;
                XYZ closestPoint = new XYZ(0, 0, 0);


                for (int x = 0; x < splinePoints.Count; x++) //finds the shortest lenght door to point
                {

                    if (x == 0) // apply to first door in loop
                    {
                        shortestLength = window.Value.DistanceTo(splinePoints[0]);
                        closestPoint = splinePoints[0];

                    }
                    else
                    {

                        if (window.Value.DistanceTo(splinePoints[x]) < shortestLength)// if there is a shorter door
                        {
                            closestPoint = splinePoints[x];
                            shortestLength = window.Value.DistanceTo(splinePoints[x]);// add the door 

                        }


                    }
                }


                foreach (var item in splinePoints)
                {
                    if (closestPoint == item.Value)
                    {
                        //Spline point num/Door Element/Door Point/Closest point on spline
                        orderedPoints.Add(new Tuple<double, Element, XYZ, XYZ>(item.Key, window.Key, window.Value, closestPoint));
                    }

                }


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
                DTMessage mb = new DTMessage();


                if (e.Cancelled)
                {
                    //MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    // MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter"))
                    {

                        t.Start();

                        //var sort = from element in orderedPoints //sort by distance to the door
                        //           orderby element.Item1 ascending
                        //           select element;

                        orderedPoints = orderedPoints.OrderBy(a => a.Item2.LevelId.IntegerValue).ThenBy(b => b.Item1).ToList();

                        string paddingNumber = orderedPoints.ToList().Count.ToString();

                        //int zeroes = paddingNumber.Count(char.IsNumber);

                        int zeroes = Convert.ToInt32(comboBoxZeroPad.SelectedItem.ToString());


                        for (int x = 0; x < orderedPoints.ToList().Count; x++)
                        {
                            orderedPoints.ToList()[x].Item2.get_Parameter(BuiltInParameter.ALL_MODEL_MARK).Set(PrefixString.Text + x + SuffixString.Text);
                        }

                        t.Commit();

                    }



                    StatusLabel.Text = "Completed";
                    CloseButton.Text = "Finish";
                    progressBar1.Value = 0;
                    windowPoints.Clear();
                    orderedPoints.Clear();
                    ButtonsEnabled();
    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }


        }



        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = windowPoints.Count;

            foreach (Element E in collWindows)
            {

                LocationPoint getWindowPoint = E.Location as LocationPoint;

                windowPoints.Add(E, getWindowPoint.Point as Autodesk.Revit.DB.XYZ);


            }

            Curve curve = (localSpline as CurveElement).GeometryCurve;

            tessellation = curve.Tessellate();

            splinePoints = new Dictionary<int, XYZ>(1);

            double stepsize = 5.0;
            double dist = 0.0;

            XYZ p = curve.GetEndPoint(0);
            int count = 0;

            foreach (XYZ q in tessellation)
            {
                if (0 == splinePoints.Count)
                {
                    splinePoints.Add(count, p);
                    dist = 0.0;
                    count++;
                }
                else
                {
                    dist += p.DistanceTo(q);

                    if (dist >= stepsize)
                    {
                        splinePoints.Add(count++, q);
                        dist = 0;
                    }
                    p = q;
                }


            }

            foreach (KeyValuePair<Element, XYZ> window in windowPoints)
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



                double shortestLength = 0;
                XYZ closestPoint = new XYZ(0, 0, 0);


                for (int x = 0; x < splinePoints.Count; x++) //finds the shortest lenght door to point
                {

                    if (x == 0) // apply to first door in loop
                    {
                        shortestLength = window.Value.DistanceTo(splinePoints[0]);
                        closestPoint = splinePoints[0];

                    }
                    else
                    {

                        if (window.Value.DistanceTo(splinePoints[x]) < shortestLength)// if there is a shorter door
                        {
                            closestPoint = splinePoints[x];
                            shortestLength = window.Value.DistanceTo(splinePoints[x]);// add the door 

                        }


                    }
                }


                foreach (var item in splinePoints)
                {
                    if (closestPoint == item.Value)
                    {
                        //Spline point num/Door Element/Door Point/Closest point on spline
                        orderedPoints.Add(new Tuple<double, Element, XYZ, XYZ>(item.Key, window.Key, window.Value, closestPoint));
                    }

                }


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
                DTMessage mb = new DTMessage();

                if (e.Cancelled)
                {
                    //MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    //MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";


                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter"))
                    {

                        t.Start();

                        orderedPoints = orderedPoints.OrderBy(a => a.Item2.LevelId.IntegerValue).ThenBy(b => b.Item1).ToList();


                        string paddingNumber = orderedPoints.ToList().Count.ToString();

                        //int zeroes = paddingNumber.Count(char.IsNumber);
                        int zeroes = Convert.ToInt32(comboBoxZeroPad.SelectedItem.ToString());

                        for (int x = 0; x < orderedPoints.ToList().Count; x++)
                        {
                            orderedPoints.ToList()[x].Item2.get_Parameter(BuiltInParameter.ALL_MODEL_MARK).Set(PrefixString.Text + x.ToString().PadLeft(zeroes, '0') + SuffixString.Text);

                        }

                        t.Commit();

                    }


                    StatusLabel.Text = "Completed";
                    CloseButton.Text = "Finish";
                    progressBar1.Value = 0;
                    windowPoints.Clear();
                    orderedPoints.Clear();
                    ButtonsEnabled();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }


        }


        //ROOMS
        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {

            double i = 0;
            double max = roomPoints.Count;

            foreach (Element E in collRooms)
            {

                if (E.LevelId == currentViewID)
                {
                    LocationPoint getRoomPoint = E.Location as LocationPoint;

                    roomPoints.Add(E, getRoomPoint.Point as Autodesk.Revit.DB.XYZ);
                }

            }

            Curve curve = (localSpline as CurveElement).GeometryCurve;

            tessellation = curve.Tessellate();

            splinePoints = new Dictionary<int, XYZ>(1);

            double stepsize = 5.0;
            double dist = 0.0;

            XYZ p = curve.GetEndPoint(0);
            int count = 0;

            foreach (XYZ q in tessellation)
            {
                if (0 == splinePoints.Count)
                {
                    splinePoints.Add(count, p);
                    dist = 0.0;
                    count++;
                }
                else
                {
                    dist += p.DistanceTo(q);

                    if (dist >= stepsize)
                    {
                        splinePoints.Add(count++, q);
                        dist = 0;
                    }
                    p = q;
                }


            }

            foreach (KeyValuePair<Element, XYZ> room in roomPoints)
            {


                i += 100 / max;

                if (i <= 100)
                {
                    backgroundWorker5.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker5.ReportProgress((int)i);
                }

                if (backgroundWorker5.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }



                double shortestLength = 0;
                XYZ closestPoint = new XYZ(0, 0, 0);



                for (int x = 0; x < splinePoints.Count; x++) //finds the shortest lenght door to point
                {

                    if (x == 0) // apply to first door in loop
                    {
                        shortestLength = room.Value.DistanceTo(splinePoints[0]);
                        closestPoint = splinePoints[0];


                    }
                    else
                    {

                        if (room.Value.DistanceTo(splinePoints[x]) < shortestLength)// if there is a shorter door
                        {
                            closestPoint = splinePoints[x];
                            shortestLength = room.Value.DistanceTo(splinePoints[x]);// add the door 

                        }


                    }
                }


                foreach (var item in splinePoints)
                {


                    if (closestPoint == item.Value)
                    {
                        //Spline point num/Door Element/Door Point/Closest point on spline
                        orderedPoints.Add(new Tuple<double, Element, XYZ, XYZ>(item.Key, room.Key, room.Value, closestPoint));
                    }


                }


            }

        }

        private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DTMessage mb = new DTMessage();

                if (e.Cancelled)
                {
                    //MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    //MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter"))
                    {

                        t.Start();

                        orderedPoints = orderedPoints.OrderBy(b => b.Item1).ToList();


                        string paddingNumber = orderedPoints.ToList().Count.ToString();

                        //int zeroes = paddingNumber.Count(char.IsNumber);
                        int zeroes = Convert.ToInt32(comboBoxZeroPad.SelectedItem.ToString());

                        for (int x = 0; x < orderedPoints.ToList().Count; x++)
                        {

                            orderedPoints.ToList()[x].Item2.get_Parameter(BuiltInParameter.ROOM_NUMBER).Set(PrefixString.Text + x.ToString().PadLeft(zeroes, '0') + SuffixString.Text);

                        }

                        t.Commit();

                    }


                    StatusLabel.Text = "Completed";
                    CloseButton.Text = "Finish";
                    progressBar1.Value = 0;
                    roomPoints.Clear();
                    orderedPoints.Clear();
                    ButtonsEnabled();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }

        }


        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = roomPoints.Count;


            foreach (Element E in collRooms)
            {

                foreach (ElementId LV in LevelViewID)
                {
                    if (E.LevelId == LV)
                    {
                        LocationPoint getRoomPoint = E.Location as LocationPoint;

                        roomPoints.Add(E, getRoomPoint.Point as Autodesk.Revit.DB.XYZ);
                    }


                }

            }

            Curve curve = (localSpline as CurveElement).GeometryCurve;

            tessellation = curve.Tessellate();

            splinePoints = new Dictionary<int, XYZ>(1);

            double stepsize = 5.0;
            double dist = 0.0;

            XYZ p = curve.GetEndPoint(0);
            int count = 0;

            foreach (XYZ q in tessellation)
            {
                if (0 == splinePoints.Count)
                {
                    splinePoints.Add(count, p);
                    dist = 0.0;
                    count++;
                }
                else
                {
                    dist += p.DistanceTo(q);

                    if (dist >= stepsize)
                    {
                        splinePoints.Add(count++, q);
                        dist = 0;
                    }
                    p = q;
                }


            }

            foreach (KeyValuePair<Element, XYZ> room in roomPoints)
            {


                i += 100 / max;

                if (i <= 100)
                {
                    backgroundWorker6.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker6.ReportProgress((int)i);
                }

                if (backgroundWorker6.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }



                double shortestLength = 0;
                XYZ closestPoint = new XYZ(0, 0, 0);



                for (int x = 0; x < splinePoints.Count; x++) //finds the shortest lenght door to point
                {

                    if (x == 0) // apply to first door in loop
                    {
                        shortestLength = room.Value.DistanceTo(splinePoints[0]);
                        closestPoint = splinePoints[0];


                    }
                    else
                    {

                        if (room.Value.DistanceTo(splinePoints[x]) < shortestLength)// if there is a shorter door
                        {
                            closestPoint = splinePoints[x];
                            shortestLength = room.Value.DistanceTo(splinePoints[x]);// add the door 

                        }


                    }
                }


                foreach (var item in splinePoints)
                {


                    if (closestPoint == item.Value)
                    {
                        //Spline point num/Door Element/Door Point/Closest point on spline
                        orderedPoints.Add(new Tuple<double, Element, XYZ, XYZ>(item.Key, room.Key, room.Value, closestPoint));
                    }


                }


            }



        }

        private void backgroundWorker6_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DTMessage mb = new DTMessage();

                if (e.Cancelled)
                {
                    //MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;

                }
                else if (e.Error != null)
                {
                    //MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    CloseButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    using (Transaction t = new Transaction(localDoc.Document, "Set Parameter"))
                    {

                        t.Start();

                        orderedPoints = orderedPoints.OrderBy(a => a.Item2.LevelId.IntegerValue).ThenBy(b => b.Item1).ToList();



                        string paddingNumber = orderedPoints.ToList().Count.ToString();

                        //int zeroes = paddingNumber.Count(char.IsNumber);
                        int zeroes = Convert.ToInt32(comboBoxZeroPad.SelectedItem.ToString());


                        for (int x = 0; x < orderedPoints.ToList().Count; x++)
                        {


                            orderedPoints.ToList()[x].Item2.get_Parameter(BuiltInParameter.ROOM_NUMBER).Set(PrefixString.Text + x.ToString().PadLeft(zeroes, '0') + SuffixString.Text);


                        }


                        t.Commit();

                    }

                    StatusLabel.Text = "Completed";
                    CloseButton.Text = "Finish";

                    progressBar1.Value = 0;
                    roomPoints.Clear();
                    orderedPoints.Clear();
                    ButtonsEnabled();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }

        }


        #endregion

        private void SelectElementBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SelectElementBox.Text == "By Doors")
            {
                checkBoxCurtainWalls.Enabled = true;
            }

            if (SelectElementBox.Text == "By Windows")
            {
                checkBoxCurtainWalls.Checked = false;
                checkBoxCurtainWalls.Enabled = false;
            }

            if (SelectElementBox.Text == "By Rooms")
            {
                checkBoxCurtainWalls.Checked = false;
                checkBoxCurtainWalls.Enabled = false;
            }

        }

        private void RenumberSplineForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            backgroundWorker3.CancelAsync();
            backgroundWorker4.CancelAsync();
            backgroundWorker5.CancelAsync();

            FormCollection fc = Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc) //tries looking for the Open Form to get the spline from
            {
                if (frm.Name == "SelectionForm")
                {
                    frm.Close();
                    frm.Dispose();
                    break;

                }
            }


        }
    }


}
