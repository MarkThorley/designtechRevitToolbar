using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using System.Reflection;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using DesignTechRibbon.Revit.EssentialTools.LegendPlacer;

namespace EssentialTools
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class LegendPlacer : IExternalCommand
    {
        bool isFormOpen;

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
          ref string message, ElementSet elements)
        {

            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
            UIApplication uiApp = new UIApplication(revit.Application.Application);

            FormCollection fc = Application.OpenForms;

            foreach (System.Windows.Forms.Form frm in fc) //tries looking for the Open Form to get the spline from
            {
                if (frm.Name == "PointXYZSelector")
                {
                    isFormOpen = true;

                }
            }


            if (isFormOpen == false)
            {
                isFormOpen = true;

                PointXYZSelector form = new PointXYZSelector(uidoc);

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
