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

            Autodesk.Revit.UI.RibbonPanel managePanel = application.CreateRibbonPanel(tabName,"Manage");
            Autodesk.Revit.UI.RibbonPanel toolsPanel = application.CreateRibbonPanel(tabName, "Tools");
            Autodesk.Revit.UI.RibbonPanel excelPanel = application.CreateRibbonPanel(tabName, "Excel");

            //Manage
            CreateRemoveViewTemplatesButton(application,tabName,managePanel);
            CreateRemoveFiltersButton(application,tabName,managePanel);

            //Tools   
            CreatePinUnpinButton(application, tabName, toolsPanel);
            CreateSplineRenumberButton(application, tabName, toolsPanel);
            CreateMatchFireRatingButton(application, tabName, toolsPanel);
            CreateLegendPlacerButton(application, tabName, toolsPanel);


            //Excel
            CreateExcelSheetButton(application, tabName,excelPanel);




            /*   // Add a new ribbon panel
                 Autodesk.Revit.UI.RibbonPanel ribbonPanel1 = application.CreateRibbonPanel(tabName, "Tools");
                 Autodesk.Revit.UI.RibbonPanel ribbonPanel2 = application.CreateRibbonPanel(tabName, "View Templates");
                 Autodesk.Revit.UI.RibbonPanel ribbonPanel3 = application.CreateRibbonPanel(tabName, "Filters");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            //Create RemoveViewTemplates button
            CreatePushButton(ribbonPanel2, String.Format("Removes" + Environment.NewLine + "View Templates"), thisAssemblyPath, "EssentialTools.CommandRemoveTemplates",
                "Remove used or unused View Templates in bulk.", "EssentialTools/RemoveTemplatesPlaceholder.png");
            //Create RemoveFilters button
            CreatePushButton(ribbonPanel3, String.Format("Removes" + Environment.NewLine + "Filters"), thisAssemblyPath, "EssentialTools.CommandRemoveFilters",
                "Remove used or unused Filters in bulk.", "EssentialTools/RemoveFiltersPlaceholder.png");

            //Create push buttons for split drop down
            PushButtonData bOne = new PushButtonData(
                "cmdCurveTotalLength",
                "Curve Length",
                thisAssemblyPath,
                "TotalLength.CurveTotalLength");
            bOne.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/CurveTotalLength.png"));

            PushButtonData bTwo = new PushButtonData(
                "cmdWallTotalLength",
                "Wall Length",
                thisAssemblyPath,
                "TotalLength.WallTotalLength");
            bTwo.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/WallTotalLength.png"));

            PushButtonData bThree = new PushButtonData(
                "cmdFramingTotalLength",
                "Beam Length",
                thisAssemblyPath,
                "TotalLength.FramingTotalLength");
            bThree.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/FramingTotalLength.png"));

            PushButtonData bFour = new PushButtonData(
                "cmdPipingTotalLength",
                "Pipe Length",
                thisAssemblyPath,
                 "TotalLength.PipingTotalLength");
            bFour.LargeImage = new BitmapImage(new Uri(@"pack://application:,,,/DesignTechRibbon;component/Resources/PipingTotalLength.png"));

            SplitButtonData sb1 = new SplitButtonData("splitButton1", "Split");
            SplitButton sb = ribbonPanel1.AddItem(sb1) as SplitButton;
            sb.AddPushButton(bOne);
            sb.AddPushButton(bTwo);
            sb.AddPushButton(bThree);
            sb.AddPushButton(bFour);
            
             
             */




        }

        static void CreateThePushButton(UIControlledApplication a, string tabname)
        {
            // Add a new ribbon panel

            Autodesk.Revit.UI.RibbonPanel newPanel = a.CreateRibbonPanel(tabname, "NewRibbonPanel");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdHelloWorld",
               "Hello World", thisAssemblyPath, "Test.testclass"); //Make sure this class exists

            PushButton pushButton = newPanel.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Say hello to the entire world.";

          
            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/PipingTotalLength.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;







        }


        //Manage Tab Buttons
        static void CreateRemoveViewTemplatesButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {
            // Add a new ribbon panel

           // Autodesk.Revit.UI.RibbonPanel newPanel = a.CreateRibbonPanel(tabname,"Manage");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdTemplates",
               "View\nTemplates", thisAssemblyPath, "EssentialTools.CommandRemoveTemplates"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;


            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/RemoveTemplatesPlaceholder.png"));
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
               "Filters", thisAssemblyPath, "EssentialTools.CommandRemoveFilters"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/EssentialTools/RemoveFiltersPlaceholder.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }

        static void CreatePinUnpinButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {
           // Autodesk.Revit.UI.RibbonPanel newPanel = a.CreateRibbonPanel(tabname, "Manage");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdPin/UnpinFromList",
               "Pin/Unpin", thisAssemblyPath, "EssentialTools.PinAndUnpinList"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Pin/Unpin From List";

          
            SetRibbonItemToolTip(pushButton, PinUnpinToolTip);


            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/PinIcon.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage; 


        }


        //Excel Tab Buttons
        static void CreateExcelSheetButton(UIControlledApplication a, string tabname,Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdExcelSheet",
               "Import\nSheets", thisAssemblyPath, "EssentialTools.SheetsFromExcel"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
            pushButton.ToolTip = "Import Data From Excel";

            SetRibbonItemToolTip(pushButton, CreateExcelToolTip);

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/ExcelLogo.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage; 


        }


        //Tools Buttons
        static void CreateSplineRenumberButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdSpline",
               "Renumber\nElements", thisAssemblyPath, "EssentialTools.RenumberSpline"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            SetRibbonItemToolTip(pushButton, CreateSplineToolTip);

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/SplineIcon.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage;


        }

        static void CreateMatchFireRatingButton(UIControlledApplication a, string tabname, Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdFireDoorWall",
               "Match Fire\nRatings", thisAssemblyPath, "EssentialTools.MatchFireDoorWall"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;

            // Optionally, other properties may be assigned to the button
            // a) tool-tip
          
            SetRibbonItemToolTip(pushButton, MatchFireRatingToolTip);

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/DoorIcon.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage; 


        }

        static void CreateLegendPlacerButton(UIControlledApplication a, string tabname,Autodesk.Revit.UI.RibbonPanel rp)
        {

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonData = new PushButtonData("cmdHelloWorld",
               "Place\nLegends", thisAssemblyPath, "EssentialTools.LegendPlacer"); //Make sure this class exists

            PushButton pushButton = rp.AddItem(buttonData) as PushButton;


            SetRibbonItemToolTip(pushButton, CreateLegendToolTip);

            Uri uriImage = new Uri((@"pack://application:,,,/DesignTechRibbon;component/Resources/LegendIcon.png"));
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            pushButton.LargeImage = largeImage; 


        }




        #region ToolTips

        static RibbonToolTip PinUnpinToolTip = new RibbonToolTip()
        {
            Title = "Pin and Unpin Tool",
            ExpandedContent = @"Pin And Unpin Single Or Multiple Items In The Current Document",

            ExpandedVideo = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Autodesk/Revit/Addins/2018/designtech.bundle/PinUnpinT.mp4"),
       
        };

        static RibbonToolTip CreateExcelToolTip = new RibbonToolTip()
        {
            Title = "Excel Import Tool",
            ExpandedContent = @"Imports Data From An Excel Spreadsheet And Stores It In A List ",
            ExpandedVideo = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Autodesk/Revit/Addins/2018/designtech.bundle/ExcelSheetsT.mp4"),

        };

        static RibbonToolTip CreateSplineToolTip = new RibbonToolTip()
        {
            Title = "Spline Naming Tool",
            ExpandedContent = @"Renumbers In Order All The Elements In A Specific Category Based On A Selected Spline.",
            ExpandedVideo = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Autodesk/Revit/Addins/2018/designtech.bundle/SplineT.mp4"),

        };

        static RibbonToolTip MatchFireRatingToolTip = new RibbonToolTip()
        {
            Title = "Match Fire Rating Tool",
            ExpandedContent = @"Matches The Fire Rating Between Walls And Doors",
            ExpandedVideo = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Autodesk/Revit/Addins/2018/designtech.bundle/FireRatingT.mp4"),

        };

        static RibbonToolTip CreateLegendToolTip = new RibbonToolTip()
        {
            Title = "Create Legend Tool",
            ExpandedContent = @"Places the specified legend in the selected sheets, in the same location as the original.",
            ExpandedVideo = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Autodesk/Revit/Addins/2018/designtech.bundle/LegendsPlacementT.mp4"),

        };


        #endregion

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


