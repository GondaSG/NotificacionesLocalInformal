using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NotificationService.Entity
{
    [DataContract]
    [Serializable]
    public class InformalLocalEntity
    {
        [DataMember]
        public List<Feature> features { get; set; }
    }

    
}
