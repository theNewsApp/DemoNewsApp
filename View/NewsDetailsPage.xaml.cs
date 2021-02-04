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
    public partial class NewsDetailsPage : ContentPage
    {
        private NewsDetailsPageVM _newsDetailsPageVM;
        public NewsDetailsPage(string url)
        {
            InitializeComponent();
            _newsDetailsPageVM = new NewsDetailsPageVM(this.Navigation,url,this.webView);
            this.BindingContext = _newsDetailsPageVM;
        }

        private void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            this.labelLoading.IsVisible = true;
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            this.labelLoading.IsVisible = false;
        }
    }
}