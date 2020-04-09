using System;
using System.Collections.Generic;
using System.ComponentModel;
using VnXNews.ViewModels;
using Xamarin.Forms;

namespace VnXNews.Views
{
    public partial class MainPageCustom : ContentPage
    {
        public string Url { get; set; }
        private RssItemViewModel viewModel = new RssItemViewModel();
        public MainPageCustom()
        {
            InitializeComponent();
            BindingContext = viewModel;
            //Url = TabHost.Parameter;
            //TabHost.Parameter = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss";
            TabHost.OnTabItemClicked += TabHost_OnTabItemClicked;
        }

        private void TabHost_OnTabItemClicked(object sender, string e)
        {
            viewModel.Url = e;
            viewModel.LoadRssFeed();
        }

        //Button click show data
        private void TabButtonClicked(object sender, EventArgs e)
        {
        }
    }
}
