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
            this.DoorToWall = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteFireRatingsWindow = new System.Windows.Forms.Button();
            this.DeleteFireRatingsDoors = new System.Windows.Forms.Button();
            this.SetFireRatingsGB = new System.Windows.Forms.GroupBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.comboBoxMapToParam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.parameterNameInput = new System.Windows.Forms.RichTextBox();
            this.comboBoxParameterList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SetFireRatingsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowToWall
            // 
            this.WindowToWall.Location = new System.Drawing.Point(21, 105);
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
            // DoorToWall
            // 
            this.DoorToWall.Location = new System.Drawing.Point(21, 41);
            this.DoorToWall.Name = "DoorToWall";
            this.DoorToWall.Size = new System.Drawing.Size(194, 42);
            this.DoorToWall.TabIndex = 3;
            this.DoorToWall.Text = "Wall To Door";
            this.DoorToWall.UseVisualStyleBackColor = true;
            this.DoorToWall.Click += new System.EventHandler(this.WallToDoor_Click);
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
            this.groupBox1.Controls.Add(this.comboBoxParameterList);
            this.groupBox1.Controls.Add(this.parameterNameInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxMapToParam);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.SetFireRatingsGB);
            this.groupBox1.Controls.Add(this.StatusLabel);
            this.groupBox1.Controls.Add(this.designtechLogo);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 514);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteFireRatingsWindow);
            this.groupBox2.Controls.Add(this.DeleteFireRatingsDoors);
            this.groupBox2.Location = new System.Drawing.Point(280, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 176);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete Fire Rating Parameters";
            // 
            // DeleteFireRatingsWindow
            // 
            this.DeleteFireRatingsWindow.Location = new System.Drawing.Point(20, 96);
            this.DeleteFireRatingsWindow.Name = "DeleteFireRatingsWindow";
            this.DeleteFireRatingsWindow.Size = new System.Drawing.Size(194, 42);
            this.DeleteFireRatingsWindow.TabIndex = 10;
            this.DeleteFireRatingsWindow.Text = "By Window";
            this.DeleteFireRatingsWindow.UseVisualStyleBackColor = true;
            this.DeleteFireRatingsWindow.Click += new System.EventHandler(this.DeleteFireRatingsWindow_Click);
            // 
            // DeleteFireRatingsDoors
            // 
            this.DeleteFireRatingsDoors.Location = new System.Drawing.Point(20, 32);
            this.DeleteFireRatingsDoors.Name = "DeleteFireRatingsDoors";
            this.DeleteFireRatingsDoors.Size = new System.Drawing.Size(194, 42);
            this.DeleteFireRatingsDoors.TabIndex = 9;
            this.DeleteFireRatingsDoors.Text = "By Door";
            this.DeleteFireRatingsDoors.UseVisualStyleBackColor = true;
            this.DeleteFireRatingsDoors.Click += new System.EventHandler(this.DeleteFireRatings_Click);
            // 
            // SetFireRatingsGB
            // 
            this.SetFireRatingsGB.Controls.Add(this.DoorToWall);
            this.SetFireRatingsGB.Controls.Add(this.WindowToWall);
            this.SetFireRatingsGB.Location = new System.Drawing.Point(21, 21);
            this.SetFireRatingsGB.Name = "SetFireRatingsGB";
            this.SetFireRatingsGB.Size = new System.Drawing.Size(253, 185);
            this.SetFireRatingsGB.TabIndex = 10;
            this.SetFireRatingsGB.TabStop = false;
            this.SetFireRatingsGB.Text = "Set Fire Rating Parameters";
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
            // comboBoxMapToParam
            // 
            this.comboBoxMapToParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMapToParam.FormattingEnabled = true;
            this.comboBoxMapToParam.Location = new System.Drawing.Point(27, 222);
            this.comboBoxMapToParam.Name = "comboBoxMapToParam";
            this.comboBoxMapToParam.Size = new System.Drawing.Size(247, 24);
            this.comboBoxMapToParam.TabIndex = 12;
            this.comboBoxMapToParam.SelectedIndexChanged += new System.EventHandler(this.comboBoxMapToParam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Paramter Name:";
            // 
            // parameterNameInput
            // 
            this.parameterNameInput.Location = new System.Drawing.Point(141, 301);
            this.parameterNameInput.Name = "parameterNameInput";
            this.parameterNameInput.Size = new System.Drawing.Size(257, 26);
            this.parameterNameInput.TabIndex = 14;
            this.parameterNameInput.Text = "";
            this.parameterNameInput.TextChanged += new System.EventHandler(this.parameterNameInput_TextChanged);
            // 
            // comboBoxParameterList
            // 
            this.comboBoxParameterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParameterList.FormattingEnabled = true;
            this.comboBoxParameterList.Location = new System.Drawing.Point(141, 271);
            this.comboBoxParameterList.Name = "comboBoxParameterList";
            this.comboBoxParameterList.Size = new System.Drawing.Size(257, 24);
            this.comboBoxParameterList.TabIndex = 15;
            this.comboBoxParameterList.SelectedIndexChanged += new System.EventHandler(this.comboBoxParameterList_SelectedIndexChanged);
            // 
            // MatchFireDoorWallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 538);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatchFireDoorWallForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match Fire Rating";
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.SetFireRatingsGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button WindowToWall;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button DoorToWall;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button DeleteFireRatingsDoors;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteFireRatingsWindow;
        private System.Windows.Forms.GroupBox SetFireRatingsGB;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.ComboBox comboBoxMapToParam;
        private System.Windows.Forms.RichTextBox parameterNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxParameterList;
    }
}