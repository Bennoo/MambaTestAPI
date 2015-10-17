using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MambaTestApi.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

                    dynamic jd = JsonConvert.DeserializeObject(resp.content);
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

                    dynamic test = JsonConvert.DeserializeObject(resp.content);
                }
            }

            return resp;
        }
    }
}
