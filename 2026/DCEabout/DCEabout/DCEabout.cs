using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DCEAnnoReinf;
using System;
using System.IO;


namespace DCEabout
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class DCEabout : IExternalCommand
    {


        public Autodesk.Revit.UI.Result Execute(Autodesk.Revit.UI.ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uidoc = uiApp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Autodesk.Revit.UI.TaskDialog.Show("DeSimone Version", "DeSimone Custom Tabs Version 2025.02.01 \nContact Thayuman Sookram for Help");

            string commandName = "DCEabout";
            DCELogFile log = new DCELogFile();
            log.LogCommand(commandName, doc);

            return Autodesk.Revit.UI.Result.Succeeded;

        }
        
    }

}