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
using System.Windows.Media.Media3D;
using System.Threading;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

namespace DesignTechRibbon.Revit.EssentialTools.LegendPlacer
{

    public partial class LegendPlacerForm : System.Windows.Forms.Form
    {

        #region Initalise

        public Document localDoc;

        FilteredElementCollector sheetCollector;
        FilteredElementCollector viewPortCollector;
        FilteredElementCollector legendCollector;

        List<Viewport> vP = new List<Viewport>();

        List<Element> allElementsOnSheet = new List<Element>();
        List<Element> allViewportsOnSheet = new List<Element>();

        List<Tuple<Element, Element>> AddToSheet = new List<Tuple<Element, Element>>();
        List<Tuple<Element,Viewport>> RemoveFromSheet = new List<Tuple<Element,Viewport>>();

        GetWinformItems WFItem = new GetWinformItems();

        XYZ userSelectedPoint;

       

        public LegendPlacerForm(Document doc)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;

            

            localDoc = doc;

            sheetCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Sheets).WhereElementIsNotElementType();
            legendCollector = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).WhereElementIsNotElementType();
            viewPortCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Viewports).WhereElementIsNotElementType();


            FormCollection fc = Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc) //tries looking for the Open Form to get the spline from
            {
                if (frm.Name == "PointXYZSelector")
                {
                     PointXYZSelector pxyz = frm as PointXYZSelector;

                    userSelectedPoint = pxyz.MyPoint;

                }
            }




            //get the ID of the views

            foreach (Element E in legendCollector) //Adds all the legends names to the list box
            {
                Autodesk.Revit.DB.View v = doc.GetElement(E.Id) as Autodesk.Revit.DB.View;

             
                if (v.ViewType == ViewType.Legend)
                {   
                    LegendListBox.Items.Add(v.Name);
                }

            }


            foreach (Element E in sheetCollector) // get the dictionary
            {
                ViewSheet VS = (ViewSheet)E;
                WFItem.allSheetsList.Add(new Tuple<string, Element>(VS.SheetNumber, E));
    
            }


            foreach (Tuple<string,Element> v in WFItem.allSheetsList) //adds all the Sheet names to the list box from dictionary
            {
                SheetListBox.Items.Add(v.Item1.ToString() + ": " +  v.Item2.Name);
            }


            StatusLabel.Visible = false;
            StopButton.Enabled = false;
            

        }

        #endregion

        #region Buttons

        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            this.Close();
        }

        private void SelectAllSheets_Click(object sender, EventArgs e)
        {

            try
            {
                for (int x = 0; x < SheetListBox.Items.Count; x++)
                {
                    SheetListBox.SetSelected(x, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DeselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < SheetListBox.Items.Count; x++)
                {
                    SheetListBox.SetSelected(x, false);
                }

                for (int x = 0; x < LegendListBox.Items.Count; x++)
                {
                    LegendListBox.SetSelected(x, false);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlaceButton_Click(object sender, EventArgs e)
        {

            if(SheetListBox.SelectedItems.Count <= 0 || LegendListBox.SelectedItems.Count<= 0)
            {
                MessageBox.Show("Please Select At Least One Item In Each Box", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                PlaceButton.Enabled = false;
                RemoveButton.Enabled = false;
                StopButton.Enabled = true;

                WFItem.selectedSheetsList.Clear();

                StatusLabel.Visible = true;
                StatusLabel.Text = "Please Wait";

                foreach (string SS in SheetListBox.SelectedItems) // in every selected item by user
                {

                    int findSpace = 0;

                    findSpace = SS.IndexOf(":");

                    string getSheetID = SS.Remove(findSpace);

                    foreach (Tuple<string, Element> All in WFItem.allSheetsList) // in all the sheets on the form
                    {

                        if (getSheetID == All.Item1) // If the selected sheet name matches the sheet ID out of all
                        {

                            WFItem.selectedSheetsList.Add(new Tuple<string, Element>(All.Item1, All.Item2)); //Add

                        }

                    }


                    foreach (string SL in LegendListBox.SelectedItems)
                    {

                        WFItem.SelectedLegends.Add(SL);
                    }


                    // progressBar1.Style = ProgressBarStyle.Marquee;

                    if (!this.backgroundWorker1.IsBusy)
                    {
                        this.backgroundWorker1.RunWorkerAsync();
                        this.PlaceButton.Enabled = false;

                    }

                }

            }

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

            if (SheetListBox.SelectedItems.Count <= 0 || LegendListBox.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please Select At Least One Item In Each Box", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                WFItem.selectedSheetsList.Clear();

                RemoveButton.Enabled = false;
                StatusLabel.Visible = true;
                StopButton.Enabled = true;
                StatusLabel.Text = "Please Wait";

                foreach (string SS in SheetListBox.SelectedItems) // in every selected item by user
                {

                    int findSpace = 0;

                    findSpace = SS.IndexOf(":");

                    string getSheetID = SS.Remove(findSpace);

                    foreach (Tuple<string, Element> All in WFItem.allSheetsList) // in all the sheets on the form
                    {

                        if (getSheetID == All.Item1) // If the selected sheet name matches the sheet ID out of all
                        {

                            WFItem.selectedSheetsList.Add(new Tuple<string, Element>(All.Item1, All.Item2)); //Add
                        
                        }

                    }

                }

                foreach (string SL in LegendListBox.SelectedItems)
                {

                    WFItem.SelectedLegends.Add(SL);
                }

                if (!this.backgroundWorker2.IsBusy)
                {
                    this.backgroundWorker2.RunWorkerAsync();
                    this.RemoveButton.Enabled = false;
                    this.PlaceButton.Enabled = false;

                }


            }


         


        }

        private void StopButton_Click_1(object sender, EventArgs e)
        {
            StatusLabel.Visible = false;
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
        }


        #endregion

        #region Background Workers

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            double i = 0;
            double max = sheetCollector.Count();

            foreach (Element S in sheetCollector)
            {

                 i += max / 100;
                 Math.Round(i,MidpointRounding.AwayFromZero);

                if(i <= 100)
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


                foreach (Element L in legendCollector)
                {

                    foreach (Tuple<string, Element> selectedSheet in WFItem.selectedSheetsList)  //Finds which Sheets where selected
                    {
                        foreach( string selectedLegend in WFItem.SelectedLegends) //Finds which Legends were selected
                        {

                            if ((S.get_Parameter(BuiltInParameter.SHEET_NUMBER).AsString() == selectedSheet.Item1) && (L.Name == selectedLegend))
                            {
                                
                                ViewSheet VS = (ViewSheet)S;
                           
                                foreach (ElementId E in VS.GetAllPlacedViews())
                                {
                                    allElementsOnSheet.Add(localDoc.GetElement(E));
                                }

                                bool legendOnSheet = false;

                                if(allElementsOnSheet.Count == 0)
                                {
                                    AddToSheet.Add(new Tuple<Element, Element>(selectedSheet.Item2,L));                         
                                    e.Result = "Place Legend on Empty Sheet";
                                    allElementsOnSheet.Clear();
                                    break;
                                }


                                foreach (Element thisLegend in allElementsOnSheet)
                                {
                           
                                        if (L.Id == thisLegend.Id)
                                        {
                                            legendOnSheet = true;
                                            e.Result = "Legend on sheet not adding";
                                            break;
                                        }

                                    else
                                    {
                                        legendOnSheet = false;
                                        e.Result = "adding legend";
                                    }

                                }

                                if (!legendOnSheet)
                                {

                                    AddToSheet.Add(new Tuple<Element, Element>(S, L));
                                    e.Result = "adding legend";
                                    allElementsOnSheet.Clear();
                                    break;

                                }


                                allElementsOnSheet.Clear();

              
                                //End of if
                            }



                        }
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

            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
                progressBar1.Value = 0;
                this.PlaceButton.Enabled = true;
                this.RemoveButton.Enabled = true;
                StatusLabel.Visible = false;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                progressBar1.Value = 0;
                this.PlaceButton.Enabled = true;
                this.RemoveButton.Enabled = true;
                StatusLabel.Visible = false;
            }
            else
            {

                //Placed the elements onto the sheet here

                XYZ point = userSelectedPoint;

                try
                {
                    using (Transaction t = new Transaction(localDoc, "Place Legend"))
                    {
                        t.Start();
                        foreach (Tuple<Element, Element> add in AddToSheet)
                        {

                            Viewport.Create(localDoc, add.Item1.Id, add.Item2.Id, point);
                        }

                        t.Commit();

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if(AddToSheet.Count == 0)
                {
                    MessageBox.Show("The Task Has Been Completed.\nLegends Were Not Placed As They Already Exist On Selected Sheets");
                }
                else if(AddToSheet.Count == 1)
                {

                    MessageBox.Show("The Task Has Been Completed. " + LegendListBox.SelectedItem.ToString() + " Was Added To " + AddToSheet.Count + " Sheet", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Task Has Been Completed. " + LegendListBox.SelectedItem.ToString() + " Was Added To " + AddToSheet.Count + " Sheets", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                WFItem.SelectedLegends.Clear();
                WFItem.SelectedSheets.Clear();
                AddToSheet.Clear();

                progressBar1.Value = 0;
                this.PlaceButton.Enabled = true;
                this.RemoveButton.Enabled = true;
                StopButton.Enabled = false;

                StatusLabel.Visible = false;
              
            }




        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //https://nerdparadise.com/programming/csharpbackgroundworker

            double i = 0;
            double max = sheetCollector.Count();
            Viewport legendsViewport = null;


            foreach (Element S in sheetCollector)
            {
                i += max / 100;
                Math.Round(i, MidpointRounding.AwayFromZero);

                if (i <= 100)
                {
                    backgroundWorker2.ReportProgress((int)i);
                }
                else
                {
                    i = 100;
                    backgroundWorker2.ReportProgress((int)i);
                }

                //if cancellation is pending, cancel work.  
                if (backgroundWorker2.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }


                foreach (Element L in legendCollector)
                {

                    foreach (Tuple<string, Element> selectedSheet in WFItem.selectedSheetsList)  //Finds which Sheets where selected
                    {
                        foreach (string selectedLegend in WFItem.SelectedLegends) //Finds which Legends were selected
                        {

                            if ((S.get_Parameter(BuiltInParameter.SHEET_NUMBER).AsString() == selectedSheet.Item1) && (L.Name == selectedLegend))
                            {

                                ViewSheet VS = (ViewSheet)S;


                                foreach (ElementId E in VS.GetAllPlacedViews())
                                {
                                    allElementsOnSheet.Add(localDoc.GetElement(E));
                                }


                                bool legendOnSheet = false;

                                foreach (Element thisLegend in allElementsOnSheet)
                                {

                                    if (L.Id == thisLegend.Id)
                                    {
                                        legendOnSheet = true;
                                        e.Result = "Legend on sheet removing";
                                        break;
                                    }

                                    else
                                    {
                                        legendOnSheet = false;
                                        e.Result = "no legend found";
                                    }

                                }

                                if (legendOnSheet)
                                {

                                    foreach (Viewport vp in viewPortCollector)
                                    {
                                        if (vp.SheetId == S.Id)
                                        {
                                            legendsViewport = vp;
                                        }

                                    }

                                    RemoveFromSheet.Add(new Tuple<Element, Viewport>(S, legendsViewport));
                                    allElementsOnSheet.Clear();
                                    break;

                                }




                                allElementsOnSheet.Clear();


                                //End of if
                            }



                        }
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
            if (e.Cancelled)
            {
                MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                progressBar1.Value = 0;
                this.PlaceButton.Enabled = true;
                this.RemoveButton.Enabled = true;
                StatusLabel.Visible = false;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
                this.PlaceButton.Enabled = true;
                this.RemoveButton.Enabled = true;
                StatusLabel.Visible = false;
            }
            else
            {
                try
                {
                    using (Transaction t = new Transaction(localDoc, "Delete Viewport"))
                    {
                        t.Start();

                        foreach (Tuple<Element, Viewport> remove in RemoveFromSheet) // for each (Sheet/Legend) to be removed
                        {

                            ViewSheet VS = (ViewSheet)remove.Item1;

                            VS.DeleteViewport(remove.Item2);

                        }

                        t.Commit();

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                if (RemoveFromSheet.Count == 0)
                {
                    MessageBox.Show("The Task Has Been Completed.\nLegends Were Not Deleted As They Do Not Exist");
                }
                else if (RemoveFromSheet.Count == 1)
                {

                    MessageBox.Show("The Task Has Been Completed. " + LegendListBox.SelectedItem.ToString() + " Was Deleted On " + RemoveFromSheet.Count + " Sheet", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Task Has Been Completed. " + LegendListBox.SelectedItem.ToString() + " Was Deleted On " + RemoveFromSheet.Count + " Sheets", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                WFItem.SelectedLegends.Clear();
                WFItem.SelectedSheets.Clear();
                RemoveFromSheet.Clear();
                allViewportsOnSheet.Clear();

                progressBar1.Value = 0;
                this.PlaceButton.Enabled = true;
                this.RemoveButton.Enabled = true;
                StopButton.Enabled = false;
                StatusLabel.Visible = false;
                //MessageBox.Show("The Task Has Been Completed.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            

        }

        #endregion

        #region Store Data 

        public class GetWinformItems
        {

            public List<Tuple<string, Element>> allSheetsList = new List<Tuple<string, Element>>();

            public List<Tuple<string, Element>> selectedSheetsList = new List<Tuple<string, Element>>();

            public List<string> SelectedLegends = new List<string>();
            public List<string> SelectedSheets = new List<string>();


            public Dictionary<string, Element> IDLegends = new Dictionary<string, Element>();



        }


        #endregion

        private void SheetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelSelectedCount.Text = "Selected Sheets: " + SheetListBox.SelectedItems.Count.ToString();
        }

        private void LegendPlacerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection fc = Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc) //tries looking for the Open Form to get the spline from
            {
                if (frm.Name == "PointXYZSelector")
                {
                    frm.Close();
                    frm.Dispose();
                    break;


                }
            }

        }
    }





}





