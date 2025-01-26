namespace Exam_Form
{
    partial class Frm_GetExamQuestionsWithAnswers
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
            reportViewer_GetExamQuestionsWithAnswers = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // reportViewer_GetExamQuestionsWithAnswers
            // 
            reportViewer_GetExamQuestionsWithAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer_GetExamQuestionsWithAnswers.Location = new Point(0, 0);
            reportViewer_GetExamQuestionsWithAnswers.Name = "ReportViewer";
            reportViewer_GetExamQuestionsWithAnswers.ServerReport.BearerToken = null;
            reportViewer_GetExamQuestionsWithAnswers.Size = new Size(1146, 792);
            reportViewer_GetExamQuestionsWithAnswers.TabIndex = 0;
            // 
            // Frm_GetExamQuestionsWithAnswers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 793);
            Controls.Add(reportViewer_GetExamQuestionsWithAnswers);
            Name = "Frm_GetExamQuestionsWithAnswers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_GetExamQuestionsWithAnswers";
            Load += Frm_GetExamQuestionsWithAnswers_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_GetExamQuestionsWithAnswers;
    }
}