namespace Exam_Form
{
    partial class Frm_GetStuByDept_SP
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
            reportViewer_getStuByDept = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // reportViewer_getStuByDept
            // 
            reportViewer_getStuByDept.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer_getStuByDept.Location = new Point(0, 0);
            reportViewer_getStuByDept.Name = "ReportViewer";
            reportViewer_getStuByDept.ServerReport.BearerToken = null;
            reportViewer_getStuByDept.Size = new Size(1047, 731);
            reportViewer_getStuByDept.TabIndex = 0;
            // 
            // Frm_GetStuByDept_SP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 731);
            Controls.Add(reportViewer_getStuByDept);
            Name = "Frm_GetStuByDept_SP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_GetStuByDept_SP";
            Load += Frm_GetStuByDept_SP_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_getStuByDept;
    }
}