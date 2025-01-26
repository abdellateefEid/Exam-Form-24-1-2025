
using Exam_Form.Models;

namespace Exam_Form
{
    public enum UserType
    {
        Student,
        Instructor
    }

    public partial class Frm_Login : Form
    {
        private Student? _student;
        private Instructor? _instructor;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void comboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUserType.SelectedIndex > -1)
            {
                pnl_user.Visible = true;
                pictureBox3.Visible = true;
            }

            if ((UserType)comboUserType.SelectedIndex == UserType.Student)
            {
                this.lab_userType.Text = UserType.Student.ToString();
                this.lab_or.Visible = true;
                this.btn_register.Visible = true;
                pictureBox3.Image = Image.FromFile("Images\\st-icon.jpg");

            }
            else if ((UserType)comboUserType.SelectedIndex == UserType.Instructor)
            {
                this.lab_userType.Text = UserType.Instructor.ToString();
                this.lab_or.Visible = false;
                this.btn_register.Visible = false;
                pictureBox3.Image = Image.FromFile("Images\\inst-icon.png");

            }


            // Set the PictureBox's SizeMode property to make the image fit
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Frm_Instructor _instructorPage;
        private Frm_Stu_Coures_Exam _stuCourseExam;
        private Frm_StuApplyProgram _StuApplyProgram;
        private Frm_Stu_Register _Frm_Regiser;

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pnl_user.Visible = false;

            comboUserType.Items.Add(UserType.Student.ToString());
            comboUserType.Items.Add(UserType.Instructor.ToString());
        }

        private void btnLogStu_Click_1(object sender, EventArgs e)
        {
            string username = this.txtStuUsername.Text.Trim();
            string password = this.txtStuPass.Text.Trim();

            using (var context = new Examination_Sys_Context())
            {
                var user = context.Users
                    .FirstOrDefault(t => t.UserName == username && t.Password == password);

                if (user != null)
                {
                    this.Hide();
                    if (Enum.TryParse(user.UserType.Trim(), out UserType userType))
                    {
                        if (userType == UserType.Student)
                        {

                            //string _studentEmail = context.Users.FirstOrDefault(u=> u.UserName == )
                            //_student = context.Students.Find(user.UserId);
                            _student = context.Students.FirstOrDefault(s => s.StudentEmail == user.Email);

                            if (_student != null)
                            {
                                _stuCourseExam = new Frm_Stu_Coures_Exam(_student);

                                _stuCourseExam.ShowDialog();
                            }
                            else
                            {
                                _StuApplyProgram = new Frm_StuApplyProgram();
                                _StuApplyProgram.ShowDialog();

                            }
                        }
                        else if (userType == UserType.Instructor)
                        {
                            _instructor = context.Instructors.FirstOrDefault(u => u.InstructorEmail == user.Email);

                            _instructorPage = new Frm_Instructor(_instructor);

                            _instructorPage.ShowDialog();
                        }
                    }

                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            _Frm_Regiser = new Frm_Stu_Register();

            this.Hide();
            _Frm_Regiser.ShowDialog();
            this.Show();
        }
    }
}





//using Exam_Form.Models;

//namespace Exam_Form
//{
//    public partial class Frm_Login : Form
//    {
//        public Frm_Login()
//        {
//            InitializeComponent();
//        }

//        private void comboUserType_SelectedIndexChanged(object sender, EventArgs e)
//        {

//            if (comboUserType.SelectedIndex > -1)
//            {
//                panelStu.Visible = true;
//            }
//            if (comboUserType.SelectedIndex == 0)
//            {
//                this.lab_userType.Text = "Student";
//                this.lab_or.Visible = true;
//                this.btn_register.Visible = true;
//            }
//            else if (comboUserType.SelectedIndex == 1)
//            {
//                this.lab_userType.Text = "Instructor";
//                this.lab_or.Visible = false;
//                this.btn_register.Visible = false;

//            }

//        }
//        private Frm_Instructor _instructorPage;

//        private Frm_Stu_Coures_Exam _stuCourseExam;

//        private Frm_Stu_Register _Frm_Regiser;
//        private void FrmLogin_Load(object sender, EventArgs e)
//        {

//            panelStu.Visible = false;

//            comboUserType.Items.Add("Student");
//            comboUserType.Items.Add("Instructor");

//            _instructorPage = new Frm_Instructor();
//            _stuCourseExam = new Frm_Stu_Coures_Exam();
//            _Frm_Regiser = new Frm_Stu_Register();

//        }


//        private void btnLogStu_Click_1(object sender, EventArgs e)
//        {
//            string username = this.txtStuUsername.Text.Trim();
//            string password = this.txtStuPass.Text.Trim();

//            using (var context = new Examination_Sys_Context())
//            {
//                var user = context.Users
//                    .FirstOrDefault(t => t.UserName == username && t.Password == password);

//                if (user != null)
//                {
//                    this.Hide();
//                    if (user.UserType.Trim() == "student")
//                    {
//                        _stuCourseExam.ShowDialog();

//                    }
//                    else if (user.UserType.Trim() == "instructor")
//                    {
//                        _instructorPage.ShowDialog();

//                    }

//                    //this.Visible = true;
//                    //OR
//                    //MessageBox.Show("username and password", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);

//                    Application.Exit();
//                }
//                else
//                {
//                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        private void btn_register_Click(object sender, EventArgs e)
//        {
//            this.Hide();
//            _Frm_Regiser.ShowDialog();
//            this.Show();
//        }
//    }
//}
