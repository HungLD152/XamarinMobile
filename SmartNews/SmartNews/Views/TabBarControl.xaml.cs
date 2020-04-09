using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SmartNews.Models;
using SmartNews.ViewModels;
using Xamarin.Forms;

namespace SmartNews.Views
{
    public partial class TabBarControl : ScrollView
    {
        private RssItemViewModel viewModel = new RssItemViewModel();
        RSSFeedItem rssItem;
        public TabBarControl(IList<TabItems> tabItems)
        {
            InitializeComponent();
            TabHost.OnTabItemClicked += TabHost_OnTabItemClicked;
        }

        private void TabHost_OnTabItemClicked(object sender, string e)
        {
            viewModel.Url = e;
            viewModel.LoadRssFeed();
        }

        private ObservableCollection<TabItems> GetTabItems()
        {
            var items = new ObservableCollection<TabItems>();
            items.Add(new TabItems()
            {
                Title = "24h.com.vn",
                Url = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss"
            });
            items.Add(new TabItems()
            {
                Title = "tinhte.vn",
                Url = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss"
            });
            items.Add(new TabItems()
            {
                Title = "thanhnien.vn",
                Url = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss"
            });
            items.Add(new TabItems()
            {
                Title = "trithuc.vn",
                Url = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss"
            });
            items.Add(new TabItems()
            {
                Title = "baochinhphu.vn",
                Url = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss"
            });

            return items;
        }
    }
    public class TabItems
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public Color ItemColor { get; set; }
    }
}
