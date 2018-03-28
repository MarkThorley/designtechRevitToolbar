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
using DesignTechRibbon.Revit.EssentialTools.RenumberSpline;
using Autodesk.Revit.UI.Selection;

namespace EssentialTools
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class RenumberSpline : IExternalCommand
    {

        Reference splineRefrence;

        Element selectedSpline;

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
        ref string message, ElementSet elements)
        {

            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            ReferenceArray ra = new ReferenceArray();
            ISelectionFilter selFilter = new DetailLineFilter();


            try
            {
                splineRefrence = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, selFilter);
                selectedSpline = uidoc.Document.GetElement(splineRefrence.ElementId);
                RenumberSplineForm form = new RenumberSplineForm(uidoc,selectedSpline);
                form.ShowDialog();

                form.Dispose();
            }
            catch(Exception ex)
            {
                TaskDialog.Show("Error", ex.Message);
            }


            return Result.Succeeded;

        }


        public class DetailLineFilter : ISelectionFilter
        {
            public bool AllowElement(Element e)
            {
                return (e.Category.Id.IntegerValue.Equals(
                  (int)BuiltInCategory.OST_Lines));
            }
            public bool AllowReference(Reference r, XYZ p)
            {
                return false;
            }
        }

    }
}
