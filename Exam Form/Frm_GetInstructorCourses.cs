using Exam_Form.Models;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_GetInstructorCourses : Form
    {
        private int instructorId;// = 1; // Replace with the actual instructor ID
        public Frm_GetInstructorCourses(int _instructorId)
        {
            InitializeComponent();
            instructorId = _instructorId;
        }

        private async void Frm_GetInstructorCourses_Load(object sender, EventArgs e)
        {
            using (var context = new Examination_Sys_Context())
            {
                try
                {

                    var result = await context.Procedures.GetInstructorCoursesAsync(instructorId);

                    // Convert result to DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Course_Name", typeof(string));
                    dt.Columns.Add("number_of_students", typeof(int));

                    foreach (var course in result)
                    {
                        dt.Rows.Add(course.Course_Name, course.number_of_students);
                    }

                    // Bind DataTable to ReportViewer
                    reportViewer_GetInstructorCourses.LocalReport.ReportPath = @"C:\Users\abdellateef_eid\source\repos\Exam Form\Exam Form\Report_GetInstructorCourses.rdlc";
                    reportViewer_GetInstructorCourses.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer_GetInstructorCourses.LocalReport.DataSources.Add(reportDataSource);

                    // Refresh the report
                    reportViewer_GetInstructorCourses.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
