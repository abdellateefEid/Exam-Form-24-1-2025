using Exam_Form.Models;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_GetCourseTopics : Form
    {
        private int? _CourseId;
        public Frm_GetCourseTopics(int? courseId)
        {
            InitializeComponent();
            _CourseId = courseId;
        }

        private async void Frm_GetCourseTopics_Load(object sender, EventArgs e)
        {
            using (var context = new Examination_Sys_Context())
            {
                try
                {
                    // Call the stored procedure to get course topics
                    var result = await context.Procedures.GetCourseTopicsAsync(_CourseId);//int? CourseId

                    // Convert result to DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Topic_Name", typeof(string));

                    foreach (var topic in result)
                    {
                        dt.Rows.Add(topic.Topic_Name);
                    }

                    // Set the RDLC report file path
                    reportViewer_GetCourseTopics.LocalReport.ReportPath = @"C:\Users\abdellateef_eid\source\repos\Exam Form\Exam Form\Report_GetCourseTopics.rdlc";

                    // Clear existing data sources
                    reportViewer_GetCourseTopics.LocalReport.DataSources.Clear();

                    // Create a new ReportDataSource and bind it to the DataTable
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer_GetCourseTopics.LocalReport.DataSources.Add(reportDataSource);

                    // Refresh the ReportViewer to display the data
                    reportViewer_GetCourseTopics.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
