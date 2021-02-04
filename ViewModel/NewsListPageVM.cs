using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoNewsApp
{
    public class NewsListPageVM:BaseVM
    {
        private INavigation _navigation;
        private int count = 1;
        public NewsListPageVM(INavigation _navigation)
        {
            this._navigation = _navigation;
            InitializeFeeds();
            IsLoadMoreNeed = false;
            
        }

        public ICommand NewsClickCommand => new Command<NewsFeed>(NewsClickCommandImpl);

        private async void NewsClickCommandImpl(NewsFeed feed)
        {
            if (feed == null)
                return;
           await _navigation.PushAsync(new NewsDetailsPage(feed.url));
        }
        public ICommand LoadMoreCommand => new Command(LoadMoreImple);

        private async void LoadMoreImple(object obj)
        {
               count++;
               var newList = new WebServiceHelper().GetNewsFeeds(10, count);
               if (newList.Count > 0)
               {
                   IsLoadMoreNeed = false;
                   Feeds = new ObservableCollection<NewsFeed>(Feeds.Concat(newList));
               }
            else
            {
                LoadText = "Feed ended";
                await Task.Delay(1500);
                IsLoadMoreNeed = false;
            }
        }

        private bool isNewFeedAvailable;
        public bool IsNewFeedAvailable
        {
            get { return isNewFeedAvailable; }
            set
            {
                isNewFeedAvailable = value;
                OnPropertyChange("IsNewFeedAvailable");
            }
        }

        
        private string loadText = "Load more..";
        public string LoadText
        {
            get { return loadText; }
            set { loadText = value; OnPropertyChange("LoadText"); }
        }

        private  ObservableCollection<NewsFeed> _feeds;
        public  ObservableCollection<NewsFeed> Feeds
        {
            get { return _feeds; }
            set
            {
                _feeds = value;
                OnPropertyChange("Feeds");
            }
        }

        private bool isLoadMoreNeed;
        public bool IsLoadMoreNeed
        {
            get { return isLoadMoreNeed; }
            set
            {
                isLoadMoreNeed = value;
                OnPropertyChange("IsLoadMoreNeed");
            }
        }
        public void InitializeFeeds(int pageSize=10,int page=1)
        {
            Feeds = new WebServiceHelper().GetNewsFeeds(pageSize,page);
            BackGroundTaskHelper.Instance.CurrentFeeds = Feeds;
        }

        public void ItemPaging(NewsFeed feed)
        {
            if (feed == Feeds.Last())
            {
               
                IsLoadMoreNeed = true;
            }
        }
    }
}
