using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using Autodesk.Windows;

using UIFramework;
using RibbonItem = Autodesk.Revit.UI.RibbonItem;
using VCButtonsWithVideoToolTip;
using System.IO;
using System.Media;
using static System.Environment;

namespace DesignTechRibbon
{

    class App : IExternalApplication
    {

        public static string dirWin7 = Environment.GetEnvironmentVariable("UserProfile") + "\\AppData\\Roaming\\";
        public Result OnStartup(UIControlledApplication application)
        {

            // Call our method that will load up our toolbar
            AddRibbonPanel(application);


            return Result.Succeeded;
        }



        // Define a method that will create our tab and button
        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "designtech.io";
            application.CreateRibbonTab(tabName);

     
            Autodesk.Revit.UI.RibbonPanel aboutPanel = application.CreateRibbonPanel(tabName, "About");
            Autodesk.Revit.UI.RibbonPanel managePanel = application.CreateRibbonPanel(tabName,"Manage");
            Autodesk.Revit.UI.RibbonPanel toolsPanel = application.CreateRibbonPanel(tabName, "Tools");
            Autodesk.Revit.UI.RibbonPanel excelPanel = application.CreateRibbonPanel(tabName, "Excel");

            //info
            CreateInfoButton(application, tabName, aboutPanel);

            //Manage
            CreateRemoveViewTemplatesButton(application, tabName, managePanel);
            CreateRemoveFiltersButton(application, tabName, managePanel);

            //Tools   
            CreatePinUnpinButton(application, tabName, toolsPanel);
            CreateSplineRenumberButton(application, tabName, toolsPanel);

            CreateMatchFireRatingButton(application, tabName, toolsPanel);
            CreateLegendPlacerButton(application, tabName, toolsPanel);

            //Excel
            CreateExcelSheetButton(application, tabName, excelPanel);



        }

        //Manage Tab Buttons
        static void CreateRemoveViewTemplatesButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdTemplates",
               "View\nTemplates", thisAssemblyPath, "EssentialTools.CommandRemoveTemplates"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Delete view templates from a custom UI interface. Toggle between view templates that are used and not used, or search for a particular view template by its name.";

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/view_template.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }

        static void CreateInfoButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {
  

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdInfo",
               "Info", thisAssemblyPath, "EssentialTools.Info"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Licence Information";

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/about.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }

        static void CreateRemoveFiltersButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {
 

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdRemoveFilters",
               "Remove\nFilters", thisAssemblyPath, "EssentialTools.CommandRemoveFilters"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Delete filters from a custom UI interface. Toggle between any filters in the model that are unused, used or unassigned, or search for a particular filter by its name";

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/filters.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }


        //Tools Buttons

        static void CreatePinUnpinButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {
            // Autodesk.Revit.UI.RibbonPanel newPanel = a.CreateRibbonPanel(tabname, "Manage");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdPin/UnpinFromList",
               "Pin/Unpin", thisAssemblyPath, "EssentialTools.PinAndUnpinList"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = @"Choose to pin/unpin levels, grids and links in bulk from a custom UI interface.";

            Uri uriImage2 = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/pin_unpin.png"));

            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage2);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }

        static void CreateSplineRenumberButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdSpline",
               "Renumber\nElements", thisAssemblyPath, "EssentialTools.RenumberSpline"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            //  SetRibbonItemToolTip(pushButton, CreateSplineToolTip);
            pushButton.ToolTip = "Renumber doors, windows or rooms based on a picked spline. Elements are then numbered based on their proximity to parameters on that curve.";


            try
            {
                Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/renumber_elements.png"));
                // Apply image to bitmap
                BitmapImage largeImage = new BitmapImage(uriImage);
                // Apply image to button 
                pushButton.LargeImage = largeImage;
            }
            catch(Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("a", ex.Message);
            }

        }

        static void CreateMatchFireRatingButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdFireDoorWall",
               "Match Fire\nRatings", thisAssemblyPath, "EssentialTools.MatchFireDoorWall"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Push Fire Rating From Walls to Doors/Windows";

            try
            {
                Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/fire_ratings.png"));
                // Apply image to bitmap
                BitmapImage largeImage = new BitmapImage(uriImage);
                // Apply image to button 
                pushButton.LargeImage = largeImage;
            }
            catch (Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("a", ex.Message);
            }

        }

        static void CreateLegendPlacerButton(UIControlledApplication a, string tabname,Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdHelloWorld",
               "Place\nLegends", thisAssemblyPath, "EssentialTools.LegendPlacer"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Select a series of sheets and choose to place a legend automatically on each one at a specified location.";

            try
            {
               // Uri uriImage = new Uri((@"C:\Users\rahil\Documents\Visual Studio 2015\Projects\designtechRibbon-master-20180206T094812Z-001\designtechRibbon-master\DesignTechRibbon\Resources\EssentialTools\place_legends.png"));
                Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/place_legends.png"));

                // Apply image to bitmap
                BitmapImage largeImage = new BitmapImage(uriImage);
                // Apply image to button 
                pushButton.LargeImage = largeImage;
            }
            catch (Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("a", ex.Message);
            }



        }


        //Excel Tab Buttons
        static void CreateExcelSheetButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdExcelSheet",
               "Import\nSheets", thisAssemblyPath, "EssentialTools.SheetsFromExcel"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            pushButton.ToolTip = "Create drawing sheets by importing a simple Excel drawing list.";

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/import_sheets.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }

        /// <summary>
        /// A method that allows you to create a Push Button with greater ease
        /// </summary>
        /// <param name="ribbonPanel"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="command"></param>
        /// <param name="tooltip"></param>
        /// <param name="icon"></param>
        private static void CreatePushButton(Autodesk.Revit.UI.RibbonPanel ribbonPanel, string name, string path, string command, string tooltip, string icon)
        {
            PushButtonData pbData = new PushButtonData(
                name,
                name,
                path,
                command);

            PushButton pb = ribbonPanel.AddItem(pbData) as PushButton;
            pb.ToolTip = tooltip;
            BitmapImage pb2Image = new BitmapImage(new Uri(String.Format("pack://application:,,,/DesignTechRibbon;component/Resources/{0}", icon)));
            pb.LargeImage = pb2Image;
        }

        /////Ribbon

        public Autodesk.Windows.RibbonItem GetRibbonItem(Autodesk.Revit.UI.RibbonItem item)
        {
            Type itemType = item.GetType();

            var mi = itemType.GetMethod("getRibbonItem",
              BindingFlags.NonPublic | BindingFlags.Instance);

            var windowRibbonItem = mi.Invoke(item, null);

            return windowRibbonItem
              as Autodesk.Windows.RibbonItem;
        }

        static void SetRibbonItemToolTip(RibbonItem item, RibbonToolTip toolTip)
        {
            IUIRevitItemConverter itemConverter =
                new InternalMethodUIRevitItemConverter();

            var ribbonItem = itemConverter.GetRibbonItem(item);
            if (ribbonItem == null)
                return;
            ribbonItem.ToolTip = toolTip;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // Do nothing
            return Result.Succeeded;
        }



    }




}


