using Newtonsoft.Json;
using NotificationService.Entity;
using NotificationService.Services.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NotificationService.Services
{
    public class RestService : RestImpService
    {
        private string urlInformalLocal = "https://services5.arcgis.com/oAvs2fapEemUpOTy/ArcGIS/rest/services/survey123_76549cfdea5d4828978ba44f3adfa2d8_fieldworker/FeatureServer/0/query?where=";
        private string extraInformalLocal = "objectIds=&time=&geometry=&geometryType=esriGeometryEnvelope&inSR=&spatialRel=esriSpatialRelIntersects&resultType=none&distance=0.0&units=esriSRUnit_Meter&relationParam=&returnGeodetic=false&outFields=*&returnGeometry=true&featureEncoding=esriDefault&multipatchOption=xyFootprint&maxAllowableOffset=&geometryPrecision=&outSR=&defaultSR=&datumTransformation=&applyVCSProjection=false&returnIdsOnly=false&returnUniqueIdsOnly=false&returnCountOnly=false&returnExtentOnly=false&returnQueryGeometry=false&returnDistinctValues=false&cacheHint=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&having=&resultOffset=&resultRecordCount=&returnZ=false&returnM=false&returnExceededLimitFeatures=true&quantizationParameters=&sqlFormat=none&f=json&token=";
        
        private string urlRegion = "https://gisem.osinergmin.gob.pe/serverosih/rest/services/Transversal/Oficinas_Regionales/MapServer/0/query?";
        private string extraRegion = "where=&text=&objectIds=&time=&timeRelation=esriTimeRelationOverlaps&geometryType=esriGeometryPoint&inSR=&spatialRel=esriSpatialRelIntersects&distance=&units=esriSRUnit_Foot&relationParam=&outFields=*&returnGeometry=false&returnTrueCurves=false&maxAllowableOffset=&geometryPrecision=&outSR=&havingClause=&returnIdsOnly=false&returnCountOnly=false&orderByFields=&groupByFieldsForStatistics=&outStatistics=&returnZ=false&returnM=false&gdbVersion=&historicMoment=&returnDistinctValues=false&resultOffset=&resultRecordCount=&returnExtentOnly=false&sqlFormat=none&datumTransformation=&parameterValues=&rangeValues=&quantizationParameters=&featureEncoding=esriDefault&f=json";
        public RestService()
        {
        }

        public List<Feature> GetForDay(DateTime day)
        {
            day = day.AddDays(-60);
            HttpClient client = new HttpClient();
            InformalLocalEntity informalLocalEntities = new InformalLocalEntity();
            string f_act = day.ToString("MM/dd/yyyy");
            string f_bef = day.AddDays(7).ToString("MM/dd/yyyy");
            string valoract = HttpUtility.UrlEncode(f_act);
            string valorbef = HttpUtility.UrlEncode(f_bef);
            string editDateFilter = "editDate+%3E+%27" + valoract + "%27+and+editDate+%3C+%27" + valorbef + "%27&";
            try
            {

                string _url = urlInformalLocal + editDateFilter + extraInformalLocal;
                using (HttpResponseMessage result = client.GetAsync(_url).Result)
                {
                    string resultJson = result.Content.ReadAsStringAsync().Result;
                    if (resultJson != null || resultJson.ToString().Length > 0)
                        informalLocalEntities = JsonConvert.DeserializeObject<InformalLocalEntity>(resultJson.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return informalLocalEntities.features;
        }

        public Feature GetRegion(Geometry geometry)
        {
            HttpClient client = new HttpClient();
            RegionEntity regionEntity = new RegionEntity();
            string geometryText = HttpUtility.UrlEncode(geometry.toGeometryString());
            string geometryFilter = "geometry=" + geometryText + "&";
            try
            {

                string _url = urlRegion + geometryFilter + extraRegion;
                using (HttpResponseMessage result = client.GetAsync(_url).Result)
                {
                    string resultJson = result.Content.ReadAsStringAsync().Result;
                    if (resultJson != null || resultJson.ToString().Length > 0)
                        regionEntity = JsonConvert.DeserializeObject<RegionEntity>(resultJson.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return regionEntity.features.First();
        }
    }
}
