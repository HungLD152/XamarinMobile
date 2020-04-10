using System;
using System.Collections.Generic;
using SmartNews.Models;
using SmartNews.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SmartNews.Views
{
    public partial class MainPageCustom : ContentPage
    {
        public string Url { get; set; }
        private RssItemViewModel viewModel = new RssItemViewModel();
        RSSFeedItem rssItem;
        public MainPageCustom()
        {
            InitializeComponent();
            BindingContext = viewModel;
            rssItem = new RSSFeedItem();
            //Url = TabHost.Parameter;
            //TabHost.OnTabItemClicked += TabHost_OnTabItemClicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var safeInsets = On<iOS>().SafeAreaInsets();
            safeInsets.Left = 0;
            Padding = safeInsets;
            viewModel.Url = "https://cdn.24h.com.vn/upload/rss/trangchu24h.rss";
            viewModel.LoadRssFeed();
        }
        private void TabHost_OnTabItemClicked(object sender, string e)
        {
            viewModel.Url = e;
            viewModel.LoadRssFeed();
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                // Deselect item.
                ((Xamarin.Forms.ListView)sender).SelectedItem = null;

                // Set WebView source to RSS item
                rssItem = (RSSFeedItem)args.SelectedItem;

                // For iOS 9, a NSAppTransportSecurity key was added to 
                //  Info.plist to allow accesses to EarthObservatory.nasa.gov sites.
                webView.Source = rssItem.Link;

                // Hide and make visible.
                ShowData.IsVisible = false;
                webLayout.IsVisible = true;
            }
        }

        void OnBackButtonClicked(object sender, EventArgs args)
        {
            // Hide and make visible.
            webLayout.IsVisible = false;
            ShowData.IsVisible = true;
        }
        //Button click show data
        private void TabButtonClicked(object sender, EventArgs e)
        {
        }
    }
}
