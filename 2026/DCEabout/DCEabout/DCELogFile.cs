using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCEAnnoReinf
{
    public class DCELogFile
    {
        public void LogCommand(string commandname, Document doc)
        {
            string folderpath = @"C:\ProgramData\DeSimone\DCEBIMaddondata";

            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                // Construct the log entry
                string usr = doc.Application.Username.ToString();
                // Path to the text file where logs will be written
                string filePath = $"C:/ProgramData/DeSimone/DCEBIMaddondata/{usr}.txt";

                string projnum = doc.ProjectInformation.Number.ToString();
                string projname = doc.ProjectInformation.Name.ToString();
                string timestamp = DateTime.Now.ToString("G");
                string logEntry = $"{usr},{timestamp},{commandname},{projnum},{projname}";

                // Open the file and append the log entry
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(logEntry);
                }
            }

            else
            {
                // Construct the log entry
                string usr = doc.Application.Username.ToString();
                // Path to the text file where logs will be written
                string filePath = $"C:/ProgramData/DeSimone/DCEBIMaddondata/{usr}.txt";

                string projnum = doc.ProjectInformation.Number.ToString();
                string projname = doc.ProjectInformation.Name.ToString();
                string timestamp = DateTime.Now.ToString("G");
                string logEntry = $"{usr},{timestamp},{commandname},{projnum},{projname}";

                // Open the file and append the log entry
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(logEntry);
                }
            }
        }

    }
}