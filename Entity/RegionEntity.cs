using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NotificationService.Entity
{
    [Serializable]
    [DataContract]
    public class RegionEntity
    {
        [DataMember]
        public List<Feature> features { get; set; }
    }
   
}
