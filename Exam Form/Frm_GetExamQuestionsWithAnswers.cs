using Exam_Form.Models;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_GetExamQuestionsWithAnswers : Form
    {
        private int? _ExamId;
        private int? _StudentId;
        public Frm_GetExamQuestionsWithAnswers(int ExamId, int StudentId)
        {
            InitializeComponent();
            _ExamId = ExamId;
            _StudentId = StudentId;
        }

        private async void Frm_GetExamQuestionsWithAnswers_Load(object sender, EventArgs e)
        {
            using (var context = new Examination_Sys_Context())
            {
                try
                {
                    // Call the stored procedure to get exam questions with answers
                    var result = await context.Procedures.GetExamQuestionsWithAnswersAsync(_ExamId, _StudentId);//int? ExamId, int? StudentId

                    // Convert result to DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Question_Head", typeof(string));
                    dt.Columns.Add("Model_Answer", typeof(string));
                    dt.Columns.Add("Student_Answer", typeof(string));

                    foreach (var item in result)
                    {
                        dt.Rows.Add(item.Question_Head, item.Model_Answer, item.Student_Answer);
                    }

                    // Set the RDLC report file path
                    reportViewer_GetExamQuestionsWithAnswers.LocalReport.ReportPath = @"C:\Users\abdellateef_eid\source\repos\Exam Form\Exam Form\Report_GetExamQuestionsWithAnswers.rdlc";

                    // Clear existing data sources
                    reportViewer_GetExamQuestionsWithAnswers.LocalReport.DataSources.Clear();

                    // Create a new ReportDataSource and bind it to the DataTable
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer_GetExamQuestionsWithAnswers.LocalReport.DataSources.Add(reportDataSource);

                    // Refresh the ReportViewer to display the data
                    reportViewer_GetExamQuestionsWithAnswers.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
