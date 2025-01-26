namespace Exam_Form
{
    partial class Frm_GetExamQuestionsWithChoices
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
            reportViewer_GetExamQuestionsWithChoicess = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // reportViewer_GetExamQuestionsWithChoicess
            // 
            reportViewer_GetExamQuestionsWithChoicess.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer_GetExamQuestionsWithChoicess.Location = new Point(0, 0);
            reportViewer_GetExamQuestionsWithChoicess.Name = "ReportViewer";
            reportViewer_GetExamQuestionsWithChoicess.ServerReport.BearerToken = null;
            reportViewer_GetExamQuestionsWithChoicess.Size = new Size(1052, 629);
            reportViewer_GetExamQuestionsWithChoicess.TabIndex = 0;
            // 
            // Frm_GetExamQuestionsWithChoices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 630);
            Controls.Add(reportViewer_GetExamQuestionsWithChoicess);
            Name = "Frm_GetExamQuestionsWithChoices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_GetExamQuestionsWithChoices";
            Load += Frm_GetExamQuestionsWithChoices_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_GetExamQuestionsWithChoicess;
    }
}