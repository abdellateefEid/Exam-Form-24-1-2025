using Exam_Form.Models;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_Stu_Exam : Form
    {
        private readonly Examination_Sys_Context _context;
        private List<GenerateExamThenInsertItResult> _questions;

        private int[] _questionOptionRadioIndex;
        private string[] _questionsAnswer;
        private int _currentIndex;
        private int _courseId; // Replace with your desired Course_Id
        private int _examId; // Replace with your desired Course_Id
        private int _studentId; // Replace with your desired Course_Id
        public Frm_Stu_Exam(int studentId, int courseId, int examId)
        {
            _studentId = studentId;
            _courseId = courseId;
            _examId = examId;
            InitializeComponent();
            _context = new Examination_Sys_Context();
        }

        private async void Frm_Stu_Exam_Load(object sender, EventArgs e)
        {
            this.lab_submit.Visible = false;
            this.btn_colse.Visible = false;

            int numQuestions = 10; // Replace with your desired number of questions

            // Dynamically allocate arrays based on numQuestions
            _questionOptionRadioIndex = new int[numQuestions];
            _questionsAnswer = new string[numQuestions];
            Array.Fill(_questionOptionRadioIndex, -1);

            _currentIndex = 0;
            await LoadQuestions(_courseId, _studentId, _examId);
        }

        private async Task LoadQuestions(int courseId, int studentId, int examId)
        {
            try
            {

                // Fetch questions using the stored procedure
                _questions = await _context.Procedures.GenerateExamThenInsertItAsync(courseId, studentId, examId);

                if (_questions != null && _questions.Count > 0)
                {
                    _currentIndex = 0;
                    DisplayQuestion(_currentIndex);
                }
                else
                {
                    MessageBox.Show("No questions found for the given course and number of questions.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayQuestion(int index)
        {
            if (_currentIndex == 0)
                this.btn_pre.Visible = false;
            else
            {
                this.btn_pre.Visible = true;
            }
            if (_currentIndex == 9)
                this.btn_nxt.Visible = false;
            else
            {
                this.btn_nxt.Visible = true;
            }

            if (_questionsAnswer[index] != String.Empty)
            {
                this.lab_ans.Text = _questionsAnswer[index];
            }


            if (_questions == null || index < 0 || index >= _questions.Count)
                return;

            ClearRadioButtons();

            var question = _questions[index];
            var questionOptions = _context.QuestionOptions
                .Where(qo => qo.QuestionId == question.Question_Id)
                .ToList();

            this.lab_heahOfQuesion.Text = $"Q{index + 1}: {question.Question_Head}";

            if (question.Question_Type == "mcq")
            {
                radioButton1.Text = questionOptions.Count > 0 ? questionOptions[0].QuestionOption1 : string.Empty;
                radioButton2.Text = questionOptions.Count > 1 ? questionOptions[1].QuestionOption1 : string.Empty;
                radioButton3.Visible = questionOptions.Count > 2;
                radioButton4.Visible = questionOptions.Count > 3;

                if (radioButton3.Visible) radioButton3.Text = questionOptions[2].QuestionOption1;
                if (radioButton4.Visible) radioButton4.Text = questionOptions[3].QuestionOption1;
            }
            else
            {
                radioButton1.Text = "True";
                radioButton2.Text = "False";
                radioButton3.Visible = false;
                radioButton4.Visible = false;
            }

            // Restore the selected answer if available
            if (_questionOptionRadioIndex[index] > -1)
            {
                var radioButtons = groupBox1.Controls.OfType<RadioButton>().ToList();
                radioButtons[_questionOptionRadioIndex[index]].Checked = true;
            }
        }

        private void btn_nxt_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();

            if (_questions == null || _currentIndex >= _questions.Count - 1)
                return;

            _currentIndex++;
            DisplayQuestion(_currentIndex);
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();

            if (_questions == null || _currentIndex <= 0)
                return;

            _currentIndex--;
            DisplayQuestion(_currentIndex);
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            SaveCurrentAnswer();

            // Prepare answers for the stored procedure call
            DataTable answerTable = CreateAnswerDataTable();

            // Call the stored procedure to grade the exam
            try
            {
                List<CorrectExamResult> totalGrade = await _context.Procedures.CorrectExamAsync(_studentId, _examId, answerTable);
                //MessageBox.Show($"Your total grade is: {totalGrade[0].TotalGrade}", "Exam Graded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Set Student Grade in Exam
                var entity = _context.StudentCourses.FirstOrDefault(sc => sc.StudentId == _studentId && sc.CourseId == _courseId);

                if (entity != null)
                {
                    entity.StudentCourseGrade = totalGrade[0].TotalGrade;

                    await _context.SaveChangesAsync();
                }

                this.btn_submit.Visible = false;
                this.lab_submit.Visible = true;
                this.btn_colse.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.panel1.Visible = false;
            this.lab_submit.Text = @"your answers submitted successfully....!";


            /*
             ALTER PROCEDURE [dbo].[CorrectExam]
                   @Student_Id INT,
                   @Exam_Id INT,
                   @Answers AnswerTable READONLY -- Table parameter for the answers
               AS
               BEGIN
                   -- Loop through each student's answer and update the Student_Answer table
                   UPDATE SA
                   SET SA.Student_Que_Grade = CASE 
                                               WHEN A.Student_Ans = Q.Question_Answer THEN Q.Question_Points
                                               ELSE 0 
                                             END
                   FROM Student_Answer SA
                   INNER JOIN Question Q ON SA.Question_Id = Q.Question_Id
                   INNER JOIN @Answers A ON A.Question_Id = SA.Question_Id
                   WHERE SA.Student_Id = @Student_Id AND SA.Exam_Id = @Exam_Id;
               
                   -- Optionally, calculate and return the total grade for reference
                   SELECT SUM(Student_Que_Grade) AS TotalGrade
                   FROM Student_Answer
                   WHERE Student_Id = @Student_Id AND Exam_Id = @Exam_Id;
               END;
             */
            //_questions[0].Course_Id
            //_courseId
            //_examId
        }

        private void SaveCurrentAnswer()
        {
            var radioButtons = groupBox1.Controls.OfType<RadioButton>().ToList();

            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].Visible && radioButtons[i].Checked)
                {
                    _questionOptionRadioIndex[_currentIndex] = i;
                    _questionsAnswer[_currentIndex] = radioButtons[i].Text;
                    break;
                }
            }
        }

        private void ClearRadioButtons()
        {
            foreach (var radioButton in groupBox1.Controls.OfType<RadioButton>())
            {
                radioButton.Checked = false;
            }
        }

        private DataTable CreateAnswerDataTable()
        {
            // Create a DataTable and define the columns to match the AnswerTable type in SQL Server
            DataTable answerTable = new DataTable();
            answerTable.Columns.Add("Question_Id", typeof(int));
            answerTable.Columns.Add("Student_Ans", typeof(string));

            // Add rows to the DataTable (this should be populated with data from your form)
            for (int i = 0; i < _questionsAnswer.Length; i++)
            {
                // Assuming _questionsAnswer contains the answers to the questions
                answerTable.Rows.Add(_questions[i].Question_Id, _questionsAnswer[i]);
            }

            return answerTable;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_colse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



/*
using Exam_Form.Models;



namespace Exam_Form
{
    public partial class Frm_Stu_Exam : Form
    {
        private readonly Examination_Sys_Context _context;
        private List<GenerateExamResult> _questions;

        private int[] _questionOptionRadioIndex;
        private string[] _questionsAnswer;
        private int _currentIndex;
        public Frm_Stu_Exam()
        {
            InitializeComponent();
            _context = new Examination_Sys_Context();
        }

        private async void Frm_Stu_Exam_Load(object sender, EventArgs e)
        {
            int courseId = 1; // Replace with your desired Course_Id
            int numQuestions = 10; // Replace with your desired number of questions
            _questionOptionRadioIndex = new int[10];

            _questionsAnswer = new string[10];

            _currentIndex = 0;
            await LoadQuestions(courseId, numQuestions);
        }


        private async Task LoadQuestions(int courseId, int numQuestions)
        {
            try
            {
                // Fetch questions using the stored procedure
                _questions = await _context.Procedures.GenerateExamAsync(courseId, numQuestions);

                if (_questions != null && _questions.Count > 0)
                {
                    _currentIndex = 0;
                    //this.radioButton1.Checked = false;
                    //this.radioButton2.Checked = false;
                    //this.radioButton3.Checked = false;
                    //this.radioButton4.Checked = false;
                    DisplayQuestion(_currentIndex);
                }
                else
                {
                    MessageBox.Show("No questions found for the given course and number of questions.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DisplayQuestion(int index)
        {
            if (_questions == null || index < 0 || index >= _questions.Count)
                return;


            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.radioButton4.Checked = false;
            if (_questionOptionRadioIndex[index] > -1)
            {
                radioButtons[_questionOptionRadioIndex[index]].Checked = true;
            }

            var question = _questions[index];
            // Load QuestionOptions for each question
            var questionOptions = _context.QuestionOptions
                .Where(qo => qo.QuestionId == question.Question_Id)
                .ToList();

            this.lab_heahOfQuesion.Text = $"Q{index + 1}: {question.Question_Head}";


            if (question.Question_Type == "mcq")
            {
                this.radioButton1.Text = questionOptions[0].QuestionOption1;
                this.radioButton2.Text = questionOptions[1].QuestionOption1;
                this.radioButton3.Visible = true;
                this.radioButton4.Visible = true;
                this.radioButton3.Text = questionOptions[2].QuestionOption1;
                this.radioButton4.Text = questionOptions[3].QuestionOption1;
            }
            else
            {
                this.radioButton1.Text = "True";
                this.radioButton2.Text = "False";
                this.radioButton3.Visible = false;
                this.radioButton4.Visible = false;
            }





            //lblQuestionHead.Text = $"Q{index + 1}: {question.Question_Head}";
            //lblQuestionType.Text = $"Type: {question.Question_Type}";
            //lblQuestionPoints.Text = $"Points: {question.Question_Points}";
            //txtAnswer.Text = question.Question_Answer; // or use appropriate control for input

        }


        private void btn_nxt_Click(object sender, EventArgs e)
        {
            //this.radioButton1.Checked = false;
            //this.radioButton2.Checked = false;
            //this.radioButton3.Checked = false;
            //this.radioButton4.Checked = false;

            var radioButtons = groupBox1.Controls.OfType<RadioButton>().ToList();

            // Iterate through the radio buttons

            for (int i = 0; i < radioButtons.Count; i++)
            {

                if (radioButtons[i].Checked)
                {
                    _questionOptionRadioIndex[_currentIndex] = i;
                    _questionsAnswer[_currentIndex] = radioButtons[i].Text;
                    break;
                }
            }
            if (_questionOptionRadioIndex[_currentIndex] > -1)
            {
                for (int i = 0; i < radioButtons.Count; i++)
                {
                    if (radioButtons[i].Visible)
                    {
                        radioButtons[i].Checked = (i == _questionOptionRadioIndex[_currentIndex]);
                    }
                }
            }


            if (_questions == null || _currentIndex >= _questions.Count - 1)
                return;

            _currentIndex++;
            DisplayQuestion(_currentIndex);
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {



            if (_questionOptionRadioIndex[_currentIndex] > -1)
            {
                var radioButtons = groupBox1.Controls.OfType<RadioButton>().ToList();

                radioButtons[_questionOptionRadioIndex[_currentIndex]].Checked = true;
            }
            else
            {
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                this.radioButton3.Checked = false;
                this.radioButton4.Checked = false;
            }


            if (_questions == null || _currentIndex <= 0)
                return;

            _currentIndex--;
            DisplayQuestion(_currentIndex);
        }
    }
}
*/