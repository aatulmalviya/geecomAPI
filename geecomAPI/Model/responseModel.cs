using System;

namespace geecomAPI.Model
{
    public class responseHeaderModel
    {
        public int responseHeaderID { get; set; }
        public int orgID { get; set; }
        public int farmerID { get; set; }
        public int questionSetID { get; set; }
        public string location { get; set; }
        public DateTime addTime { get; set; }
        public string addUser { get; set; }
        public DateTime? updateTime { get; set; }
        public string? updateUser { get; set; }


    }
    public class responseDetailModel
    {
        public int respID { get; set; }
        public int responseHeaderID { get; set; }
        public int questionID { get; set; }
        public string response { get; set; }
        public DateTime addTime { get; set; }
        public string addUser { get; set; }
    }
}
