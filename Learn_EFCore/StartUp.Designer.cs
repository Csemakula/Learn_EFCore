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
            jobsDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)jobsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // jobsDataGridView
            // 
            jobsDataGridView.AllowUserToAddRows = false;
            jobsDataGridView.AllowUserToDeleteRows = false;
            jobsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jobsDataGridView.Location = new Point(12, 25);
            jobsDataGridView.Name = "jobsDataGridView";
            jobsDataGridView.ReadOnly = true;
            jobsDataGridView.Size = new Size(776, 413);
            jobsDataGridView.TabIndex = 0;
            // 
            // StartUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(jobsDataGridView);
            Name = "StartUp";
            Text = "Start";
            ((System.ComponentModel.ISupportInitialize)jobsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView jobsDataGridView;
    }
}
