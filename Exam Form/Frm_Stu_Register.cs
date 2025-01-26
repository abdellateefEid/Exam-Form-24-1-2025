using Exam_Form.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_Form
{
    public partial class Frm_Stu_Register : Form
    {
        public Frm_Stu_Register()
        {
            InitializeComponent();
        }
        private async void btn_submit_Click(object sender, EventArgs e)
        {
            // Validate that all text boxes are filled
            if (string.IsNullOrWhiteSpace(txtStuname.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txtPass.Text != this.txtConPass.Text)
            {
                MessageBox.Show("Not same password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new Examination_Sys_Context())
            {
                // Check if the email already exists in the database
                var emailExists = await context.Users.AnyAsync(u => u.Email == txtEmail.Text);
                if (emailExists)
                {
                    MessageBox.Show("This email is already has account.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the same username and password combination already exists
                var usernamePasswordExists = await context.Users.AnyAsync(u => u.UserName == txtStuname.Text && u.Password == txtPass.Text);
                if (usernamePasswordExists)
                {
                    MessageBox.Show("Username and Uassword combination already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new user and save to the database
                var newUser = new User
                {
                    UserName = txtStuname.Text,
                    Password = txtPass.Text,
                    UserType = "Student",
                    Email = txtEmail.Text
                };

                context.Users.Add(newUser);
                await context.SaveChangesAsync();

                MessageBox.Show("Account created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void Frm_Stu_Register_Load(object sender, EventArgs e)
        {

        }

        //private async void btn_submit_Click(object sender, EventArgs e)
        //{

        //    using (var context = new Examination_Sys_Context())
        //    {
        //        var newUser = new User
        //        {
        //            UserName = this.txtStuname.Text,
        //            Password = this.txtPass.Text,
        //            UserType = "student",
        //            Email = this.txtEmail.Text
        //            //UserName = "yousef eid",
        //            //Password = "789",
        //            //UserType = "student",
        //            //Email = "yousefeid@gmail.com"
        //        };

        //        context.Users.Add(newUser);
        //        await context.SaveChangesAsync();

        //        this.Close();
        //        //Console.WriteLine("User inserted successfully.");
        //    }
        //}
    }
}
