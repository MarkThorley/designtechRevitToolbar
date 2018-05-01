namespace DesignTechRibbon.Revit.EssentialTools.MatchFireDoorWall
{
    partial class MatchFireDoorWallForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchFireDoorWallForm));
            this.WindowToWall = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.WallToDoor = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxChooseWD = new System.Windows.Forms.ComboBox();
            this.gbWindows = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DeleteFireRatingsWindow = new System.Windows.Forms.Button();
            this.gbDoors = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteFireRatingsDoors = new System.Windows.Forms.Button();
            this.comboBoxParameterList = new System.Windows.Forms.ComboBox();
            this.parameterNameInput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMapToParam = new System.Windows.Forms.ComboBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbWindows.SuspendLayout();
            this.gbDoors.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowToWall
            // 
            this.WindowToWall.Location = new System.Drawing.Point(40, 66);
            this.WindowToWall.Name = "WindowToWall";
            this.WindowToWall.Size = new System.Drawing.Size(194, 42);
            this.WindowToWall.TabIndex = 1;
            this.WindowToWall.Text = "Wall To Window";
            this.WindowToWall.UseVisualStyleBackColor = true;
            this.WindowToWall.Click += new System.EventHandler(this.WindowToWall_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 363);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(312, 43);
            this.progressBar1.TabIndex = 2;
            // 
            // WallToDoor
            // 
            this.WallToDoor.Location = new System.Drawing.Point(40, 66);
            this.WallToDoor.Name = "WallToDoor";
            this.WallToDoor.Size = new System.Drawing.Size(194, 42);
            this.WallToDoor.TabIndex = 3;
            this.WallToDoor.Text = "Wall To Door";
            this.WallToDoor.UseVisualStyleBackColor = true;
            this.WallToDoor.Click += new System.EventHandler(this.WallToDoor_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // designtechLogo
            // 
            this.designtechLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.designtechLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.designtechLogo.Image = ((System.Drawing.Image)(resources.GetObject("designtechLogo.Image")));
            this.designtechLogo.Location = new System.Drawing.Point(11, 423);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(312, 73);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 5;
            this.designtechLogo.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(333, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(194, 42);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(333, 454);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(194, 42);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxChooseWD);
            this.groupBox1.Controls.Add(this.gbWindows);
            this.groupBox1.Controls.Add(this.gbDoors);
            this.groupBox1.Controls.Add(this.comboBoxParameterList);
            this.groupBox1.Controls.Add(this.parameterNameInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxMapToParam);
            this.groupBox1.Controls.Add(this.StatusLabel);
            this.groupBox1.Controls.Add(this.designtechLogo);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 514);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Action:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Doors/Windows";
            // 
            // comboBoxChooseWD
            // 
            this.comboBoxChooseWD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseWD.FormattingEnabled = true;
            this.comboBoxChooseWD.Location = new System.Drawing.Point(141, 196);
            this.comboBoxChooseWD.Name = "comboBoxChooseWD";
            this.comboBoxChooseWD.Size = new System.Drawing.Size(374, 24);
            this.comboBoxChooseWD.TabIndex = 18;
            this.comboBoxChooseWD.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseWD_SelectedIndexChanged);
            // 
            // gbWindows
            // 
            this.gbWindows.Controls.Add(this.label4);
            this.gbWindows.Controls.Add(this.label5);
            this.gbWindows.Controls.Add(this.DeleteFireRatingsWindow);
            this.gbWindows.Controls.Add(this.WindowToWall);
            this.gbWindows.Location = new System.Drawing.Point(15, 21);
            this.gbWindows.Name = "gbWindows";
            this.gbWindows.Size = new System.Drawing.Size(500, 151);
            this.gbWindows.TabIndex = 17;
            this.gbWindows.TabStop = false;
            this.gbWindows.Text = "Fire Rating Windows";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Delete Parameter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Set Fire Rating";
            // 
            // DeleteFireRatingsWindow
            // 
            this.DeleteFireRatingsWindow.Location = new System.Drawing.Point(268, 66);
            this.DeleteFireRatingsWindow.Name = "DeleteFireRatingsWindow";
            this.DeleteFireRatingsWindow.Size = new System.Drawing.Size(194, 42);
            this.DeleteFireRatingsWindow.TabIndex = 10;
            this.DeleteFireRatingsWindow.Text = "By Window";
            this.DeleteFireRatingsWindow.UseVisualStyleBackColor = true;
            this.DeleteFireRatingsWindow.Click += new System.EventHandler(this.DeleteFireRatingsWindow_Click);
            // 
            // gbDoors
            // 
            this.gbDoors.Controls.Add(this.label3);
            this.gbDoors.Controls.Add(this.label2);
            this.gbDoors.Controls.Add(this.WallToDoor);
            this.gbDoors.Controls.Add(this.DeleteFireRatingsDoors);
            this.gbDoors.Location = new System.Drawing.Point(15, 21);
            this.gbDoors.Name = "gbDoors";
            this.gbDoors.Size = new System.Drawing.Size(500, 151);
            this.gbDoors.TabIndex = 16;
            this.gbDoors.TabStop = false;
            this.gbDoors.Text = "Fire Ratings Doors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Delete Parameter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Set Fire Rating";
            // 
            // DeleteFireRatingsDoors
            // 
            this.DeleteFireRatingsDoors.Location = new System.Drawing.Point(268, 66);
            this.DeleteFireRatingsDoors.Name = "DeleteFireRatingsDoors";
            this.DeleteFireRatingsDoors.Size = new System.Drawing.Size(194, 42);
            this.DeleteFireRatingsDoors.TabIndex = 9;
            this.DeleteFireRatingsDoors.Text = "By Door";
            this.DeleteFireRatingsDoors.UseVisualStyleBackColor = true;
            this.DeleteFireRatingsDoors.Click += new System.EventHandler(this.DeleteFireRatings_Click);
            // 
            // comboBoxParameterList
            // 
            this.comboBoxParameterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParameterList.FormattingEnabled = true;
            this.comboBoxParameterList.Location = new System.Drawing.Point(141, 316);
            this.comboBoxParameterList.Name = "comboBoxParameterList";
            this.comboBoxParameterList.Size = new System.Drawing.Size(374, 24);
            this.comboBoxParameterList.TabIndex = 15;
            this.comboBoxParameterList.SelectedIndexChanged += new System.EventHandler(this.comboBoxParameterList_SelectedIndexChanged);
            // 
            // parameterNameInput
            // 
            this.parameterNameInput.Location = new System.Drawing.Point(141, 316);
            this.parameterNameInput.Name = "parameterNameInput";
            this.parameterNameInput.Size = new System.Drawing.Size(257, 26);
            this.parameterNameInput.TabIndex = 14;
            this.parameterNameInput.Text = "";
            this.parameterNameInput.TextChanged += new System.EventHandler(this.parameterNameInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Paramter Name:";
            // 
            // comboBoxMapToParam
            // 
            this.comboBoxMapToParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMapToParam.FormattingEnabled = true;
            this.comboBoxMapToParam.Location = new System.Drawing.Point(141, 253);
            this.comboBoxMapToParam.Name = "comboBoxMapToParam";
            this.comboBoxMapToParam.Size = new System.Drawing.Size(374, 24);
            this.comboBoxMapToParam.TabIndex = 12;
            this.comboBoxMapToParam.SelectedIndexChanged += new System.EventHandler(this.comboBoxMapToParam_SelectedIndexChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(380, 423);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(83, 17);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Please Wait";
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
            // MatchFireDoorWallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 538);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatchFireDoorWallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Fire Rating";
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbWindows.ResumeLayout(false);
            this.gbWindows.PerformLayout();
            this.gbDoors.ResumeLayout(false);
            this.gbDoors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button WindowToWall;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button WallToDoor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button DeleteFireRatingsDoors;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button DeleteFireRatingsWindow;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.ComboBox comboBoxMapToParam;
        private System.Windows.Forms.RichTextBox parameterNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxParameterList;
        private System.Windows.Forms.GroupBox gbWindows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbDoors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxChooseWD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}