using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MambaTestApi.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MambaTestApi.Repo
{
    /// <summary>
    /// Repository getting informations directly from the JawBone API
    /// </summary>
    public class JawBoneActivityItemRepository : JawBoneRepo, Interfaces.IJawboneRepository
    {
        /// <summary>
        /// Get the last activity items
        /// </summary>
        /// <returns></returns>
        public GlobalActivityItem GetActivity()
        {
            var resp = new GlobalActivityItem();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);
           
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("moves").Result;
                if (response.IsSuccessStatusCode)
                {
                    resp = new GlobalActivityItem { Content = response.Content.ReadAsStringAsync().Result };

                    var jObject = JObject.Parse(resp.Content);

                    ParseMetaPart(resp, jObject);
                    ParseActivityItems(resp, jObject);
                }
            }

            return resp;
        }

       /// <summary>
       /// Get he last heart rate data
       /// </summary>
       /// <returns></returns>
        public HeartRateItems GetHeartRates()
        {
            var resp = new HeartRateItems();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("heartrates").Result;
                if (response.IsSuccessStatusCode)
                {
                    resp = new HeartRateItems { Content = response.Content.ReadAsStringAsync().Result };
                                        
                    var jObject = JObject.Parse(resp.Content);

                    ParseMetaPart(resp, jObject);
                    ParseHRItems(resp, jObject);
                }
            }

            return resp;
        }

        private static void ParseHRItems(HeartRateItems resp, JObject jObject)
        {
            var hrItems = (JArray)jObject["data"]["items"];

            foreach (var item in hrItems)
            {
                var hrItem = JsonConvert.DeserializeObject<HRItem>(item.ToString());
                resp.Items.Add(hrItem);
            }
        }
        private void ParseActivityItems(GlobalActivityItem resp, JObject jObject)
        {
            var activeItems = (JArray)jObject["data"]["items"];

            foreach (var item in activeItems)
            {
                var tempItem = new ActivityItem();
                tempItem.date = item["date"].ToObject<int>();
                JToken hourDetails = item["details"]["hourly_totals"];
                foreach (JProperty hour in hourDetails)
                {                                           
                    var tempHour = JsonConvert.DeserializeObject<HourActivityDetail>(hour.Value.ToString());
                    tempHour.hour = int.Parse(hour.Name.Substring(hour.Name.Length - 2));
                    tempItem.details.Add(tempHour);                    
                }
                resp.Items.Add(tempItem);
            }
        }

        private static void ParseMetaPart(HeartRateItems resp, JObject jObject)
        {            
            var jToken = jObject.GetValue("meta");
            resp.Meta = JsonConvert.DeserializeObject<HeartRateMeta>(jToken.ToString());
        }

        private void ParseMetaPart(GlobalActivityItem resp, JObject jObject)
        {
            var jToken = jObject.GetValue("meta");
            resp.Meta = JsonConvert.DeserializeObject<ActivityMeta>(jToken.ToString());
        }
    }
}
