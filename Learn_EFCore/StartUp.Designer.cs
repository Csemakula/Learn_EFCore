namespace Learn_EFCore
{
    partial class StartUp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUp));
            jobsDataGridView = new DataGridView();
            toolStrip1 = new ToolStrip();
            allToolStripButton = new ToolStripButton();
            overDueToolStripButton = new ToolStripButton();
            unassignedToolStripButton = new ToolStripButton();
            topEmployeeToolStripButton = new ToolStripButton();
            recentToolStripButton = new ToolStripButton();
            averageToolStripButton = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)jobsDataGridView).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // jobsDataGridView
            // 
            jobsDataGridView.AllowUserToAddRows = false;
            jobsDataGridView.AllowUserToDeleteRows = false;
            jobsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            jobsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jobsDataGridView.Location = new Point(12, 51);
            jobsDataGridView.Name = "jobsDataGridView";
            jobsDataGridView.ReadOnly = true;
            jobsDataGridView.Size = new Size(776, 387);
            jobsDataGridView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { allToolStripButton, overDueToolStripButton, unassignedToolStripButton, topEmployeeToolStripButton, recentToolStripButton, averageToolStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // allToolStripButton
            // 
            allToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            allToolStripButton.Image = (Image)resources.GetObject("allToolStripButton.Image");
            allToolStripButton.ImageTransparentColor = Color.Magenta;
            allToolStripButton.Name = "allToolStripButton";
            allToolStripButton.Size = new Size(25, 22);
            allToolStripButton.Text = "All";
            allToolStripButton.Click += AllToolStripButton_Click;
            // 
            // overDueToolStripButton
            // 
            overDueToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            overDueToolStripButton.Image = (Image)resources.GetObject("overDueToolStripButton.Image");
            overDueToolStripButton.ImageTransparentColor = Color.Magenta;
            overDueToolStripButton.Name = "overDueToolStripButton";
            overDueToolStripButton.Size = new Size(56, 22);
            overDueToolStripButton.Text = "Overdue";
            overDueToolStripButton.Click += OverDueToolStripButton_Click;
            // 
            // unassignedToolStripButton
            // 
            unassignedToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            unassignedToolStripButton.Image = (Image)resources.GetObject("unassignedToolStripButton.Image");
            unassignedToolStripButton.ImageTransparentColor = Color.Magenta;
            unassignedToolStripButton.Name = "unassignedToolStripButton";
            unassignedToolStripButton.Size = new Size(72, 22);
            unassignedToolStripButton.Text = "Unassigned";
            unassignedToolStripButton.Click += UnassignedToolStripButton_Click;
            // 
            // topEmployeeToolStripButton
            // 
            topEmployeeToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            topEmployeeToolStripButton.Image = (Image)resources.GetObject("topEmployeeToolStripButton.Image");
            topEmployeeToolStripButton.ImageTransparentColor = Color.Magenta;
            topEmployeeToolStripButton.Name = "topEmployeeToolStripButton";
            topEmployeeToolStripButton.Size = new Size(90, 22);
            topEmployeeToolStripButton.Text = "Top Employees";
            topEmployeeToolStripButton.Click += TopEmployeeToolStripButton_Click;
            // 
            // recentToolStripButton
            // 
            recentToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            recentToolStripButton.Image = (Image)resources.GetObject("recentToolStripButton.Image");
            recentToolStripButton.ImageTransparentColor = Color.Magenta;
            recentToolStripButton.Name = "recentToolStripButton";
            recentToolStripButton.Size = new Size(73, 22);
            recentToolStripButton.Text = "Recent Jobs";
            recentToolStripButton.Click += RecentToolStripButton_Click;
            // 
            // averageToolStripButton
            // 
            averageToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            averageToolStripButton.Image = (Image)resources.GetObject("averageToolStripButton.Image");
            averageToolStripButton.ImageTransparentColor = Color.Magenta;
            averageToolStripButton.Name = "averageToolStripButton";
            averageToolStripButton.Size = new Size(89, 22);
            averageToolStripButton.Text = "Average Hours";
            averageToolStripButton.Click += AverageToolStripButton_Click;
            // 
            // StartUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Controls.Add(jobsDataGridView);
            Name = "StartUp";
            Text = "Start";
            ((System.ComponentModel.ISupportInitialize)jobsDataGridView).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView jobsDataGridView;
        private ToolStrip toolStrip1;
        private ToolStripButton allToolStripButton;
        private ToolStripButton overDueToolStripButton;
        private ToolStripButton unassignedToolStripButton;
        private ToolStripButton topEmployeeToolStripButton;
        private ToolStripButton recentToolStripButton;
        private ToolStripButton averageToolStripButton;
    }
}
