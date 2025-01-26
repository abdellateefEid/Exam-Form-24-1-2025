namespace Exam_Form
{
    partial class Frm_GetCourseTopics
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
            reportViewer_GetCourseTopics = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // reportViewer_GetCourseTopics
            // 
            reportViewer_GetCourseTopics.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer_GetCourseTopics.Location = new Point(0, 0);
            reportViewer_GetCourseTopics.Name = "ReportViewer";
            reportViewer_GetCourseTopics.ServerReport.BearerToken = null;
            reportViewer_GetCourseTopics.Size = new Size(602, 538);
            reportViewer_GetCourseTopics.TabIndex = 0;
            // 
            // Frm_GetCourseTopics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 539);
            Controls.Add(reportViewer_GetCourseTopics);
            Name = "Frm_GetCourseTopics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_GetCourseTopics";
            Load += Frm_GetCourseTopics_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_GetCourseTopics;
    }
}