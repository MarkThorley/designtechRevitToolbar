using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesignTechRibbon.Revit.EssentialTools.PinAndUnpinForm
{

    public partial class PinAndUnpinForm : System.Windows.Forms.Form
    {

        #region Initialise

        Document localDoc;

        Dictionary<Element, string> localElements = new Dictionary<Element, string>();

        List<Element> changeElement = new List<Element>();
    //    List<string> stringElements = new List<string>();
        List<Tuple<string, string, string>> stringElementsLV = new List<Tuple<string, string, string>>();
        List<RadioButton> aa = new List<RadioButton>();

        FilteredElementCollector levelCollector;
        FilteredElementCollector gridCollector;
        FilteredElementCollector linkCollector;

        Dictionary<Element, string> pinElement = new Dictionary<Element, string>();
        Dictionary<Element, string> unpinElement = new Dictionary<Element, string>();

        Dictionary<Element, string> pinElementRVT = new Dictionary<Element, string>();
        Dictionary<Element, string> unpinElementRVT = new Dictionary<Element, string>();

        string col1 = "Type";
        string col2 = "Name";
        string col3 = "Pinned";
    
        List<string> getListBoxAsStrings = new List<string>();

        public PinAndUnpinForm(Document doc)
        {
            InitializeComponent();

            this.localDoc = doc;
            
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;


            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;


            backgroundWorker3.WorkerReportsProgress = true;
            backgroundWorker3.WorkerSupportsCancellation = true;

            listView1.View = System.Windows.Forms.View.Details;
            listView1.Columns.Add("Type",130);
            listView1.Columns.Add("Name",130);
            listView1.Columns.Add("Pinned", 130);

            var elementInfo = new List<Tuple<string,string,string>>();

            List<string[]> rows = new List<string[]>();


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

                //    stringElements.Add("RVT Link" + "\t\t" + name + "\t" + E.Value);

                    stringElementsLV.Add(new Tuple<string, string, string>("RVT Links",name,E.Value));

                    elementInfo.Add(new Tuple<string, string, string>("RVT Links", name, E.Value));

                    ListViewItem LVI = new ListViewItem(E.Key.Category.Name);
                    LVI.SubItems.Add(name);
                    LVI.SubItems.Add(E.Value);

                    listView1.Items.Add(LVI);


                }
                else
                {


                    stringElementsLV.Add(new Tuple<string, string, string>(E.Key.Category.Name, E.Key.Name, E.Value));

                    elementInfo.Add(new Tuple<string, string,string>(E.Key.Category.Name, E.Key.Name, E.Value));

                   
                    ListViewItem LVI = new ListViewItem(E.Key.Category.Name);
                    LVI.SubItems.Add(E.Key.Name);
                    LVI.SubItems.Add(E.Value);

                    listView1.Items.Add(LVI);


                }


            }

            this.totalLbl.Text = listView1.Items.Count.ToString() + " items";

            elementList.Hide();
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (listView1.Columns[0].Width < 200 || listView1.Columns[1].Width < 200 || listView1.Columns[2].Width < 200)
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

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


            ClearLists();



            foreach (string s in elementList.SelectedItems )
            {

              //  getListBoxAsStrings.Add(s); changed

            }


            foreach (int index in listView1.SelectedIndices)
            {

                ListViewItem LVI = listView1.Items[index];


                string addString = LVI.SubItems[0].Text + LVI.SubItems[1].Text + LVI.SubItems[2].Text;

                getListBoxAsStrings.Add(addString);
             //   getListBoxAsStrings.Add(item.Text);
                
               
            }
      


   
         //   getListBoxAsStrings.Add()


            if (!this.backgroundWorker1.IsBusy)
            {
                AllDisabled();
                this.backgroundWorker1.RunWorkerAsync();

            }


        }

        private void radioLevel_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                listView1.Items.Clear();

                if (radioLevel.Checked)
                {

                  //  List<string> levelsAsString = new List<string>();

                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        if (E.Key.Category.Name == "Levels")
                        {


                          //  levelsAsString.Add(E.Key.Category.Name + "\t\t" + E.Key.Name + "\t\t" + E.Value);
                            ListViewItem LVI = new ListViewItem(E.Key.Category.Name);
                            LVI.SubItems.Add(E.Key.Name);
                            LVI.SubItems.Add(E.Value);

                            listView1.Items.Add(LVI);

                        }

                    }

                //    elementList.Items.Clear();

                    listView1.Refresh();





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
                listView1.Items.Clear();
                if (radioGrid.Checked)
                {
                    List<string> gridAsString = new List<string>();

                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                        if (E.Key.Category.Name == "Grids")
                        {

                            gridAsString.Add(E.Key.Category.Name + "\t\t" + E.Key.Name + "\t\t" + E.Value);
                            ListViewItem LVI = new ListViewItem(E.Key.Category.Name);
                            LVI.SubItems.Add(E.Key.Name);
                            LVI.SubItems.Add(E.Value);

                            listView1.Items.Add(LVI);

                        }

                    }

                    elementList.Items.Clear();

                    foreach (string s in gridAsString)
                    {
                        elementList.Items.Add(s);
                    }

                    elementList.Refresh();

                }

                listView1.Refresh();

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
                listView1.Items.Clear();
                if (radioLink.Checked)
                {

                    List<string> radioAsString = new List<string>();

                    foreach (KeyValuePair<Element, string> E in localElements)
                    {

                       

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {
                            string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);
                            radioAsString.Add("RVT Link" + "\t\t" + name + "\t" + E.Value);
                            ListViewItem LVI = new ListViewItem("RVT Links");
                            LVI.SubItems.Add(name);
                            LVI.SubItems.Add(E.Value);

                            listView1.Items.Add(LVI);

                        }

                    }

                    elementList.Items.Clear();

                    foreach (string s in radioAsString)
                    {
                        elementList.Items.Add(s);
                    }

                    elementList.Refresh();

                    this.Refresh();

                    listView1.Refresh();


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
                for (int x = 0; x < listView1.Items.Count; x++)
                {
                    listView1.Items[x].Selected = true;
                    listView1.Select();
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
                for (int x = 0; x < listView1.Items.Count; x++)
                {
                    listView1.Items[x].Selected = false;
                   // listView1.Select();
                }
                totalLbl.Text = listView1.Items.Count.ToString() + " items";

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


            ClearLists();

            /*  foreach (string s in elementList.Items)
              {

                  getListBoxAsStrings.Add(s);

              }
              */

            for (int x = 0; x < listView1.Items.Count; x++)
            {
                listView1.Items[x].Selected = true;
                listView1.Select();
            }




            foreach (int index in listView1.SelectedIndices)
            {

                ListViewItem LVI = listView1.Items[index];


                string addString = LVI.SubItems[0].Text + LVI.SubItems[1].Text + LVI.SubItems[2].Text;

                getListBoxAsStrings.Add(addString);
                //   getListBoxAsStrings.Add(item.Text);


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


            ClearLists();


            for (int x = 0; x < listView1.Items.Count; x++)
            {
                listView1.Items[x].Selected = true;
                listView1.Select();
            }




            foreach (int index in listView1.SelectedIndices)
            {

                ListViewItem LVI = listView1.Items[index];

                //check which type it is

                

                string addString = LVI.SubItems[0].Text + LVI.SubItems[1].Text + LVI.SubItems[2].Text;

                getListBoxAsStrings.Add(addString);
  

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


                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {

                              string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);
                              currentElementLink = "RVT Links" + name + E.Value;

                            


                        }
                        else
                        {

                            currentElement = E.Key.Category.Name + E.Key.Name.ToString() +  E.Value;
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The Task Has Been Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //Unpin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Link"))
                {
                    t.Start();

                    foreach (KeyValuePair<Element, string> UPE in unpinElement)
                    {
                        UPE.Key.Pinned = false;


                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if(item.Item2 == UPE.Key.Name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>(UPE.Key.Category.Name, UPE.Key.Name, "False");

                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                 
                            }

                        }





                    }





                    t.Commit();

                }

                //Pin
                using (Transaction t = new Transaction(localDoc, "(Pin/Unpin) Level Grid Link"))
                {
                    t.Start();

                    // E.Key.Pinned = true;

                    foreach (KeyValuePair<Element, string> PE in pinElement)
                    {
                        PE.Key.Pinned = true;


                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 == PE.Key.Name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>(PE.Key.Category.Name, PE.Key.Name, "True");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

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


                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 == name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>("RVT Links", name, "False");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

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



                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 == name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>("RVT Links", name, "True");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }

                        }


                    }




                    t.Commit();


                }

                ChangeValues();
                ClearLists();
                radioFull.Checked = true;
                AllEnabled();

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

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {
                            string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);
                            currentElementLink = "RVT Links" + name + E.Value;

                        }
                        else
                        {

                            currentElement = E.Key.Category.Name  + E.Key.Name.ToString() + E.Value;
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

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
 
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());

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

                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 == PE.Key.Name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>(PE.Key.Category.Name, PE.Key.Name, "True");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

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

                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 ==name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>("RVT Links",name, "True");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }

                        }



                    }




                    t.Commit();
                   

                }


                ChangeValuesAllTrue();
                ClearLists();
                radioFull.Checked = true;
                AllEnabled();





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


                 

                        if (E.Key.GetType().ToString() == "Autodesk.Revit.DB.RevitLinkInstance")
                        {
                            string name = E.Key.Name.Remove(E.Key.Name.IndexOf(":") + 1);
                            currentElementLink = "RVT Links" +  name + E.Value;

                        }
                        else
                        {

                            currentElement = E.Key.Category.Name + E.Key.Name.ToString() + E.Value;
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

        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
   
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
  
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

                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 == UPE.Key.Name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>(UPE.Key.Category.Name, UPE.Key.Name, "False");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

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

                        int index;

                        foreach (var item in stringElementsLV.ToList())
                        {
                            if (item.Item2 == name)
                            {
                                try
                                {
                                    index = stringElementsLV.IndexOf(item);
                                    stringElementsLV[index] = new Tuple<string, string, string>(UPE.Key.Category.Name,name, "False");

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }

                        }

                    }


                    t.Commit();


                }

                ChangeValuesAllFalse();
                ClearLists();
                radioFull.Checked = true;
                AllEnabled();
  

            }



        }

        #endregion


        #region Value Change Methods

        void UpdateElementList()
        {


            try
            {

                listView1.Items.Clear();

                foreach(var i in stringElementsLV)
                {

                    ListViewItem LVI = new ListViewItem(i.Item1);
                    LVI.SubItems.Add(i.Item2);
                    LVI.SubItems.Add(i.Item3);

                    listView1.Items.Add(LVI);
                }

                listView1.Refresh();

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                totalLbl.Text = listView1.SelectedItems.Count.ToString() + " selected items";
            else
                totalLbl.Text = listView1.Items.Count.ToString() + " items";
        }
    }



}
    


