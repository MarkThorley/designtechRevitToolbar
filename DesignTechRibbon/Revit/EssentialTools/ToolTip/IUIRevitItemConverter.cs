using System;
using System.Reflection;
using Autodesk.Windows;
using UIFramework;
using RibbonItem = Autodesk.Revit.UI.RibbonItem;

//http://thebuildingcoder.typepad.com/blog/2012/09/video-animated-ribbon-item-tooltip.html

namespace VCButtonsWithVideoToolTip
{
  interface IUIRevitItemConverter
  {
    Autodesk.Windows.RibbonItem GetRibbonItem( 
      RibbonItem item );
  }

  class InternalMethodUIRevitItemConverter : IUIRevitItemConverter
  {
    public Autodesk.Windows.RibbonItem GetRibbonItem( 
      RibbonItem item )
    {
      Type itemType = item.GetType();

      var mi = itemType.GetMethod( "getRibbonItem", 
        BindingFlags.NonPublic | BindingFlags.Instance );

      var windowRibbonItem = mi.Invoke( item, null );

      return windowRibbonItem 
        as Autodesk.Windows.RibbonItem;
    }
  }

  class SearchItemUIRevitItemConverter : IUIRevitItemConverter
  {
    public Autodesk.Windows.RibbonItem GetRibbonItem( 
      RibbonItem item )
    {
      RibbonControl ribbonControl 
        = RevitRibbonControl.RibbonControl;

      foreach( var tab in ribbonControl.Tabs )
      {
        foreach( var panel in tab.Panels )
        {
          foreach( var ribbonItem 
            in panel.Source.Items )
          {
            if( ribbonItem.AutomationName
              == item.Name )
            {
              return ribbonItem as
                Autodesk.Windows.RibbonItem;
            }
          }
        }
      }
      return null;
    }
  }
}
