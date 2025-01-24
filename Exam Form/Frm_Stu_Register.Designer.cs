namespace Exam_Form
{
    partial class Frm_Stu_Register
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
            btn_submit = new Button();
            txtPass = new TextBox();
            label4 = new Label();
            txtStuname = new TextBox();
            txtConPass = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.FromArgb(0, 0, 192);
            btn_submit.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btn_submit.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.White;
            btn_submit.Location = new Point(297, 365);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(163, 39);
            btn_submit.TabIndex = 15;
            btn_submit.Text = "Sign in";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.Location = new Point(320, 192);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(300, 29);
            txtPass.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(169, 65);
            label4.Name = "label4";
            label4.Size = new Size(71, 24);
            label4.TabIndex = 17;
            label4.Text = "Name:";
            // 
            // txtStuname
            // 
            txtStuname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStuname.Location = new Point(258, 64);
            txtStuname.Name = "txtStuname";
            txtStuname.Size = new Size(300, 29);
            txtStuname.TabIndex = 16;
            // 
            // txtConPass
            // 
            txtConPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConPass.Location = new Point(369, 259);
            txtConPass.Name = "txtConPass";
            txtConPass.PasswordChar = '*';
            txtConPass.Size = new Size(300, 29);
            txtConPass.TabIndex = 21;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(288, 129);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 29);
            txtEmail.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(168, 264);
            label1.Name = "label1";
            label1.Size = new Size(183, 24);
            label1.TabIndex = 23;
            label1.Text = "Confirm password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(167, 197);
            label2.Name = "label2";
            label2.Size = new Size(106, 24);
            label2.TabIndex = 24;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(168, 130);
            label3.Name = "label3";
            label3.Size = new Size(68, 24);
            label3.TabIndex = 25;
            label3.Text = "Email:";
            // 
            // Frm_Stu_Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtConPass);
            Controls.Add(txtPass);
            Controls.Add(label4);
            Controls.Add(txtStuname);
            Controls.Add(btn_submit);
            Name = "Frm_Stu_Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frm_Stu_Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_submit;
        private TextBox txtPass;
        private Label label4;
        private TextBox txtStuname;
        private TextBox txtConPass;
        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}