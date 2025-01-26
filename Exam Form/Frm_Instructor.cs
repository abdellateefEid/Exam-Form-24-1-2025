using Exam_Form.Models;
using System.ComponentModel;

namespace Exam_Form
{
    public partial class Frm_Instructor : Form
    {
        private Examination_Sys_Context _context;
        private Instructor? _instructor;
        private bool _instructor_is_managger;

        private List<CourseInfo> _courseList;
        private List<CourseInfo> _courseListOfQuestions;

        public Frm_Instructor(Instructor? instructor)
        {
            InitializeComponent();
            _context = new Examination_Sys_Context();

            //_instructor = instructor;
            _instructor = _context.Instructors.FirstOrDefault(i => i.InstructorId == 1);

            _instructor_is_managger = _context.Departments
                    .Any(d => d.ManagerId == _instructor.InstructorId); // Check if any department has this instructor as a manager

            //LoadData();
        }

        private void Frm_Instructor_Load(object sender, EventArgs e)
        {
            pnl_question.Visible = false;
            pnl_reports.Visible = false;
            lab_instName.Text = _instructor.InstructorName;
        }

        private void LoadQuestionsData()
        {
            if (_instructor != null)
            {
                _courseListOfQuestions = GetCourseNamesByInstructorIdForQuestions(_instructor.InstructorId);
                foreach (var c in _courseListOfQuestions)
                {
                    comb_coursesName.Items.Add(c.CourseName);

                }
            }

            // Load data from database

        }
        public class CourseInfo
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
        }

        public List<CourseInfo> GetCourseNamesByInstructorIdForQuestions(int instructorId)
        {
            var _courseList = _context.Instructors
                .Where(i => i != null && i.InstructorId == instructorId)
                .SelectMany(i => i.Courses)
                .Select(c => new CourseInfo { CourseId = c.CourseId, CourseName = c.CourseName })
                .ToList();

            return _courseList;
        }

        private void CustomizeDataGridView()
        {
            // Set default font for all cells
            dg_questions.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Customize header row
            dg_questions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dg_questions.ColumnHeadersDefaultCellStyle.BackColor = Color.Azure;
            dg_questions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;

            // Disable default styles to allow custom header styles to take effect
            dg_questions.EnableHeadersVisualStyles = false;

            // Set row style (optional)
            dg_questions.RowsDefaultCellStyle.BackColor = Color.White;
            dg_questions.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

            dg_questions.Columns["QuestionHead"]!.Width = 400; // Set width to 150 pixels
            dg_questions.Columns["QuestionType"]!.Width = 60; // Set width to 150 pixels
            dg_questions.Columns["QuestionAnswer"]!.Width = 400; // Set width to 150 pixels

            dg_questions.Columns["QuestionId"].Visible = false;  // This hides the column in the UI
            dg_questions.Columns["CourseId"].Visible = false;  // This hides the column in the UI
            dg_questions.Columns["Course"].Visible = false;  // This hides the column in the UI
            dg_questions.Columns["QuestionOptions"].Visible = false;  // This hides the column in the UI
            dg_questions.Columns["StudentAnswers"].Visible = false;  // This hides the column in the UI



            foreach (DataGridViewColumn column in dg_questions.Columns)
            {
                column.ReadOnly = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //SaveChanges();
            try
            {
                // Save changes to the database
                _context.SaveChanges();
                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}");
            }
        }
        //private void SaveChanges()
        //{
        //    // Save changes back to the database
        //    //foreach (var entry in _context.ChangeTracker.Entries<Question>())
        //    //{
        //    //    switch (entry.State)
        //    //    {
        //    //        case EntityState.Modified:
        //    //            // Update the record
        //    //            break;
        //    //        case EntityState.Added:
        //    //            // Insert new record
        //    //            break;
        //    //        case EntityState.Deleted:
        //    //            // Delete the record
        //    //            break;
        //    //    }
        //    //}

        //    _context.SaveChanges();
        //    MessageBox.Show("Changes saved successfully.");
        //}

        private List<Question> questionsOfCourseSelected;
        private void comb_coursesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comb_coursesName.SelectedIndex >= 0)
            {
                // Fetch questions for the selected course
                questionsOfCourseSelected = _context.Questions
                    .Where(q => q.Course.CourseId == _courseListOfQuestions[comb_coursesName.SelectedIndex].CourseId)
                    .ToList();

                // Bind to DataGridView with editable binding list
                dg_questions.DataSource = new BindingList<Question>(questionsOfCourseSelected);

                // Enable editing and configure DataGridView properties
                dg_questions.AllowUserToAddRows = true;
                dg_questions.AllowUserToDeleteRows = true;
                dg_questions.EditMode = DataGridViewEditMode.EditOnEnter;

                CustomizeDataGridView();
            }
        }
        //private void comb_coursesName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    questionsOfCourseSelected = _context.Questions
        //        .Where(q => q.Course.CourseId == _courseListOfQuestions[comb_coursesName.SelectedIndex].CourseId)
        //        .ToList();

        //    var questionsView = questionsOfCourseSelected
        //        .Select(q => new
        //        {
        //            q.QuestionId,
        //            q.QuestionHead,
        //            q.QuestionAnswer,
        //            q.QuestionType,
        //            q.QuestionPoints
        //        })
        //        .ToList();

        //    dg_questions.DataSource = questionsView;
        //    //dg_questions.DataSource = questionsOfCourseSelected;

        //    ////Make the DataGridView editable
        //    dg_questions.AutoGenerateColumns = true;
        //    dg_questions.AllowUserToAddRows = true;
        //    dg_questions.AllowUserToDeleteRows = true;
        //    dg_questions.EditMode = DataGridViewEditMode.EditOnEnter;
        //    dg_questions.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);



        //    CustomizeDataGridView();
        //}

        private void dg_questions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row in dg_questions
                DataGridViewRow selectedRow = dg_questions.Rows[e.RowIndex];
                int questionId = (int)selectedRow.Cells["QuestionId"].Value;

                // Fetch options for the selected question
                var questionOptions = _context.QuestionOptions
                    .Where(qo => qo.QuestionId == questionId)
                    .ToList();

                // Bind options data to dg_qOptions
                dg_qOptions.DataSource = new BindingList<QuestionOption>(questionOptions);

                // Enable editing mode and set grid properties
                dg_qOptions.AllowUserToAddRows = true;
                dg_qOptions.AllowUserToDeleteRows = true;
                dg_qOptions.EditMode = DataGridViewEditMode.EditOnEnter;

                CustomizeOptionsDataGridView();  // Ensure customization is applied
            }
        }

        private void btn_Ques_Click(object sender, EventArgs e)
        {
            LoadQuestionsData();

            pnl_question.Visible = true;
            pnl_reports.Visible = false;
            pictureBox2.Visible = false;
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            LoadReportsData();

            pnl_question.Visible = false;
            pnl_reports.Visible = true;
            pictureBox2.Visible = false;

        }
        private int courseId_ofStudent_forExamReport;
        private List<StudentInfo> _students_;
        private void LoadReportsData()
        {
            //if (_instructor != null)
            //{
            // Populate Course Names
            comb_coursesName.Items.Clear();
            cmb_courseNmae.Items.Clear();
            cmb_courseNmaeStuExam.Items.Clear();
            comb_courseExamReport.Items.Clear();
            _courseList = GetCoursesByInstructorId(_instructor.InstructorId);
            foreach (var c in _courseList)
            {
                cmb_courseNmae.Items.Add(c.CourseName);
                cmb_courseNmaeStuExam.Items.Add(c.CourseName);
                comb_courseExamReport.Items.Add(c.CourseName);

            }
            //}

            // Populate Student Names
            //comb_studentsName.Items.Clear();
            comb_studentsNameGrades.Items.Clear();

            _students_ = GetStudentsByInstructorId(_instructor.InstructorId);
            foreach (var s in _students_)
            {
                comb_studentsNameGrades.Items.Add(s.StudentName);

            }

            //if (cmb_courseNmaeStuExam.SelectedIndex > -1)
            //{
            //    courseId_ofStudent_forExamReport = _courseList[cmb_courseNmaeStuExam.SelectedIndex].CourseId;
            //    var studentList = GetStudentNames(courseId_ofStudent_forExamReport);
            //    foreach (var student in studentList)
            //    {
            //        comb_studentsName.Items.Add(student.StudentName);
            //        comb_studentsNameGrades.Items.Add(student.StudentName);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please choise the course name first", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

            /********************************
            // Populate Exam IDs
            comb_examId.Items.Clear();
            var examList = GetExamIds();
            foreach (string examId in examList)
            {
                comb_examId.Items.Add(examId);
            }
            ************************************/


            //// Populate Department Names
            //comb_departmentsName.Items.Clear();
            //var departmentList = GetDepartmentNames();
            //foreach (string department in departmentList)
            //{
            //    comb_departmentsName.Items.Add(department);
            //}
        }
        public List<StudentInfo> GetStudentsByInstructorId(int instructorId)
        {
            return _context.Students
                .Where(s => s.StudentCourses
                    .Any(sc => sc.Course.Instructors
                        .Any(ci => ci.InstructorId == instructorId))) // Navigate through join tables
                .Select(s => new StudentInfo
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName
                })
                .Distinct() // Ensure unique students
                .ToList();
        }


        // Fetch Course Names by Instructor ID
        private List<CourseInfo> GetCoursesByInstructorId(int instructorId)
        {
            return _context.Instructors
                .Where(i => _instructor != null && i.InstructorId == instructorId)
                .SelectMany(i => i.Courses)
                .Select(c => new CourseInfo
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName
                })
                .ToList();
        }


        public class StudentInfo
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
        }
        // Fetch Student Names
        public List<StudentInfo> GetStudentNames(int courseId)
        {

            return _context.Students
        .Where(s => s.StudentCourses.Any(c => c.CourseId == courseId)) // Filter students by courseId
        .Select(s => new StudentInfo
        {
            StudentId = s.StudentId,
            StudentName = s.StudentName
        })
        .ToList();
        }

        // Fetch Exam IDs
        public List<string> GetExamIds()
        {
            return _context.Exams
                .Select(e => e.ExamId.ToString())
                .ToList();
        }

        // Fetch Instructor Names
        public List<string> GetInstructorNames()
        {
            return _context.Instructors
                .Select(i => i.InstructorName)
                .ToList();
        }

        // Fetch Department Names
        public List<string> GetDepartmentNames()
        {
            return _context.Departments
                .Select(d => d.DepartmentName)
                .ToList();
        }

        private int courseIndex_of_cmb_courseNmae = -1;
        private string courseName_of_cmb_courseNmae = "";
        private void cmb_courseNmae_SelectedIndexChanged(object sender, EventArgs e)
        {
            courseIndex_of_cmb_courseNmae = cmb_courseNmae.SelectedIndex;
            courseName_of_cmb_courseNmae = cmb_courseNmae.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (courseIndex_of_cmb_courseNmae > -1)
            {
                this.Hide();
                int course_id = _context.Courses.FirstOrDefault(c => c.CourseId == _courseList[cmb_courseNmae.SelectedIndex].CourseId).CourseId;
                Frm_GetCourseTopics frm_GetCourseTopics = new Frm_GetCourseTopics(course_id);
                frm_GetCourseTopics.ShowDialog();

                this.Show();
            }
            else
            {
                MessageBox.Show("Please choise the course name first", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //private int courseIndex_of_cmb_courseNmaeStuExam = -1;
        //private string courseName_of_cmb_courseNmaeStuExam = "";
        private List<StudentInfo> __studentList;
        private void cmb_courseNmaeStuExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //courseIndex_of_cmb_courseNmaeStuExam = cmb_courseNmaeStuExam.SelectedIndex;
            //courseName_of_cmb_courseNmaeStuExam = cmb_courseNmaeStuExam.Text;
            courseId_ofStudent_forExamReport = _courseList[cmb_courseNmaeStuExam.SelectedIndex].CourseId;
            __studentList = GetStudentNames(courseId_ofStudent_forExamReport);
            comb_studentsName.Items.Clear();
            comb_studentsName.Text = "";
            foreach (var student in __studentList)
            {
                comb_studentsName.Items.Add(student.StudentName);
                //comb_studentsNameGrades.Items.Add(student.StudentName);
            }
        }

        private int courseIndex_of_cmb_courseNmaeStuExam = -1;

        private void comb_studentsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmb_courseNmaeStuExam.SelectedIndex > -1))
            {

                MessageBox.Show("Please choise the course name first", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cmb_courseNmaeStuExam.SelectedIndex > -1 & comb_studentsName.SelectedIndex > -1)
            {
                this.Hide();
                //int course_id = _context.Courses.FirstOrDefault(c => c.CourseName == courseName_of_cmb_courseNmaeStuExam).CourseId;
                int exam_id = _context.Exams.FirstOrDefault(e => e.CourseId == _courseList[cmb_courseNmaeStuExam.SelectedIndex].CourseId).ExamId;
                int stu_id = __studentList[comb_studentsName.SelectedIndex].StudentId;
                Frm_GetExamQuestionsWithAnswers frm_GetStudentExam = new Frm_GetExamQuestionsWithAnswers(exam_id, stu_id);
                frm_GetStudentExam.ShowDialog();

                this.Show();
            }
            else
            {
                MessageBox.Show("Please choise both course name and student name", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comb_studentsNameGrades.SelectedIndex > -1)
            {
                Frm_GetStudentGrades frm_GetStudentGrades = new Frm_GetStudentGrades(____stuId);
                this.Hide();
                frm_GetStudentGrades.ShowDialog();
                this.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int exam_id = _context.Exams.FirstOrDefault(e => e.CourseId == _courseList[comb_courseExamReport.SelectedIndex].CourseId).ExamId;
            Frm_GetExamQuestionsWithChoices frm_GetExamQuestionsWithChoices = new Frm_GetExamQuestionsWithChoices(exam_id);

            this.Hide();
            frm_GetExamQuestionsWithChoices.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int instId = _instructor.InstructorId;

            Frm_GetInstructorCourses frm_GetInstructorCourses = new Frm_GetInstructorCourses(instId);

            this.Hide();
            frm_GetInstructorCourses.ShowDialog();
            this.Show();
        }

        private int ____stuId;
        private void comb_studentsNameGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ____stuId = _students_[comb_studentsNameGrades.SelectedIndex].StudentId;
        }

        private void pnl_question_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dg_questions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Retrieve updated row
                DataGridViewRow row = dg_questions.Rows[e.RowIndex];
                int questionId = (int)row.Cells["QuestionId"].Value;

                // Find the corresponding Question object
                var question = questionsOfCourseSelected.FirstOrDefault(q => q.QuestionId == questionId);
                if (question != null)
                {
                    question.QuestionHead = row.Cells["QuestionHead"].Value?.ToString() ?? "";
                    question.QuestionAnswer = row.Cells["QuestionAnswer"].Value?.ToString() ?? "";
                    question.QuestionPoints = Convert.ToInt32(row.Cells["QuestionPoints"].Value ?? 0);
                }
            }
        }



        private void dg_questions_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_questions.SelectedRows.Count > 0)
            {
                // Get the selected question's ID
                int selectedQuestionId = (int)dg_questions.SelectedRows[0].Cells["QuestionId"].Value;

                // Fetch options for the selected question
                var optionsOfSelectedQuestion = _context.QuestionOptions
                    .Where(o => o.QuestionId == selectedQuestionId)
                    .ToList();

                // Bind to DataGridView with editable binding list
                dg_qOptions.DataSource = new BindingList<QuestionOption>(optionsOfSelectedQuestion);

                // Enable editing and configure DataGridView properties
                //dg_qOptions.AllowUserToAddRows = true;
                //dg_qOptions.AllowUserToDeleteRows = true;
                //dg_qOptions.EditMode = DataGridViewEditMode.EditOnEnter;

                CustomizeOptionsDataGridView();
            }
        }
        private void CustomizeOptionsDataGridView()
        {
            // Set general properties for DataGridView
            dg_qOptions.AutoGenerateColumns = false;  // Disable auto-generating columns
            dg_qOptions.AllowUserToAddRows = false;
            dg_qOptions.AllowUserToDeleteRows = false;
            dg_qOptions.EditMode = DataGridViewEditMode.EditOnEnter;

            // Set the default font for all cells
            dg_qOptions.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            // Set the row height
            dg_qOptions.RowTemplate.Height = 35;  // Set a comfortable row height

            // Set the background color for rows
            dg_qOptions.RowsDefaultCellStyle.BackColor = Color.White;
            dg_qOptions.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;

            // Customize column headers

            dg_qOptions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dg_qOptions.ColumnHeadersDefaultCellStyle.BackColor = Color.Azure;
            dg_qOptions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;

            dg_qOptions.EnableHeadersVisualStyles = false;

            // Adjust column widths for better readability
            dg_qOptions.Columns["QuestionOption1"].Width = 550;  // Set width of the first column
            dg_qOptions.Columns["QuestionOption1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // You can adjust the width of other columns similarly
            // For example:
            //dg_qOptions.Columns["QuestionId"].Width = 50;  // If you have more columns
            dg_qOptions.Columns["QuestionId"].Visible = false;  // This hides the column in the UI
            dg_qOptions.Columns["Question"].Visible = false;  // This hides the column in the UI

            // Allow editing of individual cells
            dg_qOptions.ReadOnly = false;

            // Make sure columns are not read-only
            foreach (DataGridViewColumn column in dg_qOptions.Columns)
            {
                column.ReadOnly = false;
            }

            // Optional: Add borders to the cells
            dg_qOptions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
        //private void dg_qOptions_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Ensure a row (not header) is clicked
        //    if (e.RowIndex >= 0)
        //    {
        //        // Retrieve the QuestionId and QuestionOption1 from the selected row
        //        DataGridViewRow selectedRow = dg_qOptions.Rows[e.RowIndex];
        //        int questionId = (int)selectedRow.Cells["QuestionId"].Value;
        //        string optionValue = selectedRow.Cells["QuestionOption1"].Value?.ToString();

        //        // Now you can access the selected row data and apply any additional logic
        //    }
        //}
        //private void CustomizeOptionsDataGridView()
        //{
        //    // Ensure all columns are editable
        //    foreach (DataGridViewColumn column in dg_qOptions.Columns)
        //    {
        //        column.ReadOnly = false;  // Make sure no column is read-only
        //    }

        //    // Optionally, customize other appearance settings for the DataGridView
        //    dg_qOptions.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
        //    dg_qOptions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        //    dg_qOptions.ColumnHeadersDefaultCellStyle.BackColor = Color.Azure;
        //    dg_qOptions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
        //}


        private void dg_qOptions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Retrieve updated row
                DataGridViewRow row = dg_qOptions.Rows[e.RowIndex];
                int questionId = (int)row.Cells["QuestionId"].Value;
                string optionValue = row.Cells["QuestionOption1"].Value?.ToString();

                // Find the corresponding QuestionOption object
                var option = ((BindingList<QuestionOption>)dg_qOptions.DataSource)
                    .FirstOrDefault(o => o.QuestionId == questionId && o.QuestionOption1 == optionValue);

                if (option != null)
                {
                    option.QuestionOption1 = row.Cells["QuestionOption1"].Value?.ToString() ?? "";
                }

                // Save changes to the context
                _context.SaveChanges();
            }
        }

    }
}
