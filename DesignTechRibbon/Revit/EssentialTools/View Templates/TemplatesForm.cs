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
    public partial class TemplatesForm : Form
    {
        private Dictionary<string, Autodesk.Revit.DB.ElementId> store;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeAll;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> currentStore;
        internal Dictionary<string, Autodesk.Revit.DB.ElementId> resultStore;


        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeUsed;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeUnused;
        private Dictionary<string, Autodesk.Revit.DB.ElementId> storeUnassigned;
        private List<RadioButton> radioButtons = new List<RadioButton>();
    

        public TemplatesForm(
            Dictionary<string, Autodesk.Revit.DB.ElementId> _store, 
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeAll,
             Dictionary<string, Autodesk.Revit.DB.ElementId> _storeUsed,
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeUnused,
            Dictionary<string, Autodesk.Revit.DB.ElementId> _storeUnassigned

            )
        {
            InitializeComponent();
            this.store = _store;
            this.storeAll = _storeAll;
            this.storeUsed = _storeUsed;
            this.storeUnused = _storeUnused;
            this.storeUnassigned = _storeUnassigned;
            this.currentStore = store;
            var registrationsList = store.Keys.ToArray();
            templateList.Items.AddRange(registrationsList);
            totalLbl.Text = registrationsList.Count().ToString() + " items";
            totalLbl.Update();
    
        }

        #region Methods


        /// <summary>
        /// Search filter the View Templates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrchBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.Equals("Contains ..", SrchBox.Text))
            {
                SrchBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                SrchBox.ForeColor = System.Drawing.SystemColors.WindowText;
                var registrationsList = currentStore.Keys.ToList(); //return original data from Store

                templateList.BeginUpdate();
                templateList.Items.Clear();

                if (!string.IsNullOrEmpty(SrchBox.Text))
                {
                    foreach (string str in registrationsList)
                    {
                        if (str.IndexOf(SrchBox.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            templateList.Items.Add(str);
                        }
                    }
                }
                else
                    templateList.Items.AddRange(registrationsList.ToArray()); //there is no any filter string, so add all data we have in Store

                templateList.EndUpdate();
                totalLbl.Text = templateList.Items.Count.ToString() + " items";
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
            }
        }
        /// <summary>
        /// Toggle between Unused and All View Templates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usedBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                currentStore = storeAll;
            }
            else
            {
                currentStore = store;
            }
            var registrationsList = currentStore.Keys.ToList(); //return original data from Store

            templateList.BeginUpdate();
            templateList.Items.Clear();
            templateList.Items.AddRange(registrationsList.ToArray());
            templateList.EndUpdate();

            totalLbl.Text = registrationsList.Count().ToString() + " items";
            totalLbl.Update();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            templateList.BeginUpdate();

            for (int i = 0; i < templateList.Items.Count; i++)
                templateList.SetSelected(i, true);

            templateList.EndUpdate();
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
            var listResults = templateList.SelectedItems.Cast<String>().ToList();
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

        private void templateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalLbl.Text = templateList.SelectedItems.Count.ToString() + " selected items";
        }
    }
}
