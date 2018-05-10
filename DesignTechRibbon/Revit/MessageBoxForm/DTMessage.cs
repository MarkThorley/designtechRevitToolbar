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

            
            label1.MaximumSize = new Size(groupBox1.Width, 0 );
            
            label1.AutoSize = true;

            if(label1.Height > groupBox1.Height)
            {
                groupBox1.Height = label1.Height;
                this.Height = label1.Height;
            }
            
            this.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
