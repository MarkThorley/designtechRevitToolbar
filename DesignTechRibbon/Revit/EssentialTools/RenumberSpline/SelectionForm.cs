using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesignTechRibbon.Revit.EssentialTools.RenumberSpline
{
    public partial class SelectionForm : System.Windows.Forms.Form
    {

        #region Initalise

        UIDocument localDoc;

        private Element SelectedElement;

        Reference selectedRef;

        static IExternalEventHandler handler_event = new ExternalEventMy();

        ExternalEvent exEvent = ExternalEvent.Create(handler_event);

        public SelectionForm(UIDocument doc)
        {

            InitializeComponent();
            localDoc = doc;
            label2.AutoSize = true;
            label2.MaximumSize = new Size(groupBox1.Width - 20, 0);
            label2.Text = "Select a model nurb spline in the document.This renumbers elements based off proximity.To increase accuracy, draw spline closer to the elements you wish to renumber.";

        }

        #endregion



        private void SelectionButton_Click(object sender, EventArgs e)
        {

            this.Hide();

            try
            {
                selectedRef = localDoc.Selection.PickObject(ObjectType.Element);

                Element S = localDoc.Document.GetElement(selectedRef);


                if (S.GetType().Name.ToString() == typeof(ModelNurbSpline).Name.ToString())
                {
                    SelectedElement = localDoc.Document.GetElement(S.Id); 
                     exEvent.Raise();
                }
                else
                {
                    MessageBox.Show("Selected Item Is Not A Model Nurb Spline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                this.Show();

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                this.Dispose();
     
            }


        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public Element MyProperty //Stores the value so other forms can find and use it
        {
            get
            {
                return this.SelectedElement;
            }
        }
    }

    class ExternalEventMy : IExternalEventHandler
    {
        public void Execute(UIApplication uiapp) //External Event Is used to get around the transaction limit
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
 
            RenumberSplineForm form = new RenumberSplineForm(uidoc);

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;

            form.ShowDialog();

        }
        public string GetName()
        {
            return "my event";
        }
    }
}
