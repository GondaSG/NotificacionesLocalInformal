using NotificationService.Entity;
using NotificationService.Services.Imp;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services
{
    public class ReadExcelService : ReadExcelImpService
    {
        //private string ruta = "C:/proyectos/NotificationService/NotificationService/Data/ListaClientes.xlsx";
        private string ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\ListaClientes.xlsx");
        private string vlor = "";
        public ReadExcelService()
        {

        }
        public IEnumerable<IGrouping<string, ExcelEntity>> getElements()
        {
            SLDocument sl = new SLDocument(ruta.Replace("\\bin\\Debug\\netcoreapp3.1",""));
            IEnumerable <IGrouping<string, ExcelEntity>> elementGroup;
            ExcelEntity excelEntity;
            List<ExcelEntity> excelEntities = new List<ExcelEntity>();
            int iRow = 2;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                excelEntity = new ExcelEntity();
                excelEntity.RegionName = sl.GetCellValueAsString(iRow, 1);
                excelEntity.personName = sl.GetCellValueAsString(iRow, 2);
                excelEntity.email = sl.GetCellValueAsString(iRow, 3);
                excelEntities.Add(excelEntity);
                iRow++;
            }
            elementGroup = excelEntities.GroupBy(t => t.RegionName);
            return elementGroup;
        }
    }
}
