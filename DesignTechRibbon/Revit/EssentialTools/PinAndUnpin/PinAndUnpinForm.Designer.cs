namespace DesignTechRibbon.Revit.EssentialTools.PinAndUnpinForm
{
    partial class PinAndUnpinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PinAndUnpinForm));
            this.PinUnpinButton = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.GroupBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Action = new System.Windows.Forms.GroupBox();
            this.UnpinAll = new System.Windows.Forms.Button();
            this.PinAll = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.elementList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSelection = new System.Windows.Forms.GroupBox();
            this.radioFull = new System.Windows.Forms.RadioButton();
            this.buttonNone = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.radioLink = new System.Windows.Forms.RadioButton();
            this.radioGrid = new System.Windows.Forms.RadioButton();
            this.radioLevel = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.Action.SuspendLayout();
            this.groupBoxSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // PinUnpinButton
            // 
            this.PinUnpinButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PinUnpinButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PinUnpinButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.PinUnpinButton.Location = new System.Drawing.Point(6, 26);
            this.PinUnpinButton.Margin = new System.Windows.Forms.Padding(4);
            this.PinUnpinButton.Name = "PinUnpinButton";
            this.PinUnpinButton.Size = new System.Drawing.Size(193, 41);
            this.PinUnpinButton.TabIndex = 1;
            this.PinUnpinButton.Text = "Pin/Unpin Selection";
            this.PinUnpinButton.UseVisualStyleBackColor = false;
            this.PinUnpinButton.Click += new System.EventHandler(this.PinUnpinBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cancelBtn.Location = new System.Drawing.Point(471, 485);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(193, 40);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Close";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // designtechLogo
            // 
            this.designtechLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.designtechLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.designtechLogo.Image = ((System.Drawing.Image)(resources.GetObject("designtechLogo.Image")));
            this.designtechLogo.Location = new System.Drawing.Point(0, 443);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(312, 73);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 4;
            this.designtechLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 544);
            this.panel1.TabIndex = 1;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.StatusLabel);
            this.mainPanel.Controls.Add(this.Action);
            this.mainPanel.Controls.Add(this.StopButton);
            this.mainPanel.Controls.Add(this.progressBar1);
            this.mainPanel.Controls.Add(this.cancelBtn);
            this.mainPanel.Controls.Add(this.elementList);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.designtechLogo);
            this.mainPanel.Controls.Add(this.groupBoxSelection);
            this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(10, -2);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(4);
            this.mainPanel.Size = new System.Drawing.Size(685, 533);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.TabStop = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.StatusLabel.Location = new System.Drawing.Point(350, 465);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(78, 19);
            this.StatusLabel.TabIndex = 18;
            this.StatusLabel.Text = "Please Wait";
            // 
            // Action
            // 
            this.Action.Controls.Add(this.UnpinAll);
            this.Action.Controls.Add(this.PinUnpinButton);
            this.Action.Controls.Add(this.PinAll);
            this.Action.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Action.Location = new System.Drawing.Point(466, 273);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(210, 184);
            this.Action.TabIndex = 17;
            this.Action.TabStop = false;
            this.Action.Text = "Action";
            // 
            // UnpinAll
            // 
            this.UnpinAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.UnpinAll.Location = new System.Drawing.Point(6, 123);
            this.UnpinAll.Name = "UnpinAll";
            this.UnpinAll.Size = new System.Drawing.Size(194, 41);
            this.UnpinAll.TabIndex = 18;
            this.UnpinAll.Text = "Unpin All";
            this.UnpinAll.UseVisualStyleBackColor = true;
            this.UnpinAll.Click += new System.EventHandler(this.UnpinAll_Click);
            // 
            // PinAll
            // 
            this.PinAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.PinAll.Location = new System.Drawing.Point(6, 74);
            this.PinAll.Name = "PinAll";
            this.PinAll.Size = new System.Drawing.Size(194, 41);
            this.PinAll.TabIndex = 17;
            this.PinAll.Text = "Pin All";
            this.PinAll.UseVisualStyleBackColor = true;
            this.PinAll.Click += new System.EventHandler(this.PinAll_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.StopButton.Location = new System.Drawing.Point(335, 426);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(109, 36);
            this.StopButton.TabIndex = 16;
            this.StopButton.Text = "Cancel";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 33);
            this.progressBar1.TabIndex = 15;
            // 
            // elementList
            // 
            this.elementList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.elementList.FormattingEnabled = true;
            this.elementList.ItemHeight = 19;
            this.elementList.Location = new System.Drawing.Point(0, 54);
            this.elementList.Name = "elementList";
            this.elementList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.elementList.Size = new System.Drawing.Size(441, 327);
            this.elementList.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Type                      Name                       Pinned";
            // 
            // groupBoxSelection
            // 
            this.groupBoxSelection.Controls.Add(this.radioFull);
            this.groupBoxSelection.Controls.Add(this.buttonNone);
            this.groupBoxSelection.Controls.Add(this.buttonAll);
            this.groupBoxSelection.Controls.Add(this.radioLink);
            this.groupBoxSelection.Controls.Add(this.radioGrid);
            this.groupBoxSelection.Controls.Add(this.radioLevel);
            this.groupBoxSelection.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSelection.Location = new System.Drawing.Point(461, 23);
            this.groupBoxSelection.Name = "groupBoxSelection";
            this.groupBoxSelection.Size = new System.Drawing.Size(210, 244);
            this.groupBoxSelection.TabIndex = 11;
            this.groupBoxSelection.TabStop = false;
            this.groupBoxSelection.Text = "Selection";
            // 
            // radioFull
            // 
            this.radioFull.AutoSize = true;
            this.radioFull.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFull.Location = new System.Drawing.Point(10, 25);
            this.radioFull.Name = "radioFull";
            this.radioFull.Size = new System.Drawing.Size(76, 23);
            this.radioFull.TabIndex = 14;
            this.radioFull.TabStop = true;
            this.radioFull.Text = "Full List";
            this.radioFull.UseVisualStyleBackColor = true;
            this.radioFull.CheckedChanged += new System.EventHandler(this.radioFull_CheckedChanged);
            // 
            // buttonNone
            // 
            this.buttonNone.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.buttonNone.Location = new System.Drawing.Point(10, 188);
            this.buttonNone.Name = "buttonNone";
            this.buttonNone.Size = new System.Drawing.Size(194, 42);
            this.buttonNone.TabIndex = 13;
            this.buttonNone.Text = "None";
            this.buttonNone.UseVisualStyleBackColor = true;
            this.buttonNone.Click += new System.EventHandler(this.buttonNone_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.buttonAll.Location = new System.Drawing.Point(10, 140);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(194, 42);
            this.buttonAll.TabIndex = 12;
            this.buttonAll.Text = "All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // radioLink
            // 
            this.radioLink.AutoSize = true;
            this.radioLink.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLink.Location = new System.Drawing.Point(10, 111);
            this.radioLink.Name = "radioLink";
            this.radioLink.Size = new System.Drawing.Size(61, 23);
            this.radioLink.TabIndex = 3;
            this.radioLink.TabStop = true;
            this.radioLink.Text = "Links";
            this.radioLink.UseVisualStyleBackColor = true;
            this.radioLink.CheckedChanged += new System.EventHandler(this.radioLink_CheckedChanged);
            // 
            // radioGrid
            // 
            this.radioGrid.AutoSize = true;
            this.radioGrid.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGrid.Location = new System.Drawing.Point(10, 82);
            this.radioGrid.Name = "radioGrid";
            this.radioGrid.Size = new System.Drawing.Size(62, 23);
            this.radioGrid.TabIndex = 2;
            this.radioGrid.TabStop = true;
            this.radioGrid.Text = "Grids";
            this.radioGrid.UseVisualStyleBackColor = true;
            this.radioGrid.CheckedChanged += new System.EventHandler(this.radioGrid_CheckedChanged);
            // 
            // radioLevel
            // 
            this.radioLevel.AutoSize = true;
            this.radioLevel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLevel.Location = new System.Drawing.Point(10, 53);
            this.radioLevel.Name = "radioLevel";
            this.radioLevel.Size = new System.Drawing.Size(67, 23);
            this.radioLevel.TabIndex = 1;
            this.radioLevel.TabStop = true;
            this.radioLevel.Text = "Levels";
            this.radioLevel.UseVisualStyleBackColor = true;
            this.radioLevel.CheckedChanged += new System.EventHandler(this.radioLevel_CheckedChanged);
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
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // PinAndUnpinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 544);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PinAndUnpinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pin/Unpin List";
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.Action.ResumeLayout(false);
            this.groupBoxSelection.ResumeLayout(false);
            this.groupBoxSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PinUnpinButton;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox mainPanel;
        private System.Windows.Forms.GroupBox groupBoxSelection;
        private System.Windows.Forms.RadioButton radioLevel;
        private System.Windows.Forms.RadioButton radioLink;
        private System.Windows.Forms.RadioButton radioGrid;
        private System.Windows.Forms.Button buttonNone;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.RadioButton radioFull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox elementList;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.GroupBox Action;
        private System.Windows.Forms.Button UnpinAll;
        private System.Windows.Forms.Button PinAll;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Label StatusLabel;
    }
}