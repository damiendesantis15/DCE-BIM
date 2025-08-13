using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DCEAnnoReinf;
using System;
using System.IO;
namespace DCEabout
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    internal class DCEBluebeamSessions : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //string uri = "https://dcestructural.sharepoint.com/:b:/r/bim/BIM/DCE-Sketch%20Creation%20in%20Revit.pdf?csf=1&web=1&e=qRwCXK";
            //System.Diagnostics.Process.Start(uri);
            TaskDialog.Show("Hello", "This documentation is currently in development. If you are in urgent need of it contact a BIM Lead Specialist or higher title.");

            string commandName = "DCEBluebeamSessions";
            DCELogFile log = new DCELogFile();
            log.LogCommand(commandName, doc);

            return Result.Succeeded;
        }
        
    }
}