using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EssentialTools
{
    public partial class FiltersForm : Form
    {
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeAll;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeUsed;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeUnused;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeUnassigned;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> currentStore;
        internal Dictionary<string, Autodesk.Revit.DB.ElementId> resultStore;
        private List<RadioButton> radioButtons = new List<RadioButton>();
        private bool lockIt = false; 

        public FiltersForm(
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeAll, 
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeUsed,
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeUnused,
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeUnassigned
            )
        {
            InitializeComponent();
            this.storeAll = _storeAll;
            this.storeUsed = _storeUsed;
            this.storeUnused = _storeUnused;
            this.storeUnassigned = _storeUnassigned;
            this.currentStore = storeUnused;
            var registrationsList = currentStore.Keys.ToArray();
            filtersList.Items.AddRange(registrationsList);
            totalLbl.Text = registrationsList.Count().ToString() + " items";
            totalLbl.Update();
            InitialiseRadioButtons();
        }

        private void InitialiseRadioButtons()
        {
            radioAll.Tag = this.storeAll;
            radioUsed.Tag = this.storeUsed;
            radioUnused.Tag = this.storeUnused;
            radioUnassigned.Tag = this.storeUnassigned;
            radioButtons.Add(radioAll);
            radioButtons.Add(radioUsed);
            radioButtons.Add(radioUnused);
            radioButtons.Add(radioUnassigned);
        }

        #region Methods
        /// <summary>
        /// Search filter the Filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrchBox_TextChanged(object sender, EventArgs e)
        {
            if(string.Equals("Contains ..", SrchBox.Text))
            {
                SrchBox.Clear();
            }
            if(!string.Equals("Contains ..", SrchBox.Text))
            {
                SrchBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                SrchBox.ForeColor = System.Drawing.SystemColors.WindowText;
                var registrationsList = currentStore.Keys.ToList(); //return original data from Store

                filtersList.BeginUpdate();
                filtersList.Items.Clear();

                if (!string.IsNullOrEmpty(SrchBox.Text))
                {
                    foreach (string str in registrationsList)
                    {
                        if (str.IndexOf(SrchBox.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            filtersList.Items.Add(str);
                        }
                    }
                }
                else
                    filtersList.Items.AddRange(registrationsList.ToArray()); //there is no any filter string, so add all data we have in Store

                filtersList.EndUpdate();
                totalLbl.Text = filtersList.Items.Count.ToString() + " items";
                totalLbl.Update();
            }
        }
        /// <summary>
        /// Enters the SearchBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrchBox_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Clear();
            box.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            box.ForeColor = System.Drawing.SystemColors.WindowText;
        }
        /// <summary>
        /// Lose focus on the SearchBox - prompt is back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrchBox_Leave(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (string.IsNullOrEmpty(box.Text))
            {
                box.Text = "Contains ..";
                box.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                box.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                box.Update();
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if(!lockIt)
            {
                lockIt = true;

                foreach (RadioButton rbtn in radioButtons)
                {
                    rbtn.Checked = false;
                }
                RadioButton current = sender as RadioButton;
                current.Checked = true;
                currentStore = current.Tag as Dictionary<string, Autodesk.Revit.DB.ElementId>;
                var registrationsList = currentStore.Keys.ToList(); //return original data from Store

                filtersList.BeginUpdate();
                filtersList.Items.Clear();
                filtersList.Items.AddRange(registrationsList.ToArray());
                filtersList.EndUpdate();
                totalLbl.Text = registrationsList.Count().ToString() + " items";
                totalLbl.Update();
                
                
                SrchBox.Text = "Contains ..";
                SrchBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                SrchBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
                SrchBox.Update();

                lockIt = false;
                //return;
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            filtersList.BeginUpdate();

            for (int i = 0; i < filtersList.Items.Count; i++)
                filtersList.SetSelected(i, true);

            filtersList.EndUpdate();
        }
        #endregion

        #region End
        /// <summary>
        /// Cancel the command by Esc key
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// Cancel the command 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// Send the Delete command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delBtn_Click(object sender, EventArgs e)
        {
            var listResults = filtersList.SelectedItems.Cast<String>().ToList();
            resultStore = currentStore.Where(x => listResults.Contains(x.Key)).ToDictionary(dict => dict.Key, dict => dict.Value);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        /// <summary>
        /// Open designtech website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void designtechLogo_Click(object sender, EventArgs e)
        {
            ProcessStartInfo designtechWeb = new ProcessStartInfo("http://designtech.io/");
            Process.Start(designtechWeb);
        }


        #endregion

        private void filtersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalLbl.Text = filtersList.SelectedItems.Count.ToString() + " selected items";
        }
    }
}
