using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace DT_Install_Free
{
    public partial class DT_Installer_Free : Form
    {
        public DT_Installer_Free()
        {

            InitializeComponent();


            VersionBox.Items.Add("2018");
          //  VersionBox.Items.Add("2017");
         //   VersionBox.Items.Add("2016");
          //  VersionBox.Items.Add("2015");
         //   VersionBox.Items.Add("2014");
         //   VersionBox.Items.Add("2005");

            VersionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            VersionBox.SelectedItem = "2018";

        }

        private static string sourcePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static string dirWin7 = Environment.GetEnvironmentVariable("UserProfile") + "\\AppData\\Roaming\\";

        private static string dirXP = Environment.GetEnvironmentVariable("UserProfile") + "\\Application Data\\";

        private static string dtFolder;
        private static string rootFolder;



        private void InstallButton_Click_1(object sender, EventArgs e)
        {

            dtFolder = dirWin7 + "Autodesk/Revit/Addins/" +   VersionBox.SelectedItem.ToString() + " /designtech.bundle";

            rootFolder = dirWin7 + "Autodesk/Revit/Addins/" + VersionBox.SelectedItem.ToString() + "/";

            if (System.IO.Directory.Exists(rootFolder)) // If the version Exists
            {

                // Test for Win7
                if (Directory.Exists(dirWin7))
                {
                    doCopy(dirWin7);
                    MessageBox.Show("The Toolbar Has Been Added to Revit", "Installation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                // Test for XP
                if (Directory.Exists(dirXP))
                {
                    doCopy(dirXP);
                    MessageBox.Show("The Toolbar Has Been Added to Revit", "Installation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }

            }
            else
            {
                MessageBox.Show("This Version Of Revit Does Not Exist On This PC", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }




        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

            dtFolder = dirWin7 + "Autodesk/Revit/Addins/" + VersionBox.SelectedItem.ToString() + " /designtech.bundle";

            rootFolder = dirWin7 + "Autodesk/Revit/Addins/" + VersionBox.SelectedItem.ToString() + "/";

            if (System.IO.Directory.Exists(rootFolder)) // If the version Exists
            {

                // Test for Win7
                if (Directory.Exists(dirWin7))
                {
                    DeleteFiles(dirWin7);
                    this.Close();

                }
                // Test for XP
                if (Directory.Exists(dirXP))
                {
                    DeleteFiles(dirWin7);
                    this.Close();

                }

            }
            else
            {
                MessageBox.Show("This Version Of Revit Does Not Exist On This PC", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

        }

        private static void doCopy(string destination)
        {

            DeleteFilesBeforeInstall(destination);

            // Get Files
            DirectoryInfo di = new DirectoryInfo(sourcePath); //This is the directory where the files extensions are searched for
            FileInfo[] fiAddin = di.GetFiles("DesignTechRibbon.addin");
            FileInfo[] fiDll = di.GetFiles("DesignTechRibbon.dll");
          //  FileInfo[] fiMP4 = di.GetFiles("*.mp4");


            if (!System.IO.Directory.Exists(dtFolder)) // If folder does not exist
            {
                try
                {
                    System.IO.Directory.CreateDirectory(dtFolder); //Create the folder
                }
                catch (Exception)
                {
                    // Quiet Fail

                }

            }

            foreach (FileInfo fiAddinNext in fiAddin)
            {
                try
                {
                                  
                   fiAddinNext.CopyTo(rootFolder + "\\" + fiAddinNext.Name, true);

                }
                catch (Exception)
                {
                    // Quiet Fail
            
                }
            }
            foreach (FileInfo fiDllNext in fiDll)
            {
                try
                {
                    fiDllNext.CopyTo(rootFolder + "\\" + fiDllNext.Name, true);
                   
                }
                catch (Exception)
                {
                    // Quiet Fail
             
                }
            }

         /*   foreach (FileInfo mp4 in fiMP4)
            {
                try
                {

                   mp4.CopyTo(dtFolder + "\\" + mp4.Name, true);

                }
                catch (Exception)
                {
                    // Quiet Fail
               
                }
            }*/


        }

        private static void DeleteFiles(string destination)
        {

            string deleted = "";
            bool dtAddin = false;
            bool dtDll = false;


            try
            {
                if (System.IO.Directory.Exists(dtFolder)) // Deletes the DT Folder
                {
                    System.IO.Directory.Delete(dtFolder, true);

                }

                if (System.IO.File.Exists(rootFolder + "/DesignTechRibbon.addin"))  // Deletes the DT Folder
                {

                    System.IO.File.Delete(rootFolder + "/DesignTechRibbon.addin");
                    deleted += "DesignTechRibbon.addin, ";
                    dtAddin = true;

                }
                if (System.IO.File.Exists(rootFolder + "/DesignTechRibbon.dll"))  // Deletes the DT Folder
                {

                    System.IO.File.Delete(rootFolder + "/DesignTechRibbon.dll");
                    deleted += "DesignTechRibbon.dll,";
                    dtDll = true;
                }

                if(dtAddin == true || dtDll == true)
                {
                    MessageBox.Show("The Files " + deleted + "have Been Deleted", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Files Not Found", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " Please ensure Revit is closed and try again ", "Error During Uninstall", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }


        private static void DeleteFilesBeforeInstall(string destination)
        {

            try
            {
                if (System.IO.Directory.Exists(dtFolder)) // Deletes the DT Folder
                {
                    System.IO.Directory.Delete(dtFolder, true);

                }

                if (System.IO.File.Exists(rootFolder + "/DesignTechRibbon.addin"))  
                {

                    System.IO.File.Delete(rootFolder + "/DesignTechRibbon.addin");

                }
                if (System.IO.File.Exists(rootFolder + "/DesignTechRibbon.dll"))  
                {

                    System.IO.File.Delete(rootFolder + "/DesignTechRibbon.dll");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please ensure Revit is closed and try again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

    }
}


