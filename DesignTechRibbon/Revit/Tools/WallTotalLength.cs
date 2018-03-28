using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;


namespace TotalLength
{
    [Transaction(TransactionMode.Manual)]
    public class WallTotalLength : IExternalCommand
    {
        public class WallsLineFilter : ISelectionFilter
        {
            public bool AllowElement(Element e)
            {
                return (e.Category.Id.IntegerValue.Equals(
                  (int)BuiltInCategory.OST_Walls));
            }
            public bool AllowReference(Reference r, XYZ p)
            {
                return false;
            }
        }

        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            // Get application and document objects
            UIApplication uiApp = commandData.Application;

            try
            {
                // Implement Selection Filter to select curves
                IList<Element> pickedRef = null;
                Selection sel = uiApp.ActiveUIDocument.Selection;
                WallsLineFilter selFilter = new WallsLineFilter();
                pickedRef = sel.PickElementsByRectangle(selFilter, "Select walls");

                // Measure their total length
                List<double> lengthList = new List<double>();
                foreach (Element e in pickedRef)
                {
                    Wall position = e as Wall;
                    if (position != null)
                    {
                        double len = position.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
                        lengthList.Add(len);
                    }
                }

                string lengthFeet = Math.Round(lengthList.Sum(), 2).ToString() + " ft";
                string lengthMeters = Math.Round(lengthList.Sum() * 0.3048, 2).ToString() + " m";
                string lengthMillimeters = Math.Round(lengthList.Sum() * 304.8, 2).ToString() + " mm";
                string lengthInch = Math.Round(lengthList.Sum() * 12, 2).ToString() + " inch";

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Total Length is:");
                sb.AppendLine("");
                sb.AppendLine(lengthMillimeters);
                sb.AppendLine(lengthMeters);
                sb.AppendLine(lengthInch);
                sb.AppendLine(lengthFeet);

                // Return a message window that displays total length to user
                TaskDialog.Show("Wall Length", sb.ToString());

                // Assuming that everything went right return Result.Succeeded
                return Result.Succeeded;
            }
            // This is where we "catch" potential errors and define how to deal with them
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // If user decided to cancel the operation return Result.Canceled
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                // If something went wrong return Result.Failed
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}