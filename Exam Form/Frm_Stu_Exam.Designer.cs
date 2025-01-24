namespace Exam_Form
{
    partial class Frm_Stu_Exam
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
            panel1 = new Panel();
            lab_ans = new Label();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            lab_submit = new Label();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            btn_nxt = new Button();
            btn_pre = new Button();
            lab_heahOfQuesion = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            btn_submit = new Button();
            btn_colse = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lab_ans);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btn_nxt);
            panel1.Controls.Add(btn_pre);
            panel1.Controls.Add(lab_heahOfQuesion);
            panel1.Location = new Point(74, 111);
            panel1.Name = "panel1";
            panel1.Size = new Size(836, 352);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lab_ans
            // 
            lab_ans.AutoSize = true;
            lab_ans.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lab_ans.Location = new Point(73, 255);
            lab_ans.Name = "lab_ans";
            lab_ans.Size = new Size(41, 25);
            lab_ans.TabIndex = 3;
            lab_ans.Text = "ans";
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(lab_submit);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(70, 65);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(764, 173);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI", 14.25F);
            radioButton4.Location = new Point(6, 127);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(14, 13);
            radioButton4.TabIndex = 3;
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // lab_submit
            // 
            lab_submit.AutoSize = true;
            lab_submit.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_submit.ForeColor = Color.FromArgb(0, 192, 0);
            lab_submit.Location = new Point(204, 60);
            lab_submit.Name = "lab_submit";
            lab_submit.Size = new Size(242, 45);
            lab_submit.TabIndex = 4;
            lab_submit.Text = "sumited or not";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe UI", 14.25F);
            radioButton3.Location = new Point(6, 92);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(14, 13);
            radioButton3.TabIndex = 2;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 14.25F);
            radioButton2.Location = new Point(6, 57);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 1;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 14.25F);
            radioButton1.Location = new Point(6, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 0;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // btn_nxt
            // 
            btn_nxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_nxt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_nxt.Location = new Point(636, 297);
            btn_nxt.Name = "btn_nxt";
            btn_nxt.Size = new Size(197, 38);
            btn_nxt.TabIndex = 1;
            btn_nxt.Text = "Next";
            btn_nxt.UseVisualStyleBackColor = true;
            btn_nxt.Click += btn_nxt_Click;
            // 
            // btn_pre
            // 
            btn_pre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_pre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_pre.Location = new Point(73, 297);
            btn_pre.Name = "btn_pre";
            btn_pre.Size = new Size(186, 38);
            btn_pre.TabIndex = 2;
            btn_pre.Text = "Previous";
            btn_pre.UseVisualStyleBackColor = true;
            btn_pre.Click += btn_pre_Click;
            // 
            // lab_heahOfQuesion
            // 
            lab_heahOfQuesion.AutoSize = true;
            lab_heahOfQuesion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_heahOfQuesion.Location = new Point(36, 23);
            lab_heahOfQuesion.Name = "lab_heahOfQuesion";
            lab_heahOfQuesion.Size = new Size(26, 25);
            lab_heahOfQuesion.TabIndex = 1;
            lab_heahOfQuesion.Text = "Q";
            // 
            // btn_submit
            // 
            btn_submit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.FromArgb(0, 192, 0);
            btn_submit.Location = new Point(811, 67);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(136, 38);
            btn_submit.TabIndex = 3;
            btn_submit.Text = "Submit";
            btn_submit.UseVisualStyleBackColor = true;
            btn_submit.Click += button1_Click;
            // 
            // btn_colse
            // 
            btn_colse.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_colse.ForeColor = Color.Red;
            btn_colse.Location = new Point(52, 67);
            btn_colse.Name = "btn_colse";
            btn_colse.Size = new Size(136, 38);
            btn_colse.TabIndex = 5;
            btn_colse.Text = "Close";
            btn_colse.UseVisualStyleBackColor = true;
            btn_colse.Click += btn_colse_Click;
            // 
            // Frm_Stu_Exam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1003, 557);
            ControlBox = false;
            Controls.Add(btn_colse);
            Controls.Add(btn_submit);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Frm_Stu_Exam";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_Stu_Exam";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            Load += Frm_Stu_Exam_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_nxt;
        private Button btn_pre;
        private Label lab_heahOfQuesion;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label lab_ans;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button btn_submit;
        private Label lab_submit;
        private Button btn_colse;
    }
}
