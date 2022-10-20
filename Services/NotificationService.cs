using NotificationService.Services.Imp;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using NotificationService.Helper;
using System.Configuration;
using Microsoft.Extensions.Options;
using NotificationService.Entity;

namespace NotificationService.Services
{
    public class NotificationService : NotificationImpService
    {
        private RestImpService restImpService;
        private ReadExcelImpService readExcelImpService;
        private EmailImpService emailImpService;
        private DateTime datetime;
        private IEnumerable<IGrouping<string, ExcelEntity>> excelEntities;
        private List<Feature> features;

        public NotificationService()
        {
            restImpService = new RestService();
            readExcelImpService = new ReadExcelService();
            excelEntities = readExcelImpService.getElements();
            datetime = DateTime.Now;
        }

        public string Create()
        {
            features = new List<Feature>();
            features = restImpService.GetForDay(datetime);
            features.ForEach(t =>
            {
                t.region = new Region();
                Feature feature = restImpService.GetRegion(t.geometry);
                t.region.code = feature.attributes.COD_OF_REGION;
                t.region.name = feature.attributes.NOM_OF_REGION;
            });
            List<ExcelEntity> excels = new List<ExcelEntity>();
            features.GroupBy(t => t.region.name).ToList().ForEach(t => {
                var excel = excelEntities.Where(l => l.Key.Trim().ToUpper() == t.Key.Trim().ToUpper());
                if (excel.Any()) {
                    emailImpService = new EmailService(t);
                    emailImpService.SendEmail(string.Join(',',excel.First().ToArray().Select(f => f.email)));
                }
            });
            return "";
        }
        public List<ExcelEntity> GetEmailForRegion(string sRegion) {
            var key = excelEntities.Where(l => l.Key.Trim().ToUpper() == sRegion.Trim().ToUpper());
            if (key.Any()) {
                return key.First().ToList();
            }
            return new List<ExcelEntity>();
        }
    }
}
