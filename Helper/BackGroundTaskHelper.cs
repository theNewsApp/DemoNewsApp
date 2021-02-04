using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DemoNewsApp
{
    public sealed class BackGroundTaskHelper
    {
        BackGroundTaskHelper()
        {
        }
        private static readonly object padlock = new object();
        private static BackGroundTaskHelper instance = null;
        public static BackGroundTaskHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new BackGroundTaskHelper();
                        }
                    }
                }
                return instance;
            }
        }

        public ObservableCollection<NewsFeed> CurrentFeeds { get; set; }
       
    }
}
