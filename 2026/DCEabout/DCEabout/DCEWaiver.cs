using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DCEAnnoReinf;
using System;
using System.IO;
namespace DCEabout
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    internal class DCEWaiver : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            Document doc = uidoc.Document;

            string uri = "https://dcestructural.sharepoint.com/:w:/r/bim/BIM/Electronic%20File%20Disclaimer.docx?d=we6098b265e4744fc991236e8d14f29c9&csf=1&web=1&e=TBQ5bs";
            System.Diagnostics.Process.Start(uri);

            string commandName = "DCEWaiver";
            DCELogFile log = new DCELogFile();
            log.LogCommand(commandName, doc);

            return Result.Succeeded;
        }
        
    }
}