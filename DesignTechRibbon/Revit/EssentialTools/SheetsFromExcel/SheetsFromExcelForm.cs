using Autodesk.Revit.DB;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Linq;
using DesignTechRibbon.Revit.MessageBoxForm;

namespace DesignTechRibbon.Revit.EssentialTools.SheetsFromExcelForm
{
    public partial class SheetsFromExcelForm : System.Windows.Forms.Form
    {

        #region Initalise

        Document localDoc;

        GetSetData Variables = new GetSetData();

        ListView listData = new ListView();

        List<ListViewItem> elements = new List<ListViewItem>();

        Dictionary<string, string> sheetData = new Dictionary<string, string>();

        List<Tuple<FamilySymbol,string,string>> userSheets = new List<Tuple<FamilySymbol, string, string>>();

        ElementId titleBlockID;

        FilteredElementCollector collSheets;
        FilteredElementCollector collTitleblock;

        public SheetsFromExcelForm(Document doc)
        {

            InitializeComponent();

            localDoc = doc;

            if (Variables.xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed.");
                return;
            }

            listViewExcel.Columns.Add("Sheet Number", 156);
            listViewExcel.Columns.Add("Sheet Name", 160);

            listViewExcel.FullRowSelect = true;
            StopButton.Enabled = false;
            StatusLabel.Visible = false;

            collSheets = new FilteredElementCollector(localDoc).OfClass(typeof(ViewSheet)).WhereElementIsNotElementType();
            collTitleblock = new FilteredElementCollector(localDoc).OfCategory(BuiltInCategory.OST_TitleBlocks).WhereElementIsElementType();


            foreach (var item in collTitleblock.OrderBy(x => x.Name))
            {
                comboBoxTitleblock.Items.Add(item.Name);

            }

            if(comboBoxTitleblock.Items.Count>0) //if atleast one item is found
            {
                comboBoxTitleblock.SelectedIndex = 0; // set to first
            }
            else
            {
                comboBoxTitleblock.Enabled = false;
            }



        }

        #endregion


        #region Buttons

        private void TemplateButton_Click(object sender, EventArgs e)
        {

            object templateWorkBook = System.Reflection.Missing.Value;

            string folderLocation = "";

            Variables.xlWorkBookTemplate = Variables.xlApp.Workbooks.Add(templateWorkBook);

            Variables.xlWorkSheetTemplate = (Excel.Worksheet)Variables.xlWorkBookTemplate.Worksheets.get_Item(1);

            Variables.xlWorkSheetTemplate.Cells[1, 1] = "Sheet Number";
            Variables.xlWorkSheetTemplate.Cells[1, 2] = "Sheet Name";
            Variables.xlWorkSheetTemplate.Cells[2, 1] = "1";
            Variables.xlWorkSheetTemplate.Cells[2, 2] = "Sheet One";
            Variables.xlWorkSheetTemplate.Cells[3, 1] = "2";
            Variables.xlWorkSheetTemplate.Cells[3, 2] = "Sheet Two";


            FolderBrowserDialog browseFolders = new FolderBrowserDialog();

            DialogResult result = browseFolders.ShowDialog();

            if (result == DialogResult.OK)
            {

                folderLocation = browseFolders.SelectedPath;

            }

            try
            {
                Variables.xlWorkBookTemplate.SaveAs(folderLocation + "/designtech_ImportSheets_Template.xlsx");

                MessageBox.Show("Template was Saved At" + folderLocation, "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Template was not saved.\n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            Variables.templateWasCreated = true;
            Variables.xlWorkBookTemplate.Close(0);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            this.Close();
        }

        private void GetDataButton_Click(object sender, EventArgs e)
        {

            CleanUpListForm();

            Variables.fileLocation = GetFileLocation();

            if (!this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
                GetDataButton.Enabled = false;
                TemplateButton.Enabled = false;
                StopButton.Enabled = true;
                StatusLabel.Visible = true;

            }



        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }


        private void SelectAllButon_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < listViewExcel.Items.Count; x++)
                {
                    listViewExcel.Items[x].Selected = true;
                    listViewExcel.Select();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectNoneButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < listViewExcel.Items.Count; x++)
                {
                    listViewExcel.Items[x].Selected = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateSheetsButton_Click(object sender, EventArgs e)
        {

            if(listViewExcel.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewExcel.SelectedItems)
                {
                    sheetData.Add(item.SubItems[0].Text, item.SubItems[1].Text);
                }

                if (!this.backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.RunWorkerAsync();
                }

            }
            else
            {
                MessageBox.Show("No items Were Seleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        #endregion


        #region Background Workers

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            try
            {
                Variables.xlWorkBookExtract = Variables.xlApp.Workbooks.Open(Variables.fileLocation);

                Variables.xlWorkSheetExtract = Variables.xlWorkBookExtract.Sheets[1];
                Variables.xlRangeExtract = Variables.xlWorkSheetExtract.UsedRange;

                int rowCount = Variables.xlRangeExtract.Rows.Count;
                int colCount = Variables.xlRangeExtract.Columns.Count;

                double i = 0;
                double max = rowCount;

                for (int x = 1; x <= rowCount; x++)
                {

                    i += (100 * 1) / max;

                    if (i <= 100)
                    {
                         backgroundWorker1.ReportProgress((int)i);
                    }


                    //if cancellation is pending, cancel work.  
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }


                    for (int y = 1; y <= colCount; y++)
                    {

                        if (Variables.xlRangeExtract.Cells[x, y] != null && Variables.xlRangeExtract.Cells[x, y].Value2 != null)
                        {

                            if (y == 1)
                            {
                             
                                Variables.collOne.Add(Variables.xlRangeExtract.Cells[x, y].Value.ToString());
                            }
                            else
                            {
                                Variables.collTwo.Add(Variables.xlRangeExtract.Cells[x, y].Value.ToString());
                            }


                        }
                        else
                        {
                            if (y == 1)
                            {
                                Variables.collOne.Add("Unnamed");
                            }
                            else
                            {
                                Variables.collTwo.Add("Unnamed");
                            }


                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            try
            {
                DTMessage mb = new DTMessage();

                if (e.Cancelled)
                {

                    mb.ShowMessage("The Task Has Been Cancelled");
                    mb.Text = "Cancelled";

                    StatusLabel.Text = "Cancelled";
                    closeButton.Text = "Close";

                    CleanUpListForm();
                    Variables.collOne.Clear();
                    Variables.collTwo.Clear();
                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;


                }
                else if (e.Error != null)
                {
                    mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                    mb.Text = "Error";

                    StatusLabel.Text = "Error";
                    closeButton.Text = "Close";

                    progressBar1.Value = 0;
                    StatusLabel.Visible = false;
                }
                else
                {
                    int rowCount = Variables.xlRangeExtract.Rows.Count;
                    int colCount = Variables.xlRangeExtract.Columns.Count;

                    for (int x = 0; x < rowCount; x++)
                    {

                        if (rowCount == Variables.collOne.Count && rowCount == Variables.collTwo.Count)
                        {
                            Variables.columnArray[0] = Variables.collOne[x];
                            Variables.columnArray[1] = Variables.collTwo[x];

                            Variables.listElement = new ListViewItem(Variables.columnArray);
                            listViewExcel.Items.Add(Variables.listElement);
                        }
           
                    }

                    if (Variables.xlWorkBookExtract != null)
                    {
                        Variables.xlWorkBookExtract.Close(0);
                        Variables.dataWasExtracted = true;
                    }


                    Variables.collOne.Clear();
                    Variables.collTwo.Clear();


                    listViewExcel.Items.RemoveAt(0);

                    if(listViewExcel.Columns[0].Width < 200)
                    {
                        listViewExcel.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                    else
                    {
                        listViewExcel.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }


                    progressBar1.Value = 0;
               
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressBar1.Value = 0;
            }


            GetDataButton.Enabled = true;
            TemplateButton.Enabled = true;
            StopButton.Enabled = false;
            StatusLabel.Visible = false;

        }



        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            double i = 0;
            double max = sheetData.Count;


            foreach (var data in sheetData)
            {


                i += (100 * 1) / max;

                if (i <= 100)
                {
                    backgroundWorker2.ReportProgress((int)i);
                }


                //if cancellation is pending, cancel work.  
                if (backgroundWorker2.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }



                bool doesIDExist = false;

                foreach (var E in collSheets)
                {
                    ViewSheet VS = (ViewSheet)E;

                    if (VS.SheetNumber == data.Key)
                    {
                        doesIDExist = true;
                    }

                }

                if (doesIDExist == false)
                {

                    try
                    {

                        // Get an available title block from document
                        FilteredElementCollector collector = new FilteredElementCollector(localDoc);
                        collector.OfClass(typeof(FamilySymbol));
                        collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

                        FamilySymbol fs = collector.FirstElement() as FamilySymbol;

                        userSheets.Add(new Tuple<FamilySymbol, string, string>(fs, data.Key, data.Value));


                    }
                    catch
                    {

                    }

                }



            }

        }

        private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            DTMessage mb = new DTMessage();

            if (e.Cancelled)
            {
                mb.ShowMessage("The Task Has Been Cancelled");
                mb.Text = "Cancelled";


                StatusLabel.Text = "Cancelled";
                closeButton.Text = "Close";

                progressBar1.Value = 0;
            
            }
            else if (e.Error != null)
            {

                mb.ShowMessage("Error. Details: " + (e.Error as Exception).ToString());
                mb.Text = "Error";

                StatusLabel.Text = "Error";
                closeButton.Text = "Close";

                progressBar1.Value = 0;
              
            }
            else
            {

                try
                {
                    using (Transaction t = new Transaction(localDoc, "Add Sheet"))
                    {

                        t.Start();

                        foreach (Tuple<FamilySymbol, string, string> item in userSheets)
                        {

                            if(titleBlockID != null)
                            {
                               ViewSheet viewSheet = ViewSheet.Create(localDoc,titleBlockID);
                               viewSheet.SheetNumber = item.Item2;
                               viewSheet.ViewName = item.Item3;
                            }
                            else
                            {
                                ViewSheet viewSheet = ViewSheet.Create(localDoc,ElementId.InvalidElementId);
                                viewSheet.SheetNumber = item.Item2;
                                viewSheet.ViewName = item.Item3;
                            }

                      
                        }

                        t.Commit();

                    }


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    progressBar1.Value = 0;
                }

                StatusLabel.Text = "Completed";
                closeButton.Text = "Finish";

                userSheets.Clear();
                sheetData.Clear();

                progressBar1.Value = 0;


            }

        }

        #endregion


        #region Clean Up and Data Storage

        void CleanUpFiles()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            if (Variables.dataWasExtracted)
            {

                Marshal.ReleaseComObject(Variables.xlRangeExtract);
                Marshal.ReleaseComObject(Variables.xlWorkSheetExtract);

            }

            if (Variables.templateWasCreated)
            {

                Marshal.ReleaseComObject(Variables.xlWorkSheetTemplate);
                Marshal.ReleaseComObject(Variables.xlWorkBookTemplate);
            }

            Variables.xlApp.Quit();
            Marshal.ReleaseComObject(Variables.xlApp);

        }

        void CleanUpListForm()
        {

            listViewExcel.Clear();

            listViewExcel.Columns.Add("Sheet Number", 156);
            listViewExcel.Columns.Add("Sheet Name", 160);

            listViewExcel.FullRowSelect = true;

        }

        public string GetFileLocation()
        {

            FolderBrowserDialog browseFolders = new FolderBrowserDialog();
            OpenFileDialog browseFiles = new OpenFileDialog();

            browseFiles.ShowDialog();

            return browseFiles.FileName;

        }

        public class GetSetData
        {


            public Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            public Excel.Workbook xlWorkBookTemplate;
            public Excel.Worksheet xlWorkSheetTemplate;

            public Excel.Workbook xlWorkBookExtract;
            public Excel.Worksheet xlWorkSheetExtract;
            public Excel.Range xlRangeExtract;


            public bool templateWasCreated = false;
            public bool dataWasExtracted = false;

            public List<string> collOne = new List<string>();
            public List<string> collTwo = new List<string>();

            public string fileLocation = "";


            public string[] columnArray = new string[2];
            public ListViewItem listElement;
        }

        #endregion


        #region Form Events

        private void SheetsFromExcelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            CleanUpFiles();
        }

        #endregion

        private void comboBoxTitleblock_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var item in collTitleblock)
            {
                if(comboBoxTitleblock.SelectedItem.ToString() == item.Name)
                {
                    titleBlockID = item.Id;
                }

            }



        }
    }
}
