namespace Exam_Form
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Frm_Stu_Coures_Exam());
            Application.Run(new Frm_Login());
            //Application.Run(new Frm_ImageTest());
        }
    }
}