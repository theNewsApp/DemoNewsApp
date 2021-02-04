using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoNewsApp
{
    public class NewsDetailsPageVM:BaseVM
    {
        private INavigation _navigation;
        private WebView webView;
        public NewsDetailsPageVM(INavigation navigation, string url, WebView webView)
        {
            _navigation = navigation;
            NewsUrl = url;
            this.webView = webView;
        }

        private string newsUrl;
        public string NewsUrl
        {
            get { return newsUrl;}
            set
            {
                newsUrl = value;
                OnPropertyChange("NewsUrl");
            }
        }
        public ICommand ForwardCommand => new Command(ForwardCommandImpl);

        private void ForwardCommandImpl(object obj)
        {
            if (webView.CanGoForward)
                webView.GoForward();
        }

        public ICommand BackCommand => new Command(BackCommandImpl);

        private void BackCommandImpl(object obj)
        {
            if (webView.CanGoBack)
                webView.GoBack();
            else
                _navigation.PopAsync();
        }

       
    }
}
