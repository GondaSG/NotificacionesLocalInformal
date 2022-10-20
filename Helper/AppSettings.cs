using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Helper
{
    public class AppSettings
    {
        public RestEsri restEsri { get; set; }
    }

    public class RestEsri
    {
        public string Extra { get; set;}
        public string url { get; set;}
    }
}
