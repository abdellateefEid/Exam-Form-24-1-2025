namespace Exam_Form
{
    partial class Frm_Stu_Coures_Exam
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
            panelCoursesAndExams = new Panel();
            lab_welcome = new Label();
            SuspendLayout();
            // 
            // panelCoursesAndExams
            // 
            panelCoursesAndExams.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelCoursesAndExams.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelCoursesAndExams.Location = new Point(84, 83);
            panelCoursesAndExams.Name = "panelCoursesAndExams";
            panelCoursesAndExams.Size = new Size(801, 574);
            panelCoursesAndExams.TabIndex = 0;
            // 
            // lab_welcome
            // 
            lab_welcome.AutoSize = true;
            lab_welcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_welcome.ForeColor = Color.FromArgb(0, 192, 0);
            lab_welcome.Location = new Point(84, 39);
            lab_welcome.Name = "lab_welcome";
            lab_welcome.Size = new Size(88, 25);
            lab_welcome.TabIndex = 1;
            lab_welcome.Text = "Wecome";
            // 
            // Frm_Stu_Coures_Exam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1001, 687);
            Controls.Add(lab_welcome);
            Controls.Add(panelCoursesAndExams);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Frm_Stu_Coures_Exam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_Stu_Coures_Exam";
            Load += Frm_Stu_Coures_Exam_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCoursesAndExams;
        private Label lab_welcome;
    }
}