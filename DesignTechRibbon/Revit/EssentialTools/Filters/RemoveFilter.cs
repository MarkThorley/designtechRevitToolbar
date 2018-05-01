using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DesignTechRibbon.Revit.MessageBoxForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EssentialTools
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class CommandRemoveFilters : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            RemoveFilter removeFilter = new RemoveFilter(commandData);
            if(removeFilter.failed)
            {
                return Result.Failed;
            }
            // Invoke the removefilter method
            removeFilter.DeleteUnusedFilters();
            
            return Result.Succeeded;
        }
    }

    internal class RemoveFilter
    {        
        private ExternalCommandData _commandData;
        private OverrideGraphicSettings _defaultOverrides;
        internal bool failed = false;

        private static HashSet<ElementId> all = new HashSet<ElementId>();
        private static HashSet<ElementId> used = new HashSet<ElementId>();
        private static HashSet<ElementId> unused = new HashSet<ElementId>();
        private static HashSet<ElementId> unassigned = new HashSet<ElementId>();
    
        private static UIApplication uiapp;
        private static UIDocument uidoc;
        private static Autodesk.Revit.ApplicationServices.Application app;
        private static Document doc;

        public bool removeFromView {get; set;}
        
        /// <summary>
        /// Constructor. Takes the external common data (of the Revit app)
        /// </summary>
        /// <param name="data"></param>
        public RemoveFilter(ExternalCommandData data)
        {
            _commandData = data;
            _defaultOverrides = new OverrideGraphicSettings();

            uiapp = _commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;

            Initialize();
        }
        /// <summary>
        /// Get all the infroamtion that we need to procede
        /// All unused filters, remove all unused on views
        /// </summary>
        private void Initialize()
        {
            GetAllFilters();
            GetUsedFilters();
            GetUnusedFilters();
        }
        /// <summary>
        /// Delete unused filters main method
        /// </summary>
        public void DeleteUnusedFilters()
        {
            /*
            Dictionary<string, ElementId> store = new Dictionary<string, ElementId>();
            Dictionary<string, ElementId> storeAll = new Dictionary<string, ElementId>();
            Dictionary<string, ElementId> storeUsed = new Dictionary<string, ElementId>();
            Dictionary<string, ElementId> storeUnused = new Dictionary<string, ElementId>();
            Dictionary<string, ElementId> storeUnassigned = new Dictionary<string, ElementId>();
            */
            Dictionary<string, ElementId> store = new Dictionary<string, ElementId>();
            Dictionary<string, ElementId> storeAll = all.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            Dictionary<string, ElementId> storeUsed = used.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            Dictionary<string, ElementId> storeUnused = unused.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            Dictionary<string, ElementId> storeUnassigned = unassigned.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            //Dictionary<string, ElementId> storeAll = all.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            //Dictionary<string, ElementId> storeUsed = used.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            //Dictionary<string, ElementId> storeUnused = unused.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            //Dictionary<string, ElementId> storeUnassigned = unassigned.ToDictionary(x => (doc.GetElement(x) as ParameterFilterElement).Name, x => x);
            
            using (FiltersForm form = new FiltersForm(storeAll, storeUsed, storeUnused, storeUnassigned))
            {
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;
                System.Windows.Forms.DialogResult result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    store = form.resultStore;
                    using (Transaction t = new Transaction(doc, "Delete filters"))
                    {
                        t.Start();
                        doc.Delete(store.Values);
                        t.Commit();
                    }
                    // MessageBox.Show("Unused Filters:" + Environment.NewLine + store.Count.ToString() + " Filters were removed.", "Unused Filters.");

                    DTMessage mb = new DTMessage();
                    string message = "Unused Filters:" + Environment.NewLine + store.Count.ToString() + " Filters were removed.";

                    mb.ShowMessage(message, "Unused Filters");

                    MessageBox.Show("Unused Filters:" + Environment.NewLine + store.Count.ToString() + " Filters were removed.", "Unused Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
        /// <summary>
        /// Returns all filters
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private void GetAllFilters()
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            all = new HashSet<ElementId>(collector.OfClass(typeof(ParameterFilterElement)).ToElementIds().ToList());
        }
        /// <summary>
        /// Returns all the used filters in a project
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private void GetUsedFilters()
        {
            //FilteredElementCollector collector = new FilteredElementCollector(doc);
            //IList<Element> views = collector.OfClass(typeof(Autodesk.Revit.DB.View)).WhereElementIsNotElementType().ToElements();
            //Filted Out the Sheets

            FilteredElementCollector collViewPlan = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).WhereElementIsNotElementType();
            FilteredElementCollector collViewSection = new FilteredElementCollector(doc).OfClass(typeof(ViewSection)).WhereElementIsNotElementType();
            FilteredElementCollector collView3D= new FilteredElementCollector(doc).OfClass(typeof(View3D)).WhereElementIsNotElementType();

            IList<Element> filteredViews = new List<Element>();

            foreach (var item in collViewPlan)
            {
                filteredViews.Add(item);
            }


            foreach (var item in collViewSection)
            {
                filteredViews.Add(item);
            }


            foreach (var item in collView3D)
            {
                filteredViews.Add(item);
            }

            foreach (Element el in filteredViews)
                {
                    Autodesk.Revit.DB.View v = el as Autodesk.Revit.DB.View;
                    ICollection<ElementId> filterIds;
                    try
                    {
                        filterIds = v.GetFilters();
                    }
                    catch (AmbiguousMatchException)
                    {
                        continue;
                    }
                    catch (Autodesk.Revit.Exceptions.InvalidOperationException)
                    {
                        continue;
                    }
                    foreach (ElementId id in filterIds)
                    {
     
                        if (used.Contains(id))
                        {
                            continue;
                        }
                        OverrideGraphicSettings filterOverrides = v.GetFilterOverrides(id);
                        bool filterVisible = v.GetFilterVisibility(id);

                        if (CompareOverrides(filterOverrides, _defaultOverrides) && filterVisible)
                        {
                            unassigned.Add(id);
                        }
                        else
                        {
                            used.Add(id);
                        }
                    }
                    
                }
 
            unassigned = new HashSet<ElementId>(unassigned.ToList().Except(used.ToList()));
        }
        /// <summary>
        /// Returns the unused filters in a projects as all filters minus used filters
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private void GetUnusedFilters()
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<ElementId> exclude = new List<ElementId>();
            exclude.AddRange(used.ToList());
            exclude.AddRange(unassigned.ToList());
            if(exclude.Count > 0)
            {
                unused = new HashSet<ElementId>(collector.OfClass(typeof(ParameterFilterElement)).Excluding(exclude).ToElementIds().ToList());
            }
        }
        /// <summary>
        /// If false, the filter is different then a default one so it is in use
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        private bool CompareOverrides(OverrideGraphicSettings o1, OverrideGraphicSettings o2)
        {
            if (o1.CutFillColor.IsValid) return false;
            if (o1.CutLineColor.IsValid) return false;
            if (o1.Halftone) return false;
            if (o1.ProjectionFillColor.IsValid) return false;
            if (o1.ProjectionLineColor.IsValid) return false;
            if (o1.CutFillPatternId != o2.CutFillPatternId) return false;
            if (o1.CutLinePatternId != o2.CutLinePatternId) return false;
            if (o1.DetailLevel != o2.DetailLevel) return false;
            if (o1.IsCutFillPatternVisible != o2.IsCutFillPatternVisible) return false;
            if (o1.IsProjectionFillPatternVisible != o2.IsProjectionFillPatternVisible) return false;
            if (o1.ProjectionFillPatternId != o2.ProjectionFillPatternId) return false;
            if (o1.ProjectionLinePatternId != o2.ProjectionLinePatternId) return false;
            if (o1.ProjectionLineWeight != o2.ProjectionLineWeight) return false;
            if (o1.Transparency != o2.Transparency) return false;
            return true;
        }
    }
}
