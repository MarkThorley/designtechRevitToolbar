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

            label2.Text = "Press the Select Point button and choose a Point\non the active view where the legend will be placed";
            
        }

        private void SelectPointButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            try
            {
                try
                {
                    Autodesk.Revit.DB.View view = localDoc.ActiveView;

                    if (view is Autodesk.Revit.DB.ViewSheet)
                    {
                        userSelectedPoint = localDoc.Selection.PickPoint();
                    }
                    else
                    {
                        MessageBox.Show("Please Choose a View Sheet\nDouble Left Click The View Sheet Which The Legend Will Be Placed On", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Show();
                    }                   
                }
                catch
                {
                    MessageBox.Show("Please Choose a Point In the Active View\nDouble Left Click The View Which The Legend Will Be Placed On"
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Show();
                }

                if (userSelectedPoint != null)
                {
                    exEvent.Raise();
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Show();
            }
        }


        class ExternalEventMy : IExternalEventHandler
        {
            public void Execute(UIApplication uiapp) //External Event Is used to get around the transaction limit
            {
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
                Document doc = uidoc.Document;

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


