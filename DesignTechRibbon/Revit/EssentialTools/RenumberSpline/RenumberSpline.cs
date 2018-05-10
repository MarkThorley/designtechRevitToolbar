using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DesignTechRibbon.Revit.EssentialTools.RenumberSpline;
using System.Windows.Forms;

namespace EssentialTools
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]


    class RenumberSpline : IExternalCommand
    {
        bool isFormOpen;

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
        ref string message, ElementSet elements)
        {

            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;


            FormCollection fc = Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc) //tries looking for the Open Form to get the spline from
            {
                if (frm.Name == "SelectionForm")
                {
                    isFormOpen = true;

                }
            }

            if (isFormOpen == false)
            {
                isFormOpen = true;

                SelectionForm form = new SelectionForm(uidoc);

                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;

                form.Show();

            }
            else
            {
                MessageBox.Show("Form Already Open, Please Close Previous Instance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return Result.Succeeded;
        }


    }







}
