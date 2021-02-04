using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoNewsApp
{
    public partial class App : Application
    {
        private static NewsAppDatabase _database;
        private static Stopwatch stopWatch = new Stopwatch();
        private const int defaultTimespan = 1;
        private MainTabPage _MainTabPage;
        public App()
        {
            InitializeComponent();
            _MainTabPage = new MainTabPage();

            MainPage = _MainTabPage;
        }

        public static NewsAppDatabase Database
        {
            get
            {
                if (_database == null)
                    _database = new NewsAppDatabase();
                return _database;
            }
        }
        protected override void OnStart()
        {
            if (!stopWatch.IsRunning)
            {
                stopWatch.Start();
            }

            Device.StartTimer(new TimeSpan(0, 0, 30), () =>
            {
                

                if (stopWatch.IsRunning && stopWatch.Elapsed.Minutes >= defaultTimespan)
                {
                   
                    Device.BeginInvokeOnMainThread(() => {
                        string currentId = BackGroundTaskHelper.Instance.CurrentFeeds[0].title;
                        string recentId = new WebServiceHelper().GetNewsFeeds()[0].title;
                        
                    });

                    stopWatch.Restart();
                }

                
                return true;
            });
        }

        protected override void OnSleep()
        {
            stopWatch.Reset();
        }

        protected override void OnResume()
        {
            stopWatch.Start();
        }
    }
}
