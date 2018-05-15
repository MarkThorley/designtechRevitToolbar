namespace DesignTechRibbon.Revit.EssentialTools.SheetsFromExcelForm
{
    partial class SheetsFromExcelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetsFromExcelForm));
            this.TemplateButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.GetDataButton = new System.Windows.Forms.Button();
            this.listViewExcel = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTitleblock = new System.Windows.Forms.ComboBox();
            this.CreateSheetsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SelectNoneButton = new System.Windows.Forms.Button();
            this.SelectAllButon = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TemplateButton
            // 
            this.TemplateButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TemplateButton.Location = new System.Drawing.Point(6, 31);
            this.TemplateButton.Name = "TemplateButton";
            this.TemplateButton.Size = new System.Drawing.Size(194, 42);
            this.TemplateButton.TabIndex = 0;
            this.TemplateButton.Text = "Generate Template";
            this.TemplateButton.UseVisualStyleBackColor = true;
            this.TemplateButton.Click += new System.EventHandler(this.TemplateButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(345, 488);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(194, 42);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // GetDataButton
            // 
            this.GetDataButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GetDataButton.Location = new System.Drawing.Point(6, 91);
            this.GetDataButton.Name = "GetDataButton";
            this.GetDataButton.Size = new System.Drawing.Size(194, 42);
            this.GetDataButton.TabIndex = 2;
            this.GetDataButton.Text = "Get Excel Data";
            this.GetDataButton.UseVisualStyleBackColor = true;
            this.GetDataButton.Click += new System.EventHandler(this.GetDataButton_Click);
            // 
            // listViewExcel
            // 
            this.listViewExcel.FullRowSelect = true;
            this.listViewExcel.Location = new System.Drawing.Point(9, 21);
            this.listViewExcel.Name = "listViewExcel";
            this.listViewExcel.Size = new System.Drawing.Size(320, 350);
            this.listViewExcel.TabIndex = 3;
            this.listViewExcel.UseCompatibleStateImageBehavior = false;
            this.listViewExcel.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxTitleblock);
            this.groupBox1.Controls.Add(this.CreateSheetsButton);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.StatusLabel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.StopButton);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.designtechLogo);
            this.groupBox1.Controls.Add(this.listViewExcel);
            this.groupBox1.Controls.Add(this.closeButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 547);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excel Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Title Block";
            // 
            // comboBoxTitleblock
            // 
            this.comboBoxTitleblock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTitleblock.FormattingEnabled = true;
            this.comboBoxTitleblock.Location = new System.Drawing.Point(81, 377);
            this.comboBoxTitleblock.Name = "comboBoxTitleblock";
            this.comboBoxTitleblock.Size = new System.Drawing.Size(248, 24);
            this.comboBoxTitleblock.TabIndex = 12;
            this.comboBoxTitleblock.SelectedIndexChanged += new System.EventHandler(this.comboBoxTitleblock_SelectedIndexChanged);
            // 
            // CreateSheetsButton
            // 
            this.CreateSheetsButton.Location = new System.Drawing.Point(345, 334);
            this.CreateSheetsButton.Name = "CreateSheetsButton";
            this.CreateSheetsButton.Size = new System.Drawing.Size(197, 42);
            this.CreateSheetsButton.TabIndex = 11;
            this.CreateSheetsButton.Text = "Create Sheets";
            this.CreateSheetsButton.UseVisualStyleBackColor = true;
            this.CreateSheetsButton.Click += new System.EventHandler(this.CreateSheetsButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SelectNoneButton);
            this.groupBox3.Controls.Add(this.SelectAllButon);
            this.groupBox3.Location = new System.Drawing.Point(339, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(206, 124);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selection";
            // 
            // SelectNoneButton
            // 
            this.SelectNoneButton.Location = new System.Drawing.Point(6, 69);
            this.SelectNoneButton.Name = "SelectNoneButton";
            this.SelectNoneButton.Size = new System.Drawing.Size(197, 42);
            this.SelectNoneButton.TabIndex = 1;
            this.SelectNoneButton.Text = "None";
            this.SelectNoneButton.UseVisualStyleBackColor = true;
            this.SelectNoneButton.Click += new System.EventHandler(this.SelectNoneButton_Click);
            // 
            // SelectAllButon
            // 
            this.SelectAllButon.Location = new System.Drawing.Point(6, 21);
            this.SelectAllButon.Name = "SelectAllButon";
            this.SelectAllButon.Size = new System.Drawing.Size(197, 42);
            this.SelectAllButon.TabIndex = 0;
            this.SelectAllButon.Text = "All";
            this.SelectAllButon.UseVisualStyleBackColor = true;
            this.SelectAllButon.Click += new System.EventHandler(this.SelectAllButon_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(400, 452);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(83, 17);
            this.StatusLabel.TabIndex = 9;
            this.StatusLabel.Text = "Please Wait";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TemplateButton);
            this.groupBox2.Controls.Add(this.GetDataButton);
            this.groupBox2.Location = new System.Drawing.Point(336, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 147);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(345, 407);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(194, 42);
            this.StopButton.TabIndex = 7;
            this.StopButton.Text = "Cancel";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 407);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(320, 42);
            this.progressBar1.TabIndex = 6;
            // 
            // designtechLogo
            // 
            this.designtechLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.designtechLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.designtechLogo.Image = ((System.Drawing.Image)(resources.GetObject("designtechLogo.Image")));
            this.designtechLogo.Location = new System.Drawing.Point(7, 457);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(323, 73);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 5;
            this.designtechLogo.TabStop = false;
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
            // SheetsFromExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 560);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SheetsFromExcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Sheets";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SheetsFromExcelForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TemplateButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button GetDataButton;
        private System.Windows.Forms.ListView listViewExcel;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button CreateSheetsButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SelectNoneButton;
        private System.Windows.Forms.Button SelectAllButon;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTitleblock;
    }
}