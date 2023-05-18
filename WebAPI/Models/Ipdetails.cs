using System;
using System.Collections.Generic;

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
    public class NewsApiParam
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Cotegary { get; set; } = "general";
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }

    public class NewsResponse
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }

    public class Source
    {
        public object id { get; set; }
        public string name { get; set; }
    }


}
