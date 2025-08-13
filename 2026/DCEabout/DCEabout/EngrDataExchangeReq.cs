using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DCEAnnoReinf;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DCEabout
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    internal class EngrDataExchangeReq : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            Document doc = uidoc.Document;

            string projnum = doc.ProjectInformation.Number.ToString();
            string projname = doc.ProjectInformation.Name.ToString();
            string emailtitle = $"{projnum}-{projname} Data Exchange Request.";

            Outlook.Application outlookApp = new Outlook.Application();

            Outlook.MailItem NewMail= (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            DataExchangeForm dexchangform = new DataExchangeForm();
            dexchangform.ShowDialog();

            if (dexchangform.DialogResult == true)
            {
                
                NewMail.Subject = emailtitle;
                
                StringBuilder emailcontent = new StringBuilder();
               
                emailcontent.AppendLine($"BIM Team,\nI am requesting data exchange for {projnum}-{projname} for the following applications.\n");

                if (dexchangform.etabs.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.etabs.Content.ToString()}");
                }

                if (dexchangform.safe.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.safe.Content.ToString()}");
                }

                if (dexchangform.ram.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.ram.Content.ToString()}");
                }

                if (dexchangform.risa.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.risa.Content.ToString()}");
                }

                if (dexchangform.robot.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.robot.Content.ToString()}");
                }

                if (dexchangform.tekla.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.tekla.Content.ToString()}");
                }

                if (dexchangform.ifc.IsChecked == true)
                {
                    emailcontent.AppendLine($"• {dexchangform.ifc.Content.ToString()}");
                }
                emailcontent.AppendLine($"\n\n****Engineers must provide software versions where noted, cc the project PM and BIM staff assigned to the project.****");
                emailcontent.AppendLine("\n\nThank you,");
                NewMail.CC = "thayuman.sookram@de-simone.com";
                NewMail.Body = emailcontent.ToString();
                NewMail.Display();
                
            }

            string commandName = "EngrDataExchangeReq";
            DCELogFile log = new DCELogFile();
            log.LogCommand(commandName, doc);

            return Result.Succeeded;
        }
    }
}
