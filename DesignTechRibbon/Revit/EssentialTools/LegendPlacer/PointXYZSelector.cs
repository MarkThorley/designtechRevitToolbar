using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignTechRibbon.Revit.EssentialTools.LegendPlacer
{
    public partial class PointXYZSelector : System.Windows.Forms.Form
    {

        XYZ userSelectedPoint;
        UIDocument localDoc;


        static IExternalEventHandler handler_event = new ExternalEventMy();
        ExternalEvent exEvent = ExternalEvent.Create(handler_event);



        public PointXYZSelector(UIDocument doc)
        {
            InitializeComponent();
            localDoc = doc;

            label2.Text = "Press the Select Point button and choose a Point\non the active view";

        }

        private void SelectPointButton_Click(object sender, EventArgs e)
        {


            this.Hide();

            try
            {


                userSelectedPoint = localDoc.Selection.PickPoint();

                label1.Text = "User Selected\n" + "\nX: " + Math.Round(userSelectedPoint.X,5)  + "\nY: " + Math.Round(userSelectedPoint.Y,5);

                this.Show();
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.Show();
            }

      
        }

        private void LoadPointButton_Click(object sender, EventArgs e)
        {
            if (userSelectedPoint != null)
            {

                var confirmResult = MessageBox.Show("Use This Point", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {

                    exEvent.Raise();

                }

            }
            else
            {
                MessageBox.Show("No Point Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        class ExternalEventMy : IExternalEventHandler
        {
            public void Execute(UIApplication uiapp) //External Event Is used to get around the transaction limit
            {

                //MessageBox.Show("External Event is running");

                UIDocument uidoc = uiapp.ActiveUIDocument;
                Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
                Document doc = uidoc.Document;

                //  RenumberSplineForm RenumForm = new RenumberSplineForm(uidoc);
                //  RenumForm.ShowDialog();

                LegendPlacerForm form = new LegendPlacerForm(doc);

                form.ShowDialog();




            }
            public string GetName()
            {
                return "my event";
            }
        }

        public XYZ MyPoint //Stores the value so other forms can find and use it
        {
            get
            {
                return this.userSelectedPoint;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}


