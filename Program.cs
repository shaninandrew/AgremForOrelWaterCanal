using System.Diagnostics;

namespace OWC_Aggreems
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

            try
            {
                Bootstrap x = new Bootstrap();
                Application.Run(x);
            }
            catch (Exception ex) 
            { 
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}