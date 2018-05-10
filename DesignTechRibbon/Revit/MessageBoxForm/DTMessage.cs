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

            //this.Size = new System.Drawing.Size(100, 100);
            //this.Refresh();


            label1.Text = MainText; //Gets the Input Text
            label1.MaximumSize = new Size(groupBox1.Width-10, 0);
            label1.AutoSize = true;

            groupBox1.AutoSize = true;

            if(groupBox1.Height > 200)
            {
                this.Size = new System.Drawing.Size(this.Width, groupBox1.Height + (groupBox1.Height / 2));
            }
            else
            {
                this.Size = new System.Drawing.Size(this.Width, groupBox1.Height + 150);
            }
          

            //this.Size = new System.Drawing.Size(1000, 1000);


            // this.Size = new System.Drawing.Size(this.Width + (this.Width / 10), groupBox1.Height + (groupBox1.Height / 2));

            //if (groupBox1.Height > this.Height)
            //{
            //   // groupBox1.Width = this.Width;
            //   // groupBox1.Height = label1.Height + (label1.Height / 10);

            //    this.Size = new System.Drawing.Size(this.Width + (this.Width / 10), groupBox1.Height + (groupBox1.Height / 2));

            //}
            //else
            //{
            //    this.Size = new System.Drawing.Size(500,500);
            //}





            this.Refresh();


            //label1.AutoSize = true;

            //if(label1.Height > groupBox1.Height)
            //{
            //    groupBox1.Height = label1.Height;
            //    //this.Height = label1.Height;

            //    this.Size = new System.Drawing.Size(groupBox1.Width,groupBox1.Height);
            //    this.Refresh();
            //}

            this.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
