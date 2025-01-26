namespace Exam_Form
{
    partial class Frm_GetInstructorCourses
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
            reportViewer_GetInstructorCourses = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // reportViewer_GetInstructorCourses
            // 
            reportViewer_GetInstructorCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer_GetInstructorCourses.Location = new Point(0, 0);
            reportViewer_GetInstructorCourses.Name = "ReportViewer";
            reportViewer_GetInstructorCourses.ServerReport.BearerToken = null;
            reportViewer_GetInstructorCourses.Size = new Size(644, 701);
            reportViewer_GetInstructorCourses.TabIndex = 0;
            // 
            // Frm_GetInstructorCourses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 701);
            Controls.Add(reportViewer_GetInstructorCourses);
            Name = "Frm_GetInstructorCourses";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_GetInstructorCourses";
            Load += Frm_GetInstructorCourses_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_GetInstructorCourses;
    }
}