using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignTechRibbon.Revit.MessageBoxForm
{
    public partial class DTMessage : Form
    {
        public DTMessage()
        {
            InitializeComponent();
        }

        public void ShowMessage(string MainText)
        {
            label1.Text = MainText;

            label1.MinimumSize = new Size(groupBox1.Width, groupBox1.Width /*- this.Height/6*/);
            label1.MaximumSize = new Size(groupBox1.Width, groupBox1.Width /*- this.Height/6*/);

            //label1.AutoSize = true;
            
            this.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
