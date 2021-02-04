using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNewsApp
{
    public class NewsFeed
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
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("articles")]
        public IList<NewsFeed> newsFeeds { get; set; }
    }

}
