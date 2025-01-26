using Exam_Form.Models;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Exam_Form
{
    public partial class Frm_GetStuByDept_SP : Form
    {
        public Frm_GetStuByDept_SP()
        {
            InitializeComponent();
        }

        private async void Frm_GetStuByDept_SP_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Examination_Sys_Context())
                {
                    // Call the stored procedure
                    int departmentId = 1; // Replace with the appropriate Department_Id
                    var result = await context.Procedures.GetStudentsByDepartmentAsync(departmentId);

                    // Convert result to DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Student_Name", typeof(string));
                    dt.Columns.Add("Student_Phone", typeof(string));
                    dt.Columns.Add("Student_Email", typeof(string));
                    dt.Columns.Add("Department_Name", typeof(string));
                    dt.Columns.Add("Track_Name", typeof(string));

                    foreach (var item in result)
                    {
                        dt.Rows.Add(item.Student_Name, item.Student_Phone, item.Student_Email, item.Department_Name, item.Track_Name);
                    }

                    // Bind DataTable to ReportViewer
                    reportViewer_getStuByDept.LocalReport.ReportPath = @"C:\Users\abdellateef_eid\source\repos\Exam Form\Exam Form\Report-getStuByDept.rdlc";
                    reportViewer_getStuByDept.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);
                    reportViewer_getStuByDept.LocalReport.DataSources.Add(reportDataSource);

                    // Refresh the report
                    reportViewer_getStuByDept.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
