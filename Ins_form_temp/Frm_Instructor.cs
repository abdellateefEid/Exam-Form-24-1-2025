using Exam_Form.Models;

namespace Exam_Form
{
    public partial class Frm_Instructor : Form
    {
        private Examination_Sys_Context _context;
        private Instructor? _instructor;

        private List<CourseInfo> _courseList;
        private List<CourseInfo> _courseListOfQuestions;

        public Frm_Instructor(Instructor? instructor)
        {
            InitializeComponent();
            _context = new Examination_Sys_Context();

            //_instructor = instructor;
            _instructor = _context.Instructors.FirstOrDefault(i => i.InstructorId == 1);
            //LoadData();
        }

        private void Frm_Instructor_Load(object sender, EventArgs e)
        {
            pnl_question.Visible = false;
            pnl_reports.Visible = false;

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

            dg_questions.Columns["QuestionHead"]!.Width = 300; // Set width to 150 pixels
            dg_questions.Columns["QuestionAnswer"]!.Width = 300; // Set width to 150 pixels
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //SaveChanges();
        }
        private void SaveChanges()
        {
            // Save changes back to the database
            //foreach (var entry in _context.ChangeTracker.Entries<Question>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Modified:
            //            // Update the record
            //            break;
            //        case EntityState.Added:
            //            // Insert new record
            //            break;
            //        case EntityState.Deleted:
            //            // Delete the record
            //            break;
            //    }
            //}

            _context.SaveChanges();
            MessageBox.Show("Changes saved successfully.");
        }

        private List<Question> questionsOfCourseSelected;
        private void comb_coursesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            questionsOfCourseSelected = _context.Questions
                .Where(q => q.Course.CourseId == _courseListOfQuestions[comb_coursesName.SelectedIndex].CourseId)
                .ToList();

            var questionsView = questionsOfCourseSelected
                .Select(q => new
                {
                    q.QuestionId,
                    q.QuestionHead,
                    q.QuestionAnswer,
                    q.QuestionType,
                    q.QuestionPoints
                })
                .ToList();

            dg_questions.DataSource = questionsView;
            //dg_questions.DataSource = questionsOfCourseSelected;

            ////Make the DataGridView editable
            dg_questions.AutoGenerateColumns = true;
            dg_questions.AllowUserToAddRows = true;
            dg_questions.AllowUserToDeleteRows = true;
            dg_questions.EditMode = DataGridViewEditMode.EditOnEnter;
            dg_questions.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);



            CustomizeDataGridView();
        }

        private void dg_questions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a row (not the header) is clicked
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dg_questions.Rows[e.RowIndex];

                // Retrieve the Question from the specific column (replace "QuestionTextColumn" with your column name)
                int questionId = (int)selectedRow.Cells["QuestionId"].Value;
                string questionType = selectedRow.Cells["QuestionType"].Value?.ToString() ?? "";

                if (questionType != String.Empty)
                {
                    var questionOptions = _context.QuestionOptions
                        .Where(qo => qo.QuestionId == questionId) // Filter rows where QuestionId equals 1
                        .Select(qo => new
                        {
                            qo.QuestionOption1
                        })
                        .ToList();

                    dg_qOptions.DataSource = questionOptions;
                    dg_qOptions.Columns["QuestionOption1"]!.Width = 420; // Set width to 150 pixels

                }

                //dg_qOptions.ReadOnly = false;
                //dg_qOptions.Columns["QuestionOption1"]!.ReadOnly = false;


                dg_qOptions.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

                // Customize header row
                dg_qOptions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                dg_qOptions.ColumnHeadersDefaultCellStyle.BackColor = Color.Azure;
                dg_qOptions.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void btn_Ques_Click(object sender, EventArgs e)
        {
            LoadQuestionsData();

            pnl_question.Visible = true;
            pnl_reports.Visible = false;
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            LoadReportsData();

            pnl_question.Visible = false;
            pnl_reports.Visible = true;
        }
        private int courseId_ofStudent_forExamReport;
        private void LoadReportsData()
        {
            //if (_instructor != null)
            //{
            // Populate Course Names
            //comb_coursesName.Items.Clear();
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
            comb_studentsName.Items.Clear();
            comb_studentsNameGrades.Items.Clear();
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
            // Populate Instructor Names
            comb_instructorsName.Items.Clear();
            var instructorList = GetInstructorNames();
            foreach (string instructor in instructorList)
            {
                comb_instructorsName.Items.Add(instructor);
            }

            // Populate Department Names
            comb_departmentsName.Items.Clear();
            var departmentList = GetDepartmentNames();
            foreach (string department in departmentList)
            {
                comb_departmentsName.Items.Add(department);
            }
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
                comb_studentsNameGrades.Items.Add(student.StudentName);
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int exam_id = _context.Exams.FirstOrDefault(e => e.CourseId == _courseList[comb_courseExamReport.SelectedIndex].CourseId).ExamId;
            Frm_GetExamQuestionsWithChoices frm_GetExamQuestionsWithChoices = new Frm_GetExamQuestionsWithChoices(exam_id);

            this.Hide();
            frm_GetExamQuestionsWithChoices.ShowDialog();
            this.Show();
        }
    }
}
