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
    public class JawBoneActivityItemRepository : JawBoneRepo, Interfaces.IJawboneRepository
    {
        public ActivityItems GetActivity()
        {
            var resp = new ActivityItems();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", Authorization);
           
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("moves").Result;
                if (response.IsSuccessStatusCode)
                {
                    resp = new ActivityItems { content = response.Content.ReadAsStringAsync().Result };
                }
            }

            return resp;
        }

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
                    resp = new HeartRateItems { content = response.Content.ReadAsStringAsync().Result };

                    //var jsonSerializerSettings = new JsonSerializerSettings();
                    //jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    var jObject = JObject.Parse(resp.content);

                    ParseMetaPart(resp, jObject);
                    ParseHRItems(resp, jObject);
                }
            }

            return resp;
        }

        private static void ParseHRItems(HeartRateItems resp, JObject jObject)
        {
            var test = (JArray)jObject["data"]["items"];

            foreach (var item in test)
            {
                var temp = JsonConvert.DeserializeObject<HRItem>(item.ToString());//, jsonSerializerSettings);
                resp.items.Add(temp);
            }
        }

        private static void ParseMetaPart(HeartRateItems resp, JObject jObject)
        {            
            var jToken = jObject.GetValue("meta");
            resp.meta = JsonConvert.DeserializeObject<HeartRateMeta>(jToken.ToString());//, jsonSerializerSettings);
        }
    }
}
