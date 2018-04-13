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
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.checkBoxCurtainWalls = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SelectLevelBox = new System.Windows.Forms.ComboBox();
            this.SelectElementBox = new System.Windows.Forms.ComboBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SplineCancelButton = new System.Windows.Forms.Button();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.labelSufix = new System.Windows.Forms.Label();
            this.LabelPrefix = new System.Windows.Forms.Label();
            this.SuffixString = new System.Windows.Forms.TextBox();
            this.PrefixString = new System.Windows.Forms.TextBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker6 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.groupBoxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 210);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(313, 46);
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
            this.groupBoxMain.Controls.Add(this.checkBoxCurtainWalls);
            this.groupBoxMain.Controls.Add(this.StartButton);
            this.groupBoxMain.Controls.Add(this.SelectLevelBox);
            this.groupBoxMain.Controls.Add(this.SelectElementBox);
            this.groupBoxMain.Controls.Add(this.StatusLabel);
            this.groupBoxMain.Controls.Add(this.SplineCancelButton);
            this.groupBoxMain.Controls.Add(this.designtechLogo);
            this.groupBoxMain.Controls.Add(this.CloseButton);
            this.groupBoxMain.Controls.Add(this.groupBoxInput);
            this.groupBoxMain.Controls.Add(this.progressBar1);
            this.groupBoxMain.Location = new System.Drawing.Point(6, 3);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(532, 363);
            this.groupBoxMain.TabIndex = 3;
            this.groupBoxMain.TabStop = false;
            // 
            // checkBoxCurtainWalls
            // 
            this.checkBoxCurtainWalls.AutoSize = true;
            this.checkBoxCurtainWalls.Location = new System.Drawing.Point(338, 120);
            this.checkBoxCurtainWalls.Name = "checkBoxCurtainWalls";
            this.checkBoxCurtainWalls.Size = new System.Drawing.Size(162, 21);
            this.checkBoxCurtainWalls.TabIndex = 16;
            this.checkBoxCurtainWalls.Text = "Include Curtain Walls";
            this.checkBoxCurtainWalls.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(338, 21);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(177, 46);
            this.StartButton.TabIndex = 9;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // SelectLevelBox
            // 
            this.SelectLevelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectLevelBox.FormattingEnabled = true;
            this.SelectLevelBox.Location = new System.Drawing.Point(177, 33);
            this.SelectLevelBox.Name = "SelectLevelBox";
            this.SelectLevelBox.Size = new System.Drawing.Size(143, 24);
            this.SelectLevelBox.TabIndex = 15;
            // 
            // SelectElementBox
            // 
            this.SelectElementBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectElementBox.FormattingEnabled = true;
            this.SelectElementBox.Location = new System.Drawing.Point(8, 33);
            this.SelectElementBox.Name = "SelectElementBox";
            this.SelectElementBox.Size = new System.Drawing.Size(143, 24);
            this.SelectElementBox.TabIndex = 14;
            this.SelectElementBox.SelectedIndexChanged += new System.EventHandler(this.SelectElementBox_SelectedIndexChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(379, 270);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(83, 17);
            this.StatusLabel.TabIndex = 13;
            this.StatusLabel.Text = "Please Wait";
            // 
            // SplineCancelButton
            // 
            this.SplineCancelButton.Location = new System.Drawing.Point(338, 210);
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
            this.designtechLogo.Location = new System.Drawing.Point(7, 283);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(312, 73);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 11;
            this.designtechLogo.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(338, 310);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(177, 46);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.labelSufix);
            this.groupBoxInput.Controls.Add(this.LabelPrefix);
            this.groupBoxInput.Controls.Add(this.SuffixString);
            this.groupBoxInput.Controls.Add(this.PrefixString);
            this.groupBoxInput.Location = new System.Drawing.Point(8, 81);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(301, 113);
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
            this.SuffixString.Size = new System.Drawing.Size(211, 22);
            this.SuffixString.TabIndex = 5;
            // 
            // PrefixString
            // 
            this.PrefixString.Location = new System.Drawing.Point(76, 37);
            this.PrefixString.Name = "PrefixString";
            this.PrefixString.Size = new System.Drawing.Size(209, 22);
            this.PrefixString.TabIndex = 4;
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
            // RenumberSplineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 378);
            this.Controls.Add(this.groupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RenumberSplineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renumber Elements";
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.TextBox SuffixString;
        private System.Windows.Forms.TextBox PrefixString;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Label labelSufix;
        private System.Windows.Forms.Label LabelPrefix;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
        private System.ComponentModel.BackgroundWorker backgroundWorker6;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.Button SplineCancelButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ComboBox SelectLevelBox;
        private System.Windows.Forms.ComboBox SelectElementBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.CheckBox checkBoxCurtainWalls;
    }
}