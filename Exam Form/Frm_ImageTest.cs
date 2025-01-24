namespace Exam_Form
{
    public partial class Frm_ImageTest : Form
    {
        public Frm_ImageTest()
        {
            InitializeComponent();
        }

        private bool flag = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                pictureBox1.Image = Image.FromFile("Images\\st-icon.jpg");
                flag = false;
            }
            else
            {
                pictureBox1.Image = Image.FromFile("Images\\inst-icon.png");
                flag = true;
            }
            // Set the PictureBox's SizeMode property to make the image fit
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
