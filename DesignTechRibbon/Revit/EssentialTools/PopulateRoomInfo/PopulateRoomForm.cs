using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace DesignTechRibbon.Revit.EssentialTools.PopulateRoomInfo
{
    public partial class PopulateRoomForm : System.Windows.Forms.Form
    {

        Document localDoc;

        public PopulateRoomForm(Document doc)
        {
            InitializeComponent();
            localDoc = doc;

            FilteredElementCollector collRooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType();


        }
    }
}
