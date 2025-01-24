namespace Exam_Form
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            comboUserType = new ComboBox();
            pictureBox2 = new PictureBox();
            panelStu = new Panel();
            pictureBox3 = new PictureBox();
            lab_or = new Label();
            btn_register = new Button();
            btnLogStu = new Button();
            txtStuPass = new TextBox();
            label6 = new Label();
            label4 = new Label();
            txtStuUsername = new TextBox();
            lab_userType = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelStu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(575, 444);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(248, 279);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(155, 10);
            label1.Name = "label1";
            label1.Size = new Size(441, 38);
            label1.TabIndex = 1;
            label1.Text = "Exam Management System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(300, 75);
            label2.Name = "label2";
            label2.Size = new Size(154, 24);
            label2.TabIndex = 2;
            label2.Text = "Select User Type";
            // 
            // comboUserType
            // 
            comboUserType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboUserType.ForeColor = Color.Black;
            comboUserType.FormattingEnabled = true;
            comboUserType.Location = new Point(198, 102);
            comboUserType.Name = "comboUserType";
            comboUserType.Size = new Size(371, 29);
            comboUserType.TabIndex = 3;
            comboUserType.SelectedIndexChanged += comboUserType_SelectedIndexChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-72, 327);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(364, 477);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // panelStu
            // 
            panelStu.Controls.Add(pictureBox3);
            panelStu.Controls.Add(lab_or);
            panelStu.Controls.Add(btn_register);
            panelStu.Controls.Add(btnLogStu);
            panelStu.Controls.Add(txtStuPass);
            panelStu.Controls.Add(label6);
            panelStu.Controls.Add(label4);
            panelStu.Controls.Add(txtStuUsername);
            panelStu.Controls.Add(lab_userType);
            panelStu.Location = new Point(193, 172);
            panelStu.Name = "panelStu";
            panelStu.Size = new Size(383, 472);
            panelStu.TabIndex = 21;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(124, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(137, 92);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // lab_or
            // 
            lab_or.AutoSize = true;
            lab_or.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lab_or.ForeColor = Color.Blue;
            lab_or.Location = new Point(179, 368);
            lab_or.Name = "lab_or";
            lab_or.Size = new Size(25, 21);
            lab_or.TabIndex = 15;
            lab_or.Text = "or";
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.LimeGreen;
            btn_register.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btn_register.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_register.ForeColor = Color.White;
            btn_register.Location = new Point(46, 391);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(300, 39);
            btn_register.TabIndex = 14;
            btn_register.Text = "Register";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;
            // 
            // btnLogStu
            // 
            btnLogStu.BackColor = Color.LimeGreen;
            btnLogStu.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnLogStu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogStu.ForeColor = Color.White;
            btnLogStu.Location = new Point(46, 328);
            btnLogStu.Name = "btnLogStu";
            btnLogStu.Size = new Size(300, 39);
            btnLogStu.TabIndex = 13;
            btnLogStu.Text = "Login";
            btnLogStu.UseVisualStyleBackColor = false;
            btnLogStu.Click += btnLogStu_Click_1;
            // 
            // txtStuPass
            // 
            txtStuPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStuPass.Location = new Point(46, 252);
            txtStuPass.Name = "txtStuPass";
            txtStuPass.PasswordChar = '*';
            txtStuPass.Size = new Size(300, 29);
            txtStuPass.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(156, 229);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 11;
            label6.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(151, 157);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 8;
            label4.Text = "Username";
            // 
            // txtStuUsername
            // 
            txtStuUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStuUsername.Location = new Point(46, 180);
            txtStuUsername.Name = "txtStuUsername";
            txtStuUsername.Size = new Size(300, 29);
            txtStuUsername.TabIndex = 7;
            // 
            // lab_userType
            // 
            lab_userType.AutoSize = true;
            lab_userType.BackColor = Color.White;
            lab_userType.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lab_userType.Location = new Point(156, 94);
            lab_userType.Name = "lab_userType";
            lab_userType.Size = new Size(74, 24);
            lab_userType.TabIndex = 6;
            lab_userType.Text = "Student";
            // 
            // Frm_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(824, 752);
            Controls.Add(panelStu);
            Controls.Add(pictureBox2);
            Controls.Add(comboUserType);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Frm_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelStu.ResumeLayout(false);
            panelStu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private ComboBox comboUserType;
        private TextBox textBox2;
        private PictureBox pictureBox2;
        private Panel panelStu;
        private Label lab_or;
        private Button btn_register;
        private Button btnLogStu;
        private TextBox txtStuPass;
        private Label label6;
        private Label label4;
        private TextBox txtStuUsername;
        private Label lab_userType;
        private PictureBox pictureBox3;
    }
}
