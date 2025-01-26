using Exam_Form.Models;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_GetExamQuestionsWithChoices : Form
    {
        private int ExamId;
        public Frm_GetExamQuestionsWithChoices(int _ExamId)
        {
            InitializeComponent();
            ExamId = _ExamId;
        }

        private async void Frm_GetExamQuestionsWithChoices_Load(object sender, EventArgs e)
        {
            using (var context = new Examination_Sys_Context())
            {
                try
                {
                    // Fetch data from the stored procedure
                    var result = await context.Procedures.GetExamQuestionsWithChoices_updatedAsync(ExamId);//int? ExamId,

                    //// Convert the result to a DataTable
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("Question_Head", typeof(string));
                    //dt.Columns.Add("Question_Options", typeof(string));

                    //foreach (var item in result)
                    //{
                    //    dt.Rows.Add(item.Question_Head, item.Question_Options);
                    //}
                    // Convert the result to a DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Question_Head", typeof(string));
                    dt.Columns.Add("Question_Options", typeof(string)); // Formatted options

                    foreach (var item in result)
                    {
                        // Split the options by ',' and format them
                        var formattedOptions = string.Join(Environment.NewLine, item.Question_Options?.Split(',') ?? new string[0]);

                        // Add the question and formatted options to the DataTable
                        dt.Rows.Add(item.Question_Head, formattedOptions);
                    }
                    // Set the path to the RDLC report file
                    reportViewer_GetExamQuestionsWithChoicess.LocalReport.ReportPath = @"C:\Users\abdellateef_eid\source\repos\Exam Form\Exam Form\Report_GetExamQuestionsWithChoices.rdlc";

                    // Clear and add data source
                    reportViewer_GetExamQuestionsWithChoicess.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer_GetExamQuestionsWithChoicess.LocalReport.DataSources.Add(reportDataSource);

                    // Refresh the report
                    reportViewer_GetExamQuestionsWithChoicess.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
