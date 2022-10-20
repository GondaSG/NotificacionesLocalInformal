using NotificationService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services.Imp
{
    public interface NotificationImpService
    {
        string Create();
        List<ExcelEntity> GetEmailForRegion(string sRegion);
    }
}
