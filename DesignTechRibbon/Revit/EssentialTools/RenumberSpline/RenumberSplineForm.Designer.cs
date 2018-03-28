namespace DesignTechRibbon.Revit.EssentialTools.RenumberSpline
{
    partial class RenumberSplineForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenumberSplineForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SplineDoorByCurrentLevel = new System.Windows.Forms.Button();
            this.SplineDoorByAllLevels = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.SplineCancelButton = new System.Windows.Forms.Button();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBoxRooms = new System.Windows.Forms.GroupBox();
            this.SplineRoomsByAllLevels = new System.Windows.Forms.Button();
            this.SplineRoomByCurrentLevel = new System.Windows.Forms.Button();
            this.groupBoxWindows = new System.Windows.Forms.GroupBox();
            this.SplineWindowByAllLevels = new System.Windows.Forms.Button();
            this.SplineWindowByCurrentLevel = new System.Windows.Forms.Button();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.labelSufix = new System.Windows.Forms.Label();
            this.LabelPrefix = new System.Windows.Forms.Label();
            this.SuffixString = new System.Windows.Forms.TextBox();
            this.PrefixString = new System.Windows.Forms.TextBox();
            this.groupBoxDoors = new System.Windows.Forms.GroupBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker6 = new System.ComponentModel.BackgroundWorker();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.groupBoxRooms.SuspendLayout();
            this.groupBoxWindows.SuspendLayout();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxDoors.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(452, 46);
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // SplineDoorByCurrentLevel
            // 
            this.SplineDoorByCurrentLevel.Location = new System.Drawing.Point(20, 38);
            this.SplineDoorByCurrentLevel.Name = "SplineDoorByCurrentLevel";
            this.SplineDoorByCurrentLevel.Size = new System.Drawing.Size(177, 46);
            this.SplineDoorByCurrentLevel.TabIndex = 1;
            this.SplineDoorByCurrentLevel.Text = "By Level";
            this.SplineDoorByCurrentLevel.UseVisualStyleBackColor = true;
            this.SplineDoorByCurrentLevel.Click += new System.EventHandler(this.SplineDoorByCurrentLevel_Click);
            // 
            // SplineDoorByAllLevels
            // 
            this.SplineDoorByAllLevels.Location = new System.Drawing.Point(20, 100);
            this.SplineDoorByAllLevels.Name = "SplineDoorByAllLevels";
            this.SplineDoorByAllLevels.Size = new System.Drawing.Size(177, 46);
            this.SplineDoorByAllLevels.TabIndex = 2;
            this.SplineDoorByAllLevels.Text = "All Levels";
            this.SplineDoorByAllLevels.UseVisualStyleBackColor = true;
            this.SplineDoorByAllLevels.Click += new System.EventHandler(this.SplineDoorByAllLevels_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.StatusLabel);
            this.groupBoxMain.Controls.Add(this.SplineCancelButton);
            this.groupBoxMain.Controls.Add(this.designtechLogo);
            this.groupBoxMain.Controls.Add(this.CloseButton);
            this.groupBoxMain.Controls.Add(this.groupBoxRooms);
            this.groupBoxMain.Controls.Add(this.groupBoxWindows);
            this.groupBoxMain.Controls.Add(this.groupBoxInput);
            this.groupBoxMain.Controls.Add(this.groupBoxDoors);
            this.groupBoxMain.Controls.Add(this.progressBar1);
            this.groupBoxMain.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(655, 476);
            this.groupBoxMain.TabIndex = 3;
            this.groupBoxMain.TabStop = false;
            // 
            // SplineCancelButton
            // 
            this.SplineCancelButton.Location = new System.Drawing.Point(465, 21);
            this.SplineCancelButton.Name = "SplineCancelButton";
            this.SplineCancelButton.Size = new System.Drawing.Size(177, 46);
            this.SplineCancelButton.TabIndex = 12;
            this.SplineCancelButton.Text = "Cancel";
            this.SplineCancelButton.UseVisualStyleBackColor = true;
            this.SplineCancelButton.Click += new System.EventHandler(this.SplineCancelButton_Click);
            // 
            // designtechLogo
            // 
            this.designtechLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.designtechLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.designtechLogo.Image = ((System.Drawing.Image)(resources.GetObject("designtechLogo.Image")));
            this.designtechLogo.Location = new System.Drawing.Point(7, 396);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(312, 73);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 11;
            this.designtechLogo.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(465, 420);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(177, 46);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBoxRooms
            // 
            this.groupBoxRooms.Controls.Add(this.SplineRoomsByAllLevels);
            this.groupBoxRooms.Controls.Add(this.SplineRoomByCurrentLevel);
            this.groupBoxRooms.Location = new System.Drawing.Point(7, 96);
            this.groupBoxRooms.Name = "groupBoxRooms";
            this.groupBoxRooms.Size = new System.Drawing.Size(200, 172);
            this.groupBoxRooms.TabIndex = 8;
            this.groupBoxRooms.TabStop = false;
            this.groupBoxRooms.Text = "Rooms";
            // 
            // SplineRoomsByAllLevels
            // 
            this.SplineRoomsByAllLevels.Location = new System.Drawing.Point(17, 100);
            this.SplineRoomsByAllLevels.Name = "SplineRoomsByAllLevels";
            this.SplineRoomsByAllLevels.Size = new System.Drawing.Size(177, 46);
            this.SplineRoomsByAllLevels.TabIndex = 9;
            this.SplineRoomsByAllLevels.Text = "All Levels";
            this.SplineRoomsByAllLevels.UseVisualStyleBackColor = true;
            this.SplineRoomsByAllLevels.Click += new System.EventHandler(this.SplineRoomsByAllLevels_Click);
            // 
            // SplineRoomByCurrentLevel
            // 
            this.SplineRoomByCurrentLevel.Location = new System.Drawing.Point(17, 38);
            this.SplineRoomByCurrentLevel.Name = "SplineRoomByCurrentLevel";
            this.SplineRoomByCurrentLevel.Size = new System.Drawing.Size(177, 46);
            this.SplineRoomByCurrentLevel.TabIndex = 9;
            this.SplineRoomByCurrentLevel.Text = "Current Level";
            this.SplineRoomByCurrentLevel.UseVisualStyleBackColor = true;
            this.SplineRoomByCurrentLevel.Click += new System.EventHandler(this.SplineRoomByCurrentLevel_Click);
            // 
            // groupBoxWindows
            // 
            this.groupBoxWindows.Controls.Add(this.SplineWindowByAllLevels);
            this.groupBoxWindows.Controls.Add(this.SplineWindowByCurrentLevel);
            this.groupBoxWindows.Location = new System.Drawing.Point(442, 96);
            this.groupBoxWindows.Name = "groupBoxWindows";
            this.groupBoxWindows.Size = new System.Drawing.Size(200, 172);
            this.groupBoxWindows.TabIndex = 7;
            this.groupBoxWindows.TabStop = false;
            this.groupBoxWindows.Text = "Windows";
            // 
            // SplineWindowByAllLevels
            // 
            this.SplineWindowByAllLevels.Location = new System.Drawing.Point(11, 100);
            this.SplineWindowByAllLevels.Name = "SplineWindowByAllLevels";
            this.SplineWindowByAllLevels.Size = new System.Drawing.Size(177, 46);
            this.SplineWindowByAllLevels.TabIndex = 8;
            this.SplineWindowByAllLevels.Text = "All Levels";
            this.SplineWindowByAllLevels.UseVisualStyleBackColor = true;
            this.SplineWindowByAllLevels.Click += new System.EventHandler(this.SplineWindowByAllLevels_Click);
            // 
            // SplineWindowByCurrentLevel
            // 
            this.SplineWindowByCurrentLevel.Location = new System.Drawing.Point(11, 38);
            this.SplineWindowByCurrentLevel.Name = "SplineWindowByCurrentLevel";
            this.SplineWindowByCurrentLevel.Size = new System.Drawing.Size(177, 46);
            this.SplineWindowByCurrentLevel.TabIndex = 8;
            this.SplineWindowByCurrentLevel.Text = "By Level";
            this.SplineWindowByCurrentLevel.UseVisualStyleBackColor = true;
            this.SplineWindowByCurrentLevel.Click += new System.EventHandler(this.SplineWindowByCurrentLevel_Click);
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.labelSufix);
            this.groupBoxInput.Controls.Add(this.LabelPrefix);
            this.groupBoxInput.Controls.Add(this.SuffixString);
            this.groupBoxInput.Controls.Add(this.PrefixString);
            this.groupBoxInput.Location = new System.Drawing.Point(7, 267);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(417, 113);
            this.groupBoxInput.TabIndex = 6;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // labelSufix
            // 
            this.labelSufix.AutoSize = true;
            this.labelSufix.Location = new System.Drawing.Point(30, 73);
            this.labelSufix.Name = "labelSufix";
            this.labelSufix.Size = new System.Drawing.Size(38, 17);
            this.labelSufix.TabIndex = 7;
            this.labelSufix.Text = "Sufix";
            // 
            // LabelPrefix
            // 
            this.LabelPrefix.AutoSize = true;
            this.LabelPrefix.Location = new System.Drawing.Point(27, 37);
            this.LabelPrefix.Name = "LabelPrefix";
            this.LabelPrefix.Size = new System.Drawing.Size(43, 17);
            this.LabelPrefix.TabIndex = 6;
            this.LabelPrefix.Text = "Prefix";
            // 
            // SuffixString
            // 
            this.SuffixString.Location = new System.Drawing.Point(74, 73);
            this.SuffixString.Name = "SuffixString";
            this.SuffixString.Size = new System.Drawing.Size(322, 22);
            this.SuffixString.TabIndex = 5;
            // 
            // PrefixString
            // 
            this.PrefixString.Location = new System.Drawing.Point(74, 37);
            this.PrefixString.Name = "PrefixString";
            this.PrefixString.Size = new System.Drawing.Size(322, 22);
            this.PrefixString.TabIndex = 4;
            // 
            // groupBoxDoors
            // 
            this.groupBoxDoors.Controls.Add(this.SplineDoorByCurrentLevel);
            this.groupBoxDoors.Controls.Add(this.SplineDoorByAllLevels);
            this.groupBoxDoors.Location = new System.Drawing.Point(218, 96);
            this.groupBoxDoors.Name = "groupBoxDoors";
            this.groupBoxDoors.Size = new System.Drawing.Size(218, 172);
            this.groupBoxDoors.TabIndex = 3;
            this.groupBoxDoors.TabStop = false;
            this.groupBoxDoors.Text = "Doors";
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.WorkerReportsProgress = true;
            this.backgroundWorker4.WorkerSupportsCancellation = true;
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.backgroundWorker4.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker4_ProgressChanged);
            this.backgroundWorker4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted);
            // 
            // backgroundWorker5
            // 
            this.backgroundWorker5.WorkerReportsProgress = true;
            this.backgroundWorker5.WorkerSupportsCancellation = true;
            this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker5_DoWork);
            this.backgroundWorker5.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker5_ProgressChanged);
            this.backgroundWorker5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker5_RunWorkerCompleted);
            // 
            // backgroundWorker6
            // 
            this.backgroundWorker6.WorkerReportsProgress = true;
            this.backgroundWorker6.WorkerSupportsCancellation = true;
            this.backgroundWorker6.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker6_DoWork);
            this.backgroundWorker6.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker6_ProgressChanged);
            this.backgroundWorker6.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker6_RunWorkerCompleted);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(507, 76);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(83, 17);
            this.StatusLabel.TabIndex = 13;
            this.StatusLabel.Text = "Please Wait";
            // 
            // RenumberSplineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 497);
            this.Controls.Add(this.groupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenumberSplineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renumber Spline";
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.groupBoxRooms.ResumeLayout(false);
            this.groupBoxWindows.ResumeLayout(false);
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxDoors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button SplineDoorByCurrentLevel;
        private System.Windows.Forms.Button SplineDoorByAllLevels;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.GroupBox groupBoxDoors;
        private System.Windows.Forms.TextBox SuffixString;
        private System.Windows.Forms.TextBox PrefixString;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Label labelSufix;
        private System.Windows.Forms.Label LabelPrefix;
        private System.Windows.Forms.GroupBox groupBoxWindows;
        private System.Windows.Forms.Button SplineWindowByAllLevels;
        private System.Windows.Forms.Button SplineWindowByCurrentLevel;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.GroupBox groupBoxRooms;
        private System.Windows.Forms.Button SplineRoomByCurrentLevel;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
        private System.ComponentModel.BackgroundWorker backgroundWorker6;
        private System.Windows.Forms.Button SplineRoomsByAllLevels;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.Button SplineCancelButton;
        private System.Windows.Forms.Label StatusLabel;
    }
}