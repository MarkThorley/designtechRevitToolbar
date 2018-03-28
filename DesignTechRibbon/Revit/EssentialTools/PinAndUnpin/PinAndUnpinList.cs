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
using DesignTechRibbon.Revit.EssentialTools.PinAndUnpinForm;

namespace EssentialTools
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class PinAndUnpinList : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
        ref string message, ElementSet elements)
        {

            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            PinAndUnpinForm form = new PinAndUnpinForm(doc);

            form.ShowDialog();

            form.Dispose();


            return Result.Succeeded;

        }

    }
}
