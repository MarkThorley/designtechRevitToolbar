﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesignTechRibbon.Revit.EssentialTools.RenumberSpline
{


    public partial class SelectionForm : System.Windows.Forms.Form
    {
        UIDocument localDoc;

      //  ICollection<ElementId> selectedIds = new List<ElementId>();
     //   public List<Element> filteredDetailGroups = new List<Element>();

        private Element SelectedElement;

        Reference selectedRef;

        static IExternalEventHandler handler_event = new ExternalEventMy();

        ExternalEvent exEvent = ExternalEvent.Create(handler_event);

        public SelectionForm(UIDocument doc)
        {

            InitializeComponent();
            localDoc = doc;

        }

        private void SelectionButton_Click(object sender, EventArgs e)
        {

            this.Hide();

            try
            {
                selectedRef = localDoc.Selection.PickObject(ObjectType.Element);

                Element S = localDoc.Document.GetElement(selectedRef);


                if (S.Category.Name.ToString() == "Lines")
                {
                    LabelSelected.Text = "User Selected: " + S.Name;
                    SelectedElement = localDoc.Document.GetElement(S.Id);
                }
                else
                {
                    MessageBox.Show("Selected Item Is Not A Line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                this.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

  

            /*
            selectedIds.Clear();

            selectedIds = localDoc.Selection.GetElementIds();
         
            if (0 == selectedIds.Count)
            {
                // If no elements selected.
                MessageBox.Show("You haven't selected any elements.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Show();

            }
            else if (selectedIds.Count > 1)
            {

                // If no elements selected.
                MessageBox.Show("Please Select Only One Element (Type: Lines)","Error",MessageBoxButtons.OK ,MessageBoxIcon.Stop);

                this.Show();

            }
            else
            {

                foreach (var item in selectedIds)
                {

                    Element S = localDoc.Document.GetElement(item);

                    if (S.Category.Name.ToString() == "Lines")
                    {
                        LabelSelected.Text = "User Selected: " + S.Name;
                        SelectedElement = localDoc.Document.GetElement(item);
                    }
                    else
                    {
                        MessageBox.Show("Please Only Select Line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                this.Show();
            }*/

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {

            if (SelectedElement != null)
            {

                var confirmResult = MessageBox.Show("Load This Item", "Confirm", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {

                    exEvent.Raise();

                }

            }
            else
            {
                MessageBox.Show("No Model Line Selected","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

        }


        private void CloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public Element MyProperty //Stores the value so other forms can find and use it
        {
            get
            {
                return this.SelectedElement;
            }
        }

    }

    class ExternalEventMy : IExternalEventHandler
    {
        public void Execute(UIApplication uiapp) //External Event Is used to get around the transaction limit
        {

            //MessageBox.Show("External Event is running");

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;
 
            RenumberSplineForm form = new RenumberSplineForm(uidoc);

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;

            form.ShowDialog();


        }
        public string GetName()
        {
            return "my event";
        }
    }
}
