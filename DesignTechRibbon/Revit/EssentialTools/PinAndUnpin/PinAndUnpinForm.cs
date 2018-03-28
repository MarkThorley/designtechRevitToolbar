using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesignTechRibbon.Revit.EssentialTools.PinAndUnpinForm
{

    public partial class PinAndUnpinForm : System.Windows.Forms.Form
    {

        #region Initialise

        Document localDoc;

        Dictionary<Element, string> localElements = new Dictionary<Element, string>();

        List<Element> changeElement = new List<Element>();
        List<string> stringElements = new List<string>();
        List<RadioButton> aa = new List<RadioButton>();

        FilteredElementCollector levelCollector;
        FilteredElementCollector gridCollector;
        FilteredElementCollector linkCollector;

        Dictionary<Element, string> pinElement = new Dictionary<Element, string>();
        Dictionary<Element, string> unpinElement = new Dictionary<Element, string>();

        Dictionary<Element, string> pinElementRVT = new Dictionary<Element, string>();
        Dictionary<Element, string> unpinElementRVT = new Dictionary<Element, string>();

        List<string> getListBoxAsStrings = new List<string>();

        public PinAndUnpinForm(Document doc)
        {
            InitializeComponent();

            this.localDoc = doc;
            StopButton.Enabled = false;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;


            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;


            backgroundWorker3.WorkerReportsProgress = true;
            backgroundWorker3.WorkerSupportsCancellation = true;

            StatusLabel.Visible = false;

            levelCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType();
            gridCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Grids).WhereElementIsNotElementType();
            linkCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_RvtLinks).WhereElementIsNotElementType();

            foreach (Element L in levelCollector)
            {
                localElements.Add(L, L.Pinned.ToString());
            }

            foreach (Element G in gridCollector)
            {
                localElements.Add(G, G.Pinned.ToString());
            }

            foreach (Element Link in linkCollector)
            {
                localElements.Add(Link, Link.Pinned.ToString());
            }


            foreach (KeyValuePair<Element, string> E in localElements) //Separates the pins/grids from the links
            {

                if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                {

                    string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);

                    stringElements.Add("RVT Link" + "\t\t" + name + "\t" + E.Value);

                }
                else
                {

                    stringElements.Add(E.Key.Category.Name + "\t\t" + E.Key.Name + "\t\t" + E.Value);
                }


            }

            foreach (string s in stringElements)//adds the list to the list box
            {
                elementList.Items.Add(s);

            }

            ChangeValues();

        }

        #endregion


        #region Buttons

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            backgroundWorker3.CancelAsync();
            this.Close();
        }

        private void PinUnpinBtn_Click(object sender, EventArgs e)
        {

            StatusLabel.Visible = true;

            ClearLists();



            foreach (string s in elementList.SelectedItems )
            {

                getListBoxAsStrings.Add(s);

            }


            if (!this.backgroundWorker1.IsBusy)
            {
                AllDisabled();
                StopButton.Enabled = true;
                this.backgroundWorker1.RunWorkerAsync();
               

            }


        }

        private void radioLevel_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                if (radioLevel.Checked)
                {

                    List<string> levelsAsString = new List<string>();

                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        if (E.Key.Category.Name == "Levels")
                        {


                            levelsAsString.Add(E.Key.Category.Name + "\t\t" + E.Key.Name + "\t\t" + E.Value);

                        }

                    }

                    elementList.Items.Clear();

                    foreach (string s in levelsAsString)
                    {
                        elementList.Items.Add(s);
                    }

                    elementList.Refresh();

                    this.Refresh();



                }

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }




        }

        private void radioGrid_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (radioGrid.Checked)
                {
                    List<string> gridAsString = new List<string>();

                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        if (E.Key.Category.Name == "Grids")
                        {

                            gridAsString.Add(E.Key.Category.Name + "\t\t" + E.Key.Name + "\t\t" + E.Value);

                        }

                    }

                    elementList.Items.Clear();

                    foreach (string s in gridAsString)
                    {
                        elementList.Items.Add(s);
                    }

                    elementList.Refresh();

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }







        }

        private void radioLink_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioLink.Checked)
                {

                    List<string> radioAsString = new List<string>();

                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {

                            radioAsString.Add("RVT Link" + "\t\t" + name + "\t" + E.Value);

                        }

                    }

                    elementList.Items.Clear();

                    foreach (string s in radioAsString)
                    {
                        elementList.Items.Add(s);
                    }

                    elementList.Refresh();

                    this.Refresh();




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {

            try
            {
                for (int x = 0; x < elementList.Items.Count; x++)
                {
                    elementList.SetSelected(x, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonNone_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < elementList.Items.Count; x++)
                {
                    elementList.SetSelected(x, false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void radioFull_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioFull.Checked)
                {
                    UpdateElementList();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            backgroundWorker3.CancelAsync();
        }

        private void ClearLists()
        {
            getListBoxAsStrings.Clear();
            pinElement.Clear();
            unpinElement.Clear();
            pinElementRVT.Clear();
            unpinElementRVT.Clear();

        }

        private void PinAll_Click(object sender, EventArgs e)
        {
            StatusLabel.Visible = true;

            ClearLists();

            foreach (string s in elementList.Items)
            {

                getListBoxAsStrings.Add(s);

            }


            if (!this.backgroundWorker2.IsBusy)
            {
                AllDisabled();
                cancelBtn.Enabled = true;
                this.backgroundWorker2.RunWorkerAsync();


            }
        }

        private void UnpinAll_Click(object sender, EventArgs e)
        {
            StatusLabel.Visible = true;

            ClearLists();

            foreach (string s in elementList.Items)
            {

                getListBoxAsStrings.Add(s);

            }


            if (!this.backgroundWorker3.IsBusy)
            {
                AllDisabled();
                cancelBtn.Enabled = true;
                this.backgroundWorker3.RunWorkerAsync();


            }
        }

        #endregion


        #region Background Workers

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double i = 0;
            double max = getListBoxAsStrings.Count;

            try
            {
                foreach (string selectedText in getListBoxAsStrings)
                {


                    i += max / 100;
                    Math.Round(i, MidpointRounding.AwayFromZero);

                    if (i <= 100)
                    {
                        backgroundWorker1.ReportProgress((int)i);
                    }
                    else
                    {
                        i = 100;
                        backgroundWorker1.ReportProgress((int)i);
                    }

                    //if cancellation is pending, cancel work.  
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }


                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        string currentElement = "";
                        string currentElementLink = "";


                        string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {

                            currentElementLink = "RVT Link" + "\t\t" + name + "\t" + E.Value;

                        }
                        else
                        {

                            currentElement = E.Key.Category.Name + "\t\t" + E.Key.Name.ToString() + "\t\t" + E.Value;
                        }



                        #region Check Levels/Grids

                        if (currentElement == selectedText)
                        {

                            changeElement.Add(E.Key);




                            if (E.Key.Pinned)
                            {

                                //list for Unpin

                                unpinElement.Add(E.Key, currentElement);

                            }


                            else
                            {

                                //List for Pin
                                pinElement.Add(E.Key, currentElement);



                            }


                        }

                        #endregion


                        #region Check RVT Links

                        if (currentElementLink == selectedText)
                        {


                            changeElement.Add(E.Key);

                            #region UnPin
                            if (E.Key.Pinned == true)
                            {

                                unpinElementRVT.Add(E.Key, currentElementLink);

                            }

                            #endregion

                            #region Pin
                            if (E.Key.Pinned == false)
                            {

                                pinElementRVT.Add(E.Key, currentElementLink);

                            }

                            #endregion


                        }

                        #endregion

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
            if (e.Cancelled)
            {
                MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                StatusLabel.Visible = false;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StatusLabel.Visible = false;
            }
            else
            {
                //Unpin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();

                    foreach (KeyValuePair<Element, string> UPE in unpinElement)
                    {
                        UPE.Key.Pinned = false;

                        for (int x = 0; x < stringElements.Count; x++)
                        {


                            if (stringElements[x] == UPE.Value)
                            {

                                stringElements[x] = UPE.Key.Category.Name + "\t\t" + UPE.Key.Name + "\t\t" + "False";

                            }


                        }

                    }





                    t.Commit();

                }

                //Pin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();

                    // E.Key.Pinned = true;

                    foreach (KeyValuePair<Element, string> PE in pinElement)
                    {
                        PE.Key.Pinned = true;

                        for (int x = 0; x < stringElements.Count; x++)
                        {
                            if (stringElements[x] == PE.Value)
                            {

                                stringElements[x] = PE.Key.Category.Name + "\t\t" + PE.Key.Name + "\t\t" + "True";


                            }


                        }

                    }



                    t.Commit();


                }

                ///////////////////////////////////////RVT

                //Unpin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();

                    foreach (KeyValuePair<Element, string> UPE in unpinElementRVT)
                    {
                        UPE.Key.Pinned = false;

                        string name = UPE.Key.Name.Remove(UPE.Key.Name.IndexOf(":") + 1);

                        for (int x = 0; x < stringElements.Count; x++)
                        {

                            if (stringElements[x] == UPE.Value)
                            {
                                stringElements[x] = "RVT Link" + "\t\t" + name + "\t" + "False";
                            }


                        }




                    }


                    t.Commit();


                }

                //Pin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();



                    foreach (KeyValuePair<Element, string> PE in pinElementRVT)
                    {
                        PE.Key.Pinned = true;

                        string name = PE.Key.Name.Remove(PE.Key.Name.IndexOf(":") + 1);

                        for (int x = 0; x < stringElements.Count; x++)
                        {

                            if (stringElements[x] == PE.Value)
                            {


                                stringElements[x] = "RVT Link" + "\t\t" + name + "\t" + "True";

                            }


                        }


                    }




                    t.Commit();


                }

                progressBar1.Value = 0;
                ChangeValues();
                ClearLists();
                radioFull.Checked = true;
                AllEnabled();
                StopButton.Enabled = false;
                StatusLabel.Visible = false;




            }




        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double i = 0;
            double max = getListBoxAsStrings.Count;

            try
            {
                foreach (string selectedText in getListBoxAsStrings)
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


                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        string currentElement = "";
                        string currentElementLink = "";


                        string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {

                            currentElementLink = "RVT Link" + "\t\t" + name + "\t" + E.Value;

                        }
                        else
                        {

                            currentElement = E.Key.Category.Name + "\t\t" + E.Key.Name.ToString() + "\t\t" + E.Value;
                        }



                        #region Check Levels/Grids

                        if (currentElement == selectedText)
                        {

                            changeElement.Add(E.Key);

                            //List for Pin
                            pinElement.Add(E.Key, currentElement);


                        }

                        #endregion


                        #region Check RVT Links

                        if (currentElementLink == selectedText)
                        {

                            changeElement.Add(E.Key);

                            pinElementRVT.Add(E.Key, currentElementLink);

                        }

                        #endregion

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
                StatusLabel.Visible = false;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
                StatusLabel.Visible = false;
            }
            else
            {

                //Pin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();

                    foreach(KeyValuePair<Element,string> PE in pinElement)
                    {
                        PE.Key.Pinned = true;

                        for (int x = 0; x < stringElements.Count; x++)
                        {
                            if (stringElements[x] ==  PE.Value)
                            {

                                stringElements[x] = PE.Key.Category.Name + "\t\t" + PE.Key.Name + "\t\t" + "True";


                            }


                        }

                    }



                    t.Commit();
   

                }
    
                //Pin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();



                    foreach (KeyValuePair<Element, string> PE in pinElementRVT)
                    {
                        PE.Key.Pinned = true;

                        string name = PE.Key.Name.Remove(PE.Key.Name.IndexOf(":") + 1);

                        for (int x = 0; x < stringElements.Count; x++)
                        {

                            if (stringElements[x] == PE.Value)
                            {


                                stringElements[x] = "RVT Link" + "\t\t" + name + "\t" + "True";

                            }


                        }


                    }




                    t.Commit();
                   

                }


                progressBar1.Value = 0;
                ChangeValuesAllTrue();
                ClearLists();
                radioFull.Checked = true;
                AllEnabled();
                StopButton.Enabled = false;
                StatusLabel.Visible = false;




            }


        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            double i = 0;
            double max = getListBoxAsStrings.Count;

            try
            {
                foreach (string selectedText in getListBoxAsStrings)
                {


                    i += max / 100;
                    Math.Round(i, MidpointRounding.AwayFromZero);

                    if (i <= 100)
                    {
                        backgroundWorker3.ReportProgress((int)i);
                    }
                    else
                    {
                        i = 100;
                        backgroundWorker3.ReportProgress((int)i);
                    }

                    //if cancellation is pending, cancel work.  
                    if (backgroundWorker3.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }


                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        string currentElement = "";
                        string currentElementLink = "";


                        string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {

                            currentElementLink = "RVT Link" + "\t\t" + name + "\t" + E.Value;

                        }
                        else
                        {

                            currentElement = E.Key.Category.Name + "\t\t" + E.Key.Name.ToString() + "\t\t" + E.Value;
                        }



                        #region Check Levels/Grids

                        if (currentElement == selectedText)
                        {

                            changeElement.Add(E.Key);

                            //List for Pin
                            unpinElement.Add(E.Key, currentElement);


                        }

                        #endregion


                        #region Check RVT Links

                        if (currentElementLink == selectedText)
                        {

                            changeElement.Add(E.Key);

                            unpinElementRVT.Add(E.Key, currentElementLink);

                        }

                        #endregion

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void backgroundWorker3_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
                StatusLabel.Visible = false;
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
                StatusLabel.Visible = false;
            }
            else
            {
                //Unpin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();

                    foreach (KeyValuePair<Element, string> UPE in unpinElement)
                    {
                        UPE.Key.Pinned = false;

                        for (int x = 0; x < stringElements.Count; x++)
                        {


                            if (stringElements[x] == UPE.Value)
                            {

                                stringElements[x] = UPE.Key.Category.Name + "\t\t" + UPE.Key.Name + "\t\t" + "False";

                            }


                        }

                    }

                    t.Commit();

                }

                ///////////////////////////////////////RVT

                //Unpin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Links"))
                {
                    t.Start();

                    foreach (KeyValuePair<Element, string> UPE in unpinElementRVT)
                    {
                        UPE.Key.Pinned = false;

                        string name = UPE.Key.Name.Remove(UPE.Key.Name.IndexOf(":") + 1);

                        for (int x = 0; x < stringElements.Count; x++)
                        {

                            if (stringElements[x] == UPE.Value)
                            {
                                stringElements[x] = "RVT Link" + "\t\t" + name + "\t" + "False";
                            }


                        }




                    }


                    t.Commit();


                }

                progressBar1.Value = 0;
                ChangeValuesAllFalse();
                ClearLists();
                radioFull.Checked = true;
                AllEnabled();
                StopButton.Enabled = false;
                StatusLabel.Visible = false;

            }



        }

        #endregion


        #region Value Change Methods

        void UpdateElementList()
        {


            try
            {
                elementList.Items.Clear(); //Clear the Listbox

                foreach (string s in stringElements) //Adds new Elements as strings
                {
                    elementList.Items.Add(s);
                }

                elementList.Refresh();

                changeElement.Clear();

                radioFull.Enabled = true;

                this.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        void ChangeValues()
        {
            try
            {

                foreach (Element Change in changeElement)
                {

                    if (localElements[Change] == "False")
                    {
                        localElements[Change] = "True";
                    }
                    else
                    {
                        localElements[Change] = "False";
                    }

                }


                UpdateElementList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        void ChangeValuesAllTrue()
        {
            try
            {

                foreach (Element Change in changeElement)
                {

                    localElements[Change] = "True";

                }
                UpdateElementList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        void ChangeValuesAllFalse()
        {
            try
            {

                foreach (Element Change in changeElement)
                {

                    localElements[Change] = "False";

                }
                UpdateElementList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        void AllEnabled()
        {
            PinUnpinButton.Enabled = true;
            PinAll.Enabled = true;
            UnpinAll.Enabled = true;
                

        }

        void AllDisabled()
        {

            PinUnpinButton.Enabled = false;
            PinAll.Enabled = false;
            UnpinAll.Enabled = false;

        }

        #endregion


    }



}
    


