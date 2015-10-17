using System.Runtime.Serialization;

namespace MambaTestApi.Models
{
    public class HeartRateItems
    {
        public string content;
        public HeartRateMeta meta;      
    }

    [DataContract(Name="meta")]
    public class HeartRateMeta
    {
        [DataMember(Name = "user_xid")]
        public string user_xid { get; set; }
        [DataMember(Name = "message")]
        public string message { get; set; }
        [DataMember(Name = "code")]
        public int code { get; set; }
        [DataMember(Name = "time")]
        public int time { get; set; }
    }
}