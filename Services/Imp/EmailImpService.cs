using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services.Imp
{
    public interface EmailImpService
    {
        public void SendEmail(string emails);
    }
}
