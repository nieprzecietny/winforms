﻿namespace WinForms.Views
{
    partial class LoadReportView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxReportResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxReportResults
            // 
            this.textBoxReportResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReportResults.Location = new System.Drawing.Point(0, 0);
            this.textBoxReportResults.Name = "textBoxReportResults";
            this.textBoxReportResults.Size = new System.Drawing.Size(1311, 657);
            this.textBoxReportResults.TabIndex = 0;
            this.textBoxReportResults.Text = "";
            // 
            // LoadReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxReportResults);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoadReportView";
            this.Size = new System.Drawing.Size(1311, 657);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBoxReportResults;
    }
}
