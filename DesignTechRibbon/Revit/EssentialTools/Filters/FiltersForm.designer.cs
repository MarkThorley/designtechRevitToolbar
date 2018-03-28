namespace EssentialTools
{
    partial class FiltersForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltersForm));
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.GroupBox();
            this.totalLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioUnassigned = new System.Windows.Forms.RadioButton();
            this.radioUnused = new System.Windows.Forms.RadioButton();
            this.radioUsed = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SrchBox = new System.Windows.Forms.TextBox();
            this.filtersList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // designtechLogo
            // 
            this.designtechLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.designtechLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.designtechLogo.Image = ((System.Drawing.Image)(resources.GetObject("designtechLogo.Image")));
            this.designtechLogo.Location = new System.Drawing.Point(12, 264);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(200, 35);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 4;
            this.designtechLogo.TabStop = false;
            this.designtechLogo.Click += new System.EventHandler(this.designtechLogo_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.totalLbl);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.radioUnassigned);
            this.mainPanel.Controls.Add(this.radioUnused);
            this.mainPanel.Controls.Add(this.radioUsed);
            this.mainPanel.Controls.Add(this.radioAll);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.SrchBox);
            this.mainPanel.Controls.Add(this.filtersList);
            this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(446, 241);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.TabStop = false;
            this.mainPanel.Text = "Filters";
            // 
            // totalLbl
            // 
            this.totalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(6, 221);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(34, 13);
            this.totalLbl.TabIndex = 10;
            this.totalLbl.Text = "Total:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search Filter Name:";
            // 
            // radioUnassigned
            // 
            this.radioUnassigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioUnassigned.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUnassigned.Location = new System.Drawing.Point(344, 46);
            this.radioUnassigned.Name = "radioUnassigned";
            this.radioUnassigned.Size = new System.Drawing.Size(111, 17);
            this.radioUnassigned.TabIndex = 8;
            this.radioUnassigned.Text = "Unassigned";
            this.radioUnassigned.UseVisualStyleBackColor = true;
            this.radioUnassigned.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioUnused
            // 
            this.radioUnused.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioUnused.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUnused.Location = new System.Drawing.Point(344, 23);
            this.radioUnused.Name = "radioUnused";
            this.radioUnused.Size = new System.Drawing.Size(89, 17);
            this.radioUnused.TabIndex = 7;
            this.radioUnused.Text = "Unused";
            this.radioUnused.UseVisualStyleBackColor = true;
            this.radioUnused.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioUsed
            // 
            this.radioUsed.AutoSize = true;
            this.radioUsed.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUsed.Location = new System.Drawing.Point(287, 46);
            this.radioUsed.Name = "radioUsed";
            this.radioUsed.Size = new System.Drawing.Size(51, 17);
            this.radioUsed.TabIndex = 6;
            this.radioUsed.Text = "Used";
            this.radioUsed.UseVisualStyleBackColor = true;
            this.radioUsed.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAll.Location = new System.Drawing.Point(287, 23);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(38, 17);
            this.radioAll.TabIndex = 5;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 61);
            this.label2.TabIndex = 4;
            this.label2.Text = "Unassigned are those Filters that are placed on a View/View Template but are left" +
    " at default values.\r\n";
            // 
            // SrchBox
            // 
            this.SrchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SrchBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrchBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.SrchBox.Location = new System.Drawing.Point(286, 188);
            this.SrchBox.Name = "SrchBox";
            this.SrchBox.Size = new System.Drawing.Size(132, 22);
            this.SrchBox.TabIndex = 1;
            this.SrchBox.Text = "Contains ..";
            this.SrchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SrchBox_MouseClick);
            this.SrchBox.TextChanged += new System.EventHandler(this.SrchBox_TextChanged);
            this.SrchBox.Leave += new System.EventHandler(this.SrchBox_Leave);
            // 
            // filtersList
            // 
            this.filtersList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filtersList.ContextMenuStrip = this.contextMenuStrip1;
            this.filtersList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtersList.FormattingEnabled = true;
            this.filtersList.Location = new System.Drawing.Point(8, 23);
            this.filtersList.Name = "filtersList";
            this.filtersList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filtersList.Size = new System.Drawing.Size(260, 186);
            this.filtersList.Sorted = true;
            this.filtersList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem1.Text = "Select All";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(383, 264);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 35);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delBtn.Location = new System.Drawing.Point(302, 264);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 35);
            this.delBtn.TabIndex = 1;
            this.delBtn.Text = "Delete";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.mainPanel);
            this.panel1.Controls.Add(this.designtechLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 311);
            this.panel1.TabIndex = 0;
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(470, 311);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(486, 350);
            this.MinimumSize = new System.Drawing.Size(486, 350);
            this.Name = "FiltersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delete Filters";
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox designtechLogo;
        private System.Windows.Forms.GroupBox mainPanel;
        private System.Windows.Forms.TextBox SrchBox;
        private System.Windows.Forms.ListBox filtersList;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioUnassigned;
        private System.Windows.Forms.RadioButton radioUnused;
        private System.Windows.Forms.RadioButton radioUsed;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}