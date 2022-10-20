using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NotificationService.Entity
{
    [DataContract]
    [Serializable]
    public class ExcelEntity
    {
        [DataMember]
        public string RegionName { get; set; }
        [DataMember]
        public string personName { get; set; }
        [DataMember]
        public string email { get; set; }

    }
}
