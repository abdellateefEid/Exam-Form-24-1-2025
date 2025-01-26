using Exam_Form.Models;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_GetStudentGrades : Form
    {
        private int st_id;
        public Frm_GetStudentGrades(int _st_id)
        {
            InitializeComponent();
            st_id = _st_id;
        }


        private async void Frm_GetStudentGrades_Load(object sender, EventArgs e)
        {
            using (var context = new Examination_Sys_Context())
            {
                try
                {
                    // Fetch data from the stored procedure
                    var result = await context.Procedures.GetStudentGradesAsync(st_id);//int? StudentId

                    // Convert the result to a DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Course_Name", typeof(string));
                    dt.Columns.Add("Student_Course_Grade", typeof(int));

                    foreach (var item in result)
                    {
                        dt.Rows.Add(item.Course_Name, item.Student_Course_Grade ?? 0); // Handle null grades
                    }

                    // Set the path to the RDLC report file
                    reportViewer_GetStudentGrades.LocalReport.ReportPath = @"C:\Users\abdellateef_eid\source\repos\Exam Form\Exam Form\Report_GetStudentGrades.rdlc";

                    // Clear and add data source
                    reportViewer_GetStudentGrades.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer_GetStudentGrades.LocalReport.DataSources.Add(reportDataSource);

                    // Refresh the report
                    reportViewer_GetStudentGrades.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
