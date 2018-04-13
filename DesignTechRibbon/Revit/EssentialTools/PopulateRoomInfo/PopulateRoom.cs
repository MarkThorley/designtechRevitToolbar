using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DesignTechRibbon.Revit.EssentialTools.PopulateRoomInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EssentialTools
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class PopulateRoom : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,ref string message, ElementSet elements)
        {

            UIApplication uiapp = revit.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            PopulateRoomForm form = new PopulateRoomForm(doc);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();

            return Result.Succeeded;



        }

    }
}
