namespace Exam_Form
{
    partial class Frm_Instructor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Instructor));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btn_Ques = new Button();
            btn_reports = new Button();
            label2 = new Label();
            comb_coursesName = new ComboBox();
            dg_questions = new DataGridView();
            btn_save = new Button();
            dg_qOptions = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            pnl_reports = new Panel();
            comb_courseExamReport = new ComboBox();
            label6 = new Label();
            comb_studentsName = new ComboBox();
            label11 = new Label();
            button6 = new Button();
            comb_departmentsName = new ComboBox();
            label10 = new Label();
            button5 = new Button();
            comb_studentsNameGrades = new ComboBox();
            label9 = new Label();
            button4 = new Button();
            comb_instructorsName = new ComboBox();
            label8 = new Label();
            button3 = new Button();
            button2 = new Button();
            cmb_courseNmaeStuExam = new ComboBox();
            label5 = new Label();
            button1 = new Button();
            cmb_courseNmae = new ComboBox();
            label7 = new Label();
            pnl_question = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg_questions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg_qOptions).BeginInit();
            pnl_reports.SuspendLayout();
            pnl_question.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 149);
            label1.Name = "label1";
            label1.Size = new Size(163, 30);
            label1.TabIndex = 0;
            label1.Text = "Instructor Page";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(64, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btn_Ques
            // 
            btn_Ques.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Ques.Location = new Point(32, 228);
            btn_Ques.Name = "btn_Ques";
            btn_Ques.Size = new Size(163, 40);
            btn_Ques.TabIndex = 2;
            btn_Ques.Text = "Question";
            btn_Ques.UseVisualStyleBackColor = true;
            btn_Ques.Click += btn_Ques_Click;
            // 
            // btn_reports
            // 
            btn_reports.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_reports.Location = new Point(32, 285);
            btn_reports.Name = "btn_reports";
            btn_reports.Size = new Size(163, 40);
            btn_reports.TabIndex = 4;
            btn_reports.Text = "Reports";
            btn_reports.UseVisualStyleBackColor = true;
            btn_reports.Click += btn_reports_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 55);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 0;
            label2.Text = "Course name";
            // 
            // comb_coursesName
            // 
            comb_coursesName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comb_coursesName.FormattingEnabled = true;
            comb_coursesName.Location = new Point(32, 84);
            comb_coursesName.Name = "comb_coursesName";
            comb_coursesName.Size = new Size(290, 29);
            comb_coursesName.TabIndex = 1;
            comb_coursesName.SelectedIndexChanged += comb_coursesName_SelectedIndexChanged;
            // 
            // dg_questions
            // 
            dg_questions.AllowUserToResizeRows = false;
            dg_questions.BackgroundColor = Color.White;
            dg_questions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_questions.Location = new Point(32, 159);
            dg_questions.Name = "dg_questions";
            dg_questions.Size = new Size(730, 242);
            dg_questions.TabIndex = 2;
            dg_questions.CellClick += dg_questions_CellClick;
            // 
            // btn_save
            // 
            btn_save.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_save.Location = new Point(657, 549);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(105, 34);
            btn_save.TabIndex = 3;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // dg_qOptions
            // 
            dg_qOptions.BackgroundColor = Color.White;
            dg_qOptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg_qOptions.Location = new Point(32, 433);
            dg_qOptions.Name = "dg_qOptions";
            dg_qOptions.Size = new Size(471, 150);
            dg_qOptions.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 141);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "Quetions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 415);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 6;
            label4.Text = "Quetion Choices";
            // 
            // pnl_reports
            // 
            pnl_reports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_reports.BackColor = Color.White;
            pnl_reports.Controls.Add(comb_courseExamReport);
            pnl_reports.Controls.Add(label6);
            pnl_reports.Controls.Add(comb_studentsName);
            pnl_reports.Controls.Add(label11);
            pnl_reports.Controls.Add(button6);
            pnl_reports.Controls.Add(comb_departmentsName);
            pnl_reports.Controls.Add(label10);
            pnl_reports.Controls.Add(button5);
            pnl_reports.Controls.Add(comb_studentsNameGrades);
            pnl_reports.Controls.Add(label9);
            pnl_reports.Controls.Add(button4);
            pnl_reports.Controls.Add(comb_instructorsName);
            pnl_reports.Controls.Add(label8);
            pnl_reports.Controls.Add(button3);
            pnl_reports.Controls.Add(button2);
            pnl_reports.Controls.Add(cmb_courseNmaeStuExam);
            pnl_reports.Controls.Add(label5);
            pnl_reports.Controls.Add(button1);
            pnl_reports.Controls.Add(cmb_courseNmae);
            pnl_reports.Controls.Add(label7);
            pnl_reports.Location = new Point(212, 1);
            pnl_reports.Name = "pnl_reports";
            pnl_reports.Size = new Size(856, 628);
            pnl_reports.TabIndex = 7;
            // 
            // comb_courseExamReport
            // 
            comb_courseExamReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comb_courseExamReport.FormattingEnabled = true;
            comb_courseExamReport.Location = new Point(32, 256);
            comb_courseExamReport.Name = "comb_courseExamReport";
            comb_courseExamReport.Size = new Size(290, 29);
            comb_courseExamReport.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 227);
            label6.Name = "label6";
            label6.Size = new Size(123, 25);
            label6.TabIndex = 21;
            label6.Text = "Course name";
            // 
            // comb_studentsName
            // 
            comb_studentsName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comb_studentsName.FormattingEnabled = true;
            comb_studentsName.Location = new Point(350, 172);
            comb_studentsName.Name = "comb_studentsName";
            comb_studentsName.Size = new Size(236, 29);
            comb_studentsName.TabIndex = 20;
            comb_studentsName.SelectedIndexChanged += comb_studentsName_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(343, 143);
            label11.Name = "label11";
            label11.Size = new Size(128, 25);
            label11.TabIndex = 19;
            label11.Text = "Student name";
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(358, 528);
            button6.Name = "button6";
            button6.Size = new Size(228, 34);
            button6.TabIndex = 18;
            button6.Text = "View Students Report";
            button6.UseVisualStyleBackColor = true;
            // 
            // comb_departmentsName
            // 
            comb_departmentsName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comb_departmentsName.FormattingEnabled = true;
            comb_departmentsName.Location = new Point(34, 528);
            comb_departmentsName.Name = "comb_departmentsName";
            comb_departmentsName.Size = new Size(290, 29);
            comb_departmentsName.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(27, 499);
            label10.Name = "label10";
            label10.Size = new Size(164, 25);
            label10.TabIndex = 16;
            label10.Text = "Department name";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(358, 431);
            button5.Name = "button5";
            button5.Size = new Size(228, 34);
            button5.TabIndex = 15;
            button5.Text = "View Grades Report";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // comb_studentsNameGrades
            // 
            comb_studentsNameGrades.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comb_studentsNameGrades.FormattingEnabled = true;
            comb_studentsNameGrades.Location = new Point(34, 431);
            comb_studentsNameGrades.Name = "comb_studentsNameGrades";
            comb_studentsNameGrades.Size = new Size(290, 29);
            comb_studentsNameGrades.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(27, 402);
            label9.Name = "label9";
            label9.Size = new Size(128, 25);
            label9.TabIndex = 13;
            label9.Text = "Student name";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(358, 338);
            button4.Name = "button4";
            button4.Size = new Size(228, 34);
            button4.TabIndex = 12;
            button4.Text = "View Courses Report";
            button4.UseVisualStyleBackColor = true;
            // 
            // comb_instructorsName
            // 
            comb_instructorsName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comb_instructorsName.FormattingEnabled = true;
            comb_instructorsName.Location = new Point(34, 338);
            comb_instructorsName.Name = "comb_instructorsName";
            comb_instructorsName.Size = new Size(290, 29);
            comb_instructorsName.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(27, 309);
            label8.Name = "label8";
            label8.Size = new Size(145, 25);
            label8.TabIndex = 10;
            label8.Text = "Instructor name";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(356, 256);
            button3.Name = "button3";
            button3.Size = new Size(230, 34);
            button3.TabIndex = 9;
            button3.Text = "View Exam Report";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(610, 172);
            button2.Name = "button2";
            button2.Size = new Size(218, 34);
            button2.TabIndex = 6;
            button2.Text = "View Stu Exam Report";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // cmb_courseNmaeStuExam
            // 
            cmb_courseNmaeStuExam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_courseNmaeStuExam.FormattingEnabled = true;
            cmb_courseNmaeStuExam.Location = new Point(32, 172);
            cmb_courseNmaeStuExam.Name = "cmb_courseNmaeStuExam";
            cmb_courseNmaeStuExam.Size = new Size(290, 29);
            cmb_courseNmaeStuExam.TabIndex = 5;
            cmb_courseNmaeStuExam.SelectedIndexChanged += cmb_courseNmaeStuExam_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 143);
            label5.Name = "label5";
            label5.Size = new Size(123, 25);
            label5.TabIndex = 4;
            label5.Text = "Course name";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(356, 84);
            button1.Name = "button1";
            button1.Size = new Size(230, 34);
            button1.TabIndex = 3;
            button1.Text = "View Topic Report";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cmb_courseNmae
            // 
            cmb_courseNmae.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_courseNmae.FormattingEnabled = true;
            cmb_courseNmae.Location = new Point(32, 84);
            cmb_courseNmae.Name = "cmb_courseNmae";
            cmb_courseNmae.Size = new Size(290, 29);
            cmb_courseNmae.TabIndex = 1;
            cmb_courseNmae.SelectedIndexChanged += cmb_courseNmae_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(25, 55);
            label7.Name = "label7";
            label7.Size = new Size(123, 25);
            label7.TabIndex = 0;
            label7.Text = "Course name";
            // 
            // pnl_question
            // 
            pnl_question.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_question.BackColor = Color.White;
            pnl_question.Controls.Add(label4);
            pnl_question.Controls.Add(label3);
            pnl_question.Controls.Add(dg_qOptions);
            pnl_question.Controls.Add(btn_save);
            pnl_question.Controls.Add(dg_questions);
            pnl_question.Controls.Add(comb_coursesName);
            pnl_question.Controls.Add(label2);
            pnl_question.Location = new Point(213, 0);
            pnl_question.Name = "pnl_question";
            pnl_question.Size = new Size(855, 628);
            pnl_question.TabIndex = 3;
            // 
            // Frm_Instructor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1067, 629);
            Controls.Add(pnl_reports);
            Controls.Add(btn_reports);
            Controls.Add(pnl_question);
            Controls.Add(btn_Ques);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Frm_Instructor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_Instructor";
            Load += Frm_Instructor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg_questions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg_qOptions).EndInit();
            pnl_reports.ResumeLayout(false);
            pnl_reports.PerformLayout();
            pnl_question.ResumeLayout(false);
            pnl_question.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button btn_Ques;
        private Button btn_reports;
        private Label label2;
        private ComboBox comb_coursesName;
        private DataGridView dg_questions;
        private Button btn_save;
        private DataGridView dg_qOptions;
        private Label label3;
        private Label label4;
        private Panel pnl_reports;
        private ComboBox comb_studentsName;
        private Label label11;
        private Button button6;
        private ComboBox comb_departmentsName;
        private Label label10;
        private Button button5;
        private ComboBox comb_studentsNameGrades;
        private Label label9;
        private Button button4;
        private ComboBox comb_instructorsName;
        private Label label8;
        private Button button3;
        private Button button2;
        private ComboBox cmb_courseNmaeStuExam;
        private Label label5;
        private Button button1;
        private ComboBox cmb_courseNmae;
        private Label label7;
        private Panel pnl_question;
        private ComboBox comb_courseExamReport;
        private Label label6;
    }
}