namespace DesignTechRibbon.Revit.EssentialTools.RenumberSpline
{
    partial class SelectionFormLP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionFormLP));
            this.SelectionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelSelected = new System.Windows.Forms.Label();
            this.CloseWindow = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.designtechLogo = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectionButton
            // 
            this.SelectionButton.Location = new System.Drawing.Point(15, 21);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new System.Drawing.Size(156, 47);
            this.SelectionButton.TabIndex = 0;
            this.SelectionButton.Text = "Add Selection to List";
            this.SelectionButton.UseVisualStyleBackColor = true;
            this.SelectionButton.Click += new System.EventHandler(this.SelectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select A Single Model Line In The Document";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(15, 91);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(156, 47);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load Model Line";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelSelected);
            this.groupBox1.Controls.Add(this.CloseWindow);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.designtechLogo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 256);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // LabelSelected
            // 
            this.LabelSelected.AutoSize = true;
            this.LabelSelected.Location = new System.Drawing.Point(18, 92);
            this.LabelSelected.Name = "LabelSelected";
            this.LabelSelected.Size = new System.Drawing.Size(107, 17);
            this.LabelSelected.TabIndex = 12;
            this.LabelSelected.Text = "Selection Name";
            // 
            // CloseWindow
            // 
            this.CloseWindow.Location = new System.Drawing.Point(332, 191);
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.Size = new System.Drawing.Size(186, 47);
            this.CloseWindow.TabIndex = 10;
            this.CloseWindow.Text = "Close";
            this.CloseWindow.UseVisualStyleBackColor = true;
            this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SelectionButton);
            this.groupBox2.Controls.Add(this.LoadButton);
            this.groupBox2.Location = new System.Drawing.Point(332, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 152);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // designtechLogo
            // 
            this.designtechLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.designtechLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.designtechLogo.Image = ((System.Drawing.Image)(resources.GetObject("designtechLogo.Image")));
            this.designtechLogo.Location = new System.Drawing.Point(7, 165);
            this.designtechLogo.Margin = new System.Windows.Forms.Padding(4);
            this.designtechLogo.Name = "designtechLogo";
            this.designtechLogo.Size = new System.Drawing.Size(313, 73);
            this.designtechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.designtechLogo.TabIndex = 8;
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
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 268);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.designtechLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CloseWindow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox designtechLogo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label LabelSelected;
    }
}