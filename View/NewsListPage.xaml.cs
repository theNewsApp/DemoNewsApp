using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoNewsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsListPage : ContentPage
    {
        private NewsListPageVM _newsListPageVM;
        public NewsListPage()
        {
            InitializeComponent();
            _newsListPageVM = new NewsListPageVM(this.Navigation);
            this.BindingContext = _newsListPageVM;

            
        }
        public void UpdateIsNewFeedAvailable(bool b)
        {
            (BindingContext as NewsListPageVM).IsNewFeedAvailable = b;
        }
        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var NewsFeed = e.Item as NewsFeed;
            (BindingContext as NewsListPageVM).ItemPaging(NewsFeed);
        }
    }
}