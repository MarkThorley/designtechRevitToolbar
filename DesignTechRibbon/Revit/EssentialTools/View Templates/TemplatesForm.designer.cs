namespace EssentialTools
{
    partial class TemplatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplatesForm));
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.GroupBox();
            this.totalLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usedBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SrchBox = new System.Windows.Forms.TextBox();
            this.templateList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioUnassigned = new System.Windows.Forms.RadioButton();
            this.radioUnused = new System.Windows.Forms.RadioButton();
            this.radioUsed = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
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
            this.designtechLogo.Location = new System.Drawing.Point(15, 368);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(264, 84);
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
            this.mainPanel.Controls.Add(this.radioUnassigned);
            this.mainPanel.Controls.Add(this.radioUnused);
            this.mainPanel.Controls.Add(this.radioUsed);
            this.mainPanel.Controls.Add(this.radioAll);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.totalLbl);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.usedBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.SrchBox);
            this.mainPanel.Controls.Add(this.templateList);
            this.mainPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.Location = new System.Drawing.Point(15, 15);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(4);
            this.mainPanel.Size = new System.Drawing.Size(584, 345);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.TabStop = false;
            this.mainPanel.Text = "View Templates";
            // 
            // totalLbl
            // 
            this.totalLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(8, 319);
            this.totalLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(41, 19);
            this.totalLbl.TabIndex = 5;
            this.totalLbl.Text = "Total:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(368, 270);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Include Used View Templates.";
            // 
            // usedBox
            // 
            this.usedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.usedBox.AutoSize = true;
            this.usedBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedBox.Location = new System.Drawing.Point(372, 293);
            this.usedBox.Margin = new System.Windows.Forms.Padding(4);
            this.usedBox.Name = "usedBox";
            this.usedBox.Size = new System.Drawing.Size(51, 23);
            this.usedBox.TabIndex = 2;
            this.usedBox.Text = "Yes";
            this.usedBox.UseVisualStyleBackColor = true;
            this.usedBox.Click += new System.EventHandler(this.usedBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Specify a substring to filter the list of View Templates.";
            // 
            // SrchBox
            // 
            this.SrchBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrchBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.SrchBox.Location = new System.Drawing.Point(372, 223);
            this.SrchBox.Margin = new System.Windows.Forms.Padding(4);
            this.SrchBox.Name = "SrchBox";
            this.SrchBox.Size = new System.Drawing.Size(93, 26);
            this.SrchBox.TabIndex = 1;
            this.SrchBox.Text = "Contains ..";
            this.SrchBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SrchBox_MouseClick);
            this.SrchBox.TextChanged += new System.EventHandler(this.SrchBox_TextChanged);
            this.SrchBox.LostFocus += new System.EventHandler(this.SrchBox_Leave);
            // 
            // templateList
            // 
            this.templateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.templateList.ContextMenuStrip = this.contextMenuStrip1;
            this.templateList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateList.FormattingEnabled = true;
            this.templateList.ItemHeight = 19;
            this.templateList.Location = new System.Drawing.Point(10, 29);
            this.templateList.Margin = new System.Windows.Forms.Padding(4);
            this.templateList.Name = "templateList";
            this.templateList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.templateList.Size = new System.Drawing.Size(340, 289);
            this.templateList.Sorted = true;
            this.templateList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 24);
            this.toolStripMenuItem1.Text = "Select All";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(505, 408);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 44);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delBtn.Location = new System.Drawing.Point(404, 408);
            this.delBtn.Margin = new System.Windows.Forms.Padding(4);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(94, 44);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 466);
            this.panel1.TabIndex = 0;
            // 
            // radioUnassigned
            // 
            this.radioUnassigned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioUnassigned.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUnassigned.Location = new System.Drawing.Point(446, 138);
            this.radioUnassigned.Margin = new System.Windows.Forms.Padding(4);
            this.radioUnassigned.Name = "radioUnassigned";
            this.radioUnassigned.Size = new System.Drawing.Size(105, 21);
            this.radioUnassigned.TabIndex = 13;
            this.radioUnassigned.Text = "Unassigned.";
            this.radioUnassigned.UseVisualStyleBackColor = true;
            this.radioUnassigned.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioUnused
            // 
            this.radioUnused.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioUnused.Checked = true;
            this.radioUnused.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUnused.Location = new System.Drawing.Point(446, 109);
            this.radioUnused.Margin = new System.Windows.Forms.Padding(4);
            this.radioUnused.Name = "radioUnused";
            this.radioUnused.Size = new System.Drawing.Size(78, 21);
            this.radioUnused.TabIndex = 12;
            this.radioUnused.TabStop = true;
            this.radioUnused.Text = "Unused.";
            this.radioUnused.UseVisualStyleBackColor = true;
            this.radioUnused.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioUsed
            // 
            this.radioUsed.AutoSize = true;
            this.radioUsed.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUsed.Location = new System.Drawing.Point(374, 138);
            this.radioUsed.Margin = new System.Windows.Forms.Padding(4);
            this.radioUsed.Name = "radioUsed";
            this.radioUsed.Size = new System.Drawing.Size(61, 23);
            this.radioUsed.TabIndex = 11;
            this.radioUsed.Text = "Used";
            this.radioUsed.UseVisualStyleBackColor = true;
            this.radioUsed.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAll.Location = new System.Drawing.Point(374, 109);
            this.radioAll.Margin = new System.Windows.Forms.Padding(4);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(45, 23);
            this.radioAll.TabIndex = 10;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(368, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 76);
            this.label3.TabIndex = 9;
            this.label3.Text = "Unassigned are those Filters that are placed on a View/View Template but are left" + " at default values.\r\n";
            // 
            // TemplatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(614, 466);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(18, 363);
            this.Name = "TemplatesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete View Templates";
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
        private System.Windows.Forms.CheckBox usedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SrchBox;
        private System.Windows.Forms.ListBox templateList;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.RadioButton radioUnassigned;
        private System.Windows.Forms.RadioButton radioUnused;
        private System.Windows.Forms.RadioButton radioUsed;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.Label label3;
    }
}