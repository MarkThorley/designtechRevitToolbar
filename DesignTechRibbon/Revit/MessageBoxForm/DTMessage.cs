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
            try
            {
                label1.Text = MainText;                                     //Gets the Input Text
                label1.MaximumSize = new Size(groupBox1.Width - 10, 0);     //Makes the label width almost the window size
                label1.AutoSize = true;                                     //Label1 Will size based on the text
                groupBox1.AutoSize = true;                                  //Group Box will Size based on the label

                if (groupBox1.Height > 200)
                {
                    this.Size = new System.Drawing.Size(this.Width, groupBox1.Height + (groupBox1.Height / 2)); //Sets Width of the box to the form size and increases the height bu half
                }
                else
                {
                    this.Size = new System.Drawing.Size(this.Width, groupBox1.Height + 150); //Increases the height by a small amount
                }

                this.Refresh(); //Update Changes to the form 

                this.ShowDialog();  //Display Form


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error",ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
