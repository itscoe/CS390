using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StreamReader userDatabase = OpenFile(BuildFilePath("userDB.in"));
            StreamReader courseDatabase = OpenFile(BuildFilePath("courseDB.in"));
            StreamReader courseHistoryDatabase = OpenFile(BuildFilePath("historyDB.in"));

            RegistrationDatabase.Read(userDatabase, RegistrationDatabase.DatabaseType.user);
            RegistrationDatabase.Read(courseDatabase, RegistrationDatabase.DatabaseType.course);
            RegistrationDatabase.Read(courseHistoryDatabase, RegistrationDatabase.DatabaseType.courseHistory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInScreen());
        }

        static StreamReader OpenFile(string fileName)
        {
            try
            {
                StreamReader file = new StreamReader(fileName);

                return file;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("An error has occurred while trying to open file \"{0}\".", fileName));
            }
        }

        static string BuildFilePath(string fileName)
        {
            string strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string strFilePath = Path.Combine(strAppPath, "Resources");
            string strFullFileName = Path.Combine(strFilePath, fileName);

            return strFullFileName;
        }

    }
}
