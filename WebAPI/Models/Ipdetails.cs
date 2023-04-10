namespace WebAPI.Models
{
    public class IPdetails
    {
        public string ip { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }
        public string readme { get; set; }
    }
    public static class Config
    {
        public static string DBCon { get; set; }
    }
}
