using Exam_Form.Models;

namespace Exam_Form
{
    public partial class Frm_Stu_Coures_Exam : Form
    {
        private readonly Examination_Sys_Context _context;
        private List<GetStudentCoursesAndExamsResult> _CoursesAndExams;
        private Student _Student;

        public Frm_Stu_Coures_Exam(Student? student)
        {
            InitializeComponent();
            _context = new Examination_Sys_Context();

            if (student != null) _Student = student;
        }

        private async void Frm_Stu_Coures_Exam_Load(object sender, EventArgs e)
        {
            // Enable auto-scroll for the panel
            panelCoursesAndExams.AutoScroll = true;

            // Optional: Set a fixed size for the panel (adjust as needed)
            //panelCoursesAndExams.Size = new Size(500, 400); // Width x Height


            lab_welcome.Text = $"Welcome: {_Student.StudentName}";

            //_StudentId = 2;
            await LoadStudentCoursesAndExams(_Student.StudentId);
        }
        private async Task LoadStudentCoursesAndExams(int courseId)
        {
            try
            {
                // Clear any existing controls in the panel
                panelCoursesAndExams.Controls.Clear();

                // Enable scrolling in case of overflow
                panelCoursesAndExams.AutoScroll = true;

                // Fetch questions using the stored procedure
                _CoursesAndExams = await _context.Procedures.GetStudentCoursesAndExamsAsync(courseId);

                if (_CoursesAndExams != null && _CoursesAndExams.Count > 0)
                {
                    int panelHeight = 270;  // Height of each exam panel
                    int spacing = 15;       // Spacing between panels
                    int yPosition = 0;      // Initial Y position

                    // Font styles for labels
                    var headerFont = new Font("Arial", 18, FontStyle.Bold); // Bold font for headers
                    var contentFont = new Font("Arial", 18, FontStyle.Regular); // Regular font for content

                    // Loop through the data and create panels for each exam
                    foreach (var CourseExam in _CoursesAndExams)
                    {

                        // Create a panel to group exam details and the button
                        var examPanel = new Panel
                        {
                            Size = new Size(panelCoursesAndExams.Width - 30, panelHeight),
                            Location = new Point(10, yPosition),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        int labelYPosition = 10; // Initial Y position inside the panel
                        int labelSpacing = 40;   // Spacing between labels

                        // Add labels with bold headers and regular content
                        var courseNameLabel = new Label
                        {
                            Text = "Course Name:",
                            Font = headerFont,
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(courseNameLabel);

                        var courseNameValue = new Label
                        {
                            Text = CourseExam.Course_Name,
                            Font = contentFont,
                            AutoSize = true,
                            Location = new Point(300, labelYPosition)
                        };
                        examPanel.Controls.Add(courseNameValue);
                        labelYPosition += labelSpacing;

                        var examStartTimeLabel = new Label
                        {
                            Text = "Start Time:",
                            Font = headerFont,
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examStartTimeLabel);

                        var examStartTimeValue = new Label
                        {
                            Text = CourseExam.Exam_StartTime.ToString(),
                            Font = contentFont,
                            AutoSize = true,
                            Location = new Point(300, labelYPosition)
                        };
                        examPanel.Controls.Add(examStartTimeValue);
                        labelYPosition += labelSpacing;

                        var examStartDateLabel = new Label
                        {
                            Text = "Start Date:",
                            Font = headerFont,
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examStartDateLabel);

                        var examStartDateValue = new Label
                        {
                            Text = CourseExam.Exam_StartDate.ToShortDateString(),
                            Font = contentFont,
                            AutoSize = true,
                            Location = new Point(300, labelYPosition)
                        };
                        examPanel.Controls.Add(examStartDateValue);
                        labelYPosition += labelSpacing;

                        var examDurationLabel = new Label
                        {
                            Text = "Duration (hours):",
                            Font = headerFont,
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examDurationLabel);

                        var examDurationValue = new Label
                        {
                            Text = CourseExam.Exam_Duration.ToString(),
                            Font = contentFont,
                            AutoSize = true,
                            Location = new Point(300, labelYPosition)
                        };
                        examPanel.Controls.Add(examDurationValue);
                        labelYPosition += labelSpacing;

                        var examTotalPointsLabel = new Label
                        {
                            Text = "Total Points:",
                            Font = headerFont,
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examTotalPointsLabel);

                        var examTotalPointsValue = new Label
                        {
                            Text = CourseExam.Exam_TotalPoints.ToString(),
                            Font = contentFont,
                            AutoSize = true,
                            Location = new Point(300, labelYPosition)
                        };
                        examPanel.Controls.Add(examTotalPointsValue);
                        labelYPosition += labelSpacing;

                        //**********************************
                        var viewDetailsButton = new Button
                        {
                            Text = "Start Exam",
                            Size = new Size(200, 40),
                            Location = new Point(10, labelYPosition),
                            ForeColor = Color.Red,
                            Font = contentFont
                        };

                        // Get the current date and time
                        var currentTime = DateTime.Now;
                        // Combine DateOnly and TimeOnly into DateTime
                        var examStartTime = CourseExam.Exam_StartDate.ToDateTime(CourseExam.Exam_StartTime);
                        // Calculate the end time based on the duration
                        var examEndTime = examStartTime.AddHours(CourseExam.Exam_Duration);
                        //**********************************
                        if (_context.StudentAnswers
                            .Any(sa => sa.StudentId == _Student.StudentId && sa.ExamId == CourseExam.Exam_Id))
                        {
                            viewDetailsButton.Enabled = false;
                            viewDetailsButton.Text = "Completed";
                        }
                        else if (currentTime >= examStartTime && currentTime <= examEndTime)
                        {
                            viewDetailsButton.Enabled = true;
                        }
                        else
                        {
                            viewDetailsButton.Enabled = false;
                            viewDetailsButton.Text = "Not Available";
                            //viewDetailsButton.ForeColor = Color.Blue;
                        }


                        // Add the click event handler for the button
                        viewDetailsButton.Click += async (s, e) =>
                        {
                            Frm_Stu_Exam _Exam_Exam_Exam_ = new Frm_Stu_Exam(_Student.StudentId, CourseExam.Course_Id ?? 0, CourseExam.Exam_Id);

                            // Hide the current form and show the modal exam form
                            this.Hide();
                            _Exam_Exam_Exam_.ShowDialog();  // Show the Frm_Stu_Exam dialog

                            // After closing the dialog, show the current form again
                            this.Show();

                            // After the exam form is closed, reload the data for the current form
                            //await LoadStudentCoursesAndExams(_StudentId);
                            // After the exam form is closed, update the button's state
                            if (_context.StudentAnswers.Any(sa => sa.StudentId == _Student.StudentId && sa.ExamId == CourseExam.Exam_Id))
                            {
                                viewDetailsButton.Enabled = false;
                                viewDetailsButton.Text = "Completed";
                            }

                        };

                        // Add the button to the panel
                        examPanel.Controls.Add(viewDetailsButton);


                        /*
                        // Add a button for actions related to this exam
                        var viewDetailsButton = new Button
                        {
                            Text = "Start Exam",
                            Size = new Size(200, 40),
                            Location = new Point(10, labelYPosition),
                            ForeColor = Color.Red,
                            Font = contentFont
                        };
                        viewDetailsButton.Click += (s, e) =>
                        {
                            // Handle button click event
                            //MessageBox.Show($"Exam ID: {item.Exam_Id}", "Exam Details", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            Frm_Stu_Exam _Exam_Exam_Exam_ = new Frm_Stu_Exam(CourseExam.Course_Id, CourseExam.Exam_Id);

                            // Hide the current form and show the modal exam form
                            this.Hide();
                            _Exam_Exam_Exam_.ShowDialog();  // Show the Frm_Stu_Exam dialog

                            // After closing the dialog, show the current form again
                            this.Show();


                        };
                        examPanel.Controls.Add(viewDetailsButton);
                        */
                        // Add the panel to the main panel
                        panelCoursesAndExams.Controls.Add(examPanel);

                        // Update Y position for the next panel
                        yPosition += panelHeight + spacing;
                    }
                }
                else
                {
                    MessageBox.Show("No CoursesAndExams found for the given student.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private async Task LoadStudentCoursesAndExams(int courseId)
        {
            try
            {
                // Clear any existing controls in the panel
                panelCoursesAndExams.Controls.Clear();

                // Fetch questions using the stored procedure
                _CoursesAndExams = await _context.Procedures.GetStudentCoursesAndExamsAsync(courseId);

                if (_CoursesAndExams != null && _CoursesAndExams.Count > 0)
                {
                    int panelHeight = 240;  // Height of each exam panel
                    int spacing = 10;       // Spacing between panels
                    int yPosition = 0;      // Initial Y position

                    // Loop through the data and create panels for each exam
                    foreach (var item in _CoursesAndExams)
                    {
                        // Create a panel to group exam details and the button
                        var examPanel = new Panel
                        {
                            Size = new Size(panelCoursesAndExams.Width - 20, panelHeight),
                            Location = new Point(10, yPosition),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Add labels for exam details
                        int labelYPosition = 10; // Initial Y position inside the panel
                        int labelSpacing = 33;   // Spacing between labels

                        var courseNameLabel = new Label
                        {
                            Text = $"Course Name: {item.Course_Name}",
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(courseNameLabel);
                        labelYPosition += labelSpacing;

                        var examStartTimeLabel = new Label
                        {
                            Text = $"Start Time: {item.Exam_StartTime}",
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examStartTimeLabel);
                        labelYPosition += labelSpacing;

                        var examStartDateLabel = new Label
                        {
                            Text = $"Start Date: {item.Exam_StartDate}",
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examStartDateLabel);
                        labelYPosition += labelSpacing;

                        var examDurationLabel = new Label
                        {
                            Text = $"Duration: {item.Exam_Duration} hours",
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examDurationLabel);
                        labelYPosition += labelSpacing;

                        var examTotalPointsLabel = new Label
                        {
                            Text = $"Total Points: {item.Exam_TotalPoints}",
                            AutoSize = true,
                            Location = new Point(10, labelYPosition)
                        };
                        examPanel.Controls.Add(examTotalPointsLabel);
                        labelYPosition += labelSpacing;

                        // Add a button for actions related to this exam
                        var viewDetailsButton = new Button
                        {
                            Text = "Start Exam",
                            Size = new Size(200, 40),
                            Location = new Point(10, labelYPosition),
                            ForeColor = Color.Red
                        };
                        viewDetailsButton.Click += (s, e) =>
                        {
                            // Handle button click event here
                            MessageBox.Show($"Exam ID: {item.Exam_Id}", "Exam Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };
                        examPanel.Controls.Add(viewDetailsButton);

                        // Add the panel to the main panel
                        panelCoursesAndExams.Controls.Add(examPanel);

                        // Update Y position for the next panel
                        yPosition += panelHeight + spacing;
                    }
                }
                else
                {
                    MessageBox.Show("No CoursesAndExams found for the given student.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        /*
        private async Task LoadStudentCoursesAndExams(int courseId)
        {
            try
            {
                // Clear any existing controls in the panel
                panelCoursesAndExams.Controls.Clear();

                // Fetch questions using the stored procedure
                _CoursesAndExams = await _context.Procedures.GetStudentCoursesAndExamsAsync(courseId);

                if (_CoursesAndExams != null && _CoursesAndExams.Count > 0)
                {
                    int labelHeight = 25; // Height of each label
                    int spacing = 5;      // Spacing between labels
                    int yPosition = 0;    // Initial Y position

                    // Loop through the data and create labels
                    foreach (var item in _CoursesAndExams)
                    {
                        // Create a label for each property
                        var courseNameLabel = new Label
                        {
                            Text = $"Course Name: {item.Course_Name}",
                            AutoSize = true,
                            Location = new Point(10, yPosition)
                        };
                        panelCoursesAndExams.Controls.Add(courseNameLabel);
                        yPosition += labelHeight + spacing;

                        //var examIdLabel = new Label
                        //{
                        //    Text = $"Exam ID: {item.Exam_Id}",
                        //    AutoSize = true,
                        //    Location = new Point(10, yPosition)
                        //};
                        //panelCoursesAndExams.Controls.Add(examIdLabel);
                        //yPosition += labelHeight + spacing;

                        var examStartTimeLabel = new Label
                        {
                            Text = $"Start Time: {item.Exam_StartTime}",
                            AutoSize = true,
                            Location = new Point(10, yPosition)
                        };
                        panelCoursesAndExams.Controls.Add(examStartTimeLabel);
                        yPosition += labelHeight + spacing;

                        var examStartDateLabel = new Label
                        {
                            Text = $"Start Date: {item.Exam_StartDate}",
                            AutoSize = true,
                            Location = new Point(10, yPosition)
                        };
                        panelCoursesAndExams.Controls.Add(examStartDateLabel);
                        yPosition += labelHeight + spacing;

                        var examDurationLabel = new Label
                        {
                            Text = $"Duration: {item.Exam_Duration} hours",
                            AutoSize = true,
                            Location = new Point(10, yPosition)
                        };
                        panelCoursesAndExams.Controls.Add(examDurationLabel);
                        yPosition += labelHeight + spacing;

                        var examTotalPointsLabel = new Label
                        {
                            Text = $"Total Points: {item.Exam_TotalPoints}",
                            AutoSize = true,
                            Location = new Point(10, yPosition)
                        };
                        panelCoursesAndExams.Controls.Add(examTotalPointsLabel);
                        yPosition += labelHeight + spacing;

                        // Add a separator label or empty space
                        var separatorLabel = new Label
                        {
                            Text = "-------------------------",
                            AutoSize = true,
                            Location = new Point(10, yPosition)
                        };
                        panelCoursesAndExams.Controls.Add(separatorLabel);
                        yPosition += labelHeight + spacing;
                    }
                }
                else
                {
                    MessageBox.Show("No CoursesAndExams found for the given student.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        */

    }
}
