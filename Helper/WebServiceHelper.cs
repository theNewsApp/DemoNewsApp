using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoNewsApp
{
    public class WebServiceHelper
    {
        public RootObject Root { get; set; }
        public WebServiceHelper()
        {

        }

        public  ObservableCollection<NewsFeed> GetNewsFeeds(int pageSize=10,int page=1)
        {
            string url = WebServiceConstants.DOMAIN_NAME + "&apiKey=" + WebServiceConstants.API_KEY + "&pageSize=" + pageSize + "&page=" + page;
            
            ObservableCollection<NewsFeed> feeds = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var Response = new WebClient().DownloadString(url);
                    Root = JsonConvert.DeserializeObject<RootObject>(Response);
                    feeds = new ObservableCollection<NewsFeed>(Root.newsFeeds);
                }
                catch (WebException e)
                {
                    Console.Write("Internet not connected");
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }


            }

            return feeds;

        }
    }
}
