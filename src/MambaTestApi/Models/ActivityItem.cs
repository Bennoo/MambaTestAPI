using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MambaTestApi.Models
{
    public class GlobalActivityItem
    {
        public string Content { get; set; }
        public ActivityMeta Meta { get; set; }
        public List<ActivityItem> Items { get; set; } = new List<ActivityItem>();
    }

    public class ActivityMeta
    {
        public string user_xid { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public int time { get; set; }
    }

    public class ActivityItem
    {
        [JsonIgnore]
        public List<HourActivityDetail> details { get; set; } = new List<HourActivityDetail>();
        public int date { get; set; }
    }

    public class HourActivityDetail
    {
        [JsonIgnore]
        public int hour { get; set; }
        public double distance { get; set; }
        public int active_time { get; set; }
        public double calories{ get; set; }
        public int inactive_time { get; set; }
        public int longest_idle_time { get; set; }
        public int longest_active_time { get; set; }
        public int steps { get; set; }
    }
}
