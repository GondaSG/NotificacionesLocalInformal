using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NotificationService.Entity
{
    [Serializable]
    [DataContract]
    public class Feature
    {
        [DataMember]
        public Attributes attributes { get; set; }
        [DataMember]
        public Geometry geometry { get; set; }
        [DataMember]
        public Region region { get; set; }
    }
    public class Region
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Attributes
    {
        [DataMember]
        public int objectid { get; set; }
        [DataMember]
        public string CreationDate { get; set; }
        [DataMember]
        public string Creator { get; set; }
        [DataMember]
        public string EditDate { get; set; }
        //public string EditDateTime { get { }; set { }; }
        [DataMember]
        public string Editor { get; set; }
        [DataMember]
        public string tipo_de_establecimiento { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string codSuministro { get; set; }
        [DataMember]
        public string comentarios { get; set; }
        [DataMember]
        public string Estado { get; set; }
        public string COD_OF_REGION { get; set; }
        public string NOM_OF_REGION { get; set; }
    }
    public class Geometry
    {
        [DataMember]
        public double x { get; set; }
        [DataMember]
        public double y { get; set; }
        public SpatialReference spatialReference { get; set; } = new SpatialReference();

        public string toGeometryString()
        {
            return "{'x' : " + this.x +
                   ", 'y' :" + this.y +
                   ", 'spatialReference' : { 'wkid' : " + this.spatialReference.wkid + " }}";
        }
    }

    public class SpatialReference
    {
        public int wkid { get; set; } = 4326;
    }
}
