using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DCEAnnoReinf;
using System;
using System.IO;

namespace DCEabout
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class DCEBIM360CoordGuide : IExternalCommand
    {

        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            Document doc = uidoc.Document;

            string uri = "https://dcestructural.sharepoint.com/:b:/r/bim/BIM/BIM360%20Autodesk%20-%20Coordination%20Guide.pdf?csf=1&web=1&e=9Weu7C";
            System.Diagnostics.Process.Start(uri);

            string commandName = "DCEBIM360CoordGuide";
            DCELogFile log = new DCELogFile();
            log.LogCommand(commandName, doc);

            return Result.Succeeded;

        }
        
    }
}