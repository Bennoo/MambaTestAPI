using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MambaTestApi.Models
{
    public class HeartRateItems
    {
        public string content;
        public HeartRateMeta meta;
        public List<HRItem> items = new List<HRItem>();
    }

    public class HeartRateMeta
    {
        public string user_xid { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public int time { get; set; }
    }

    public class HRItem
    {
        public int resting_heartrate { get; set; }
        public int date{ get; set; }
    }
}