using System;
using System.Collections.Generic;
using VnXNews.Models;
using VnXNews.ViewModels;
using Xamarin.Forms;

namespace VnXNews.Views
{
    public partial class CollectionViewRssPage : ContentPage
    {
        public string Url { get; set; }
        RssItemViewModel viewModel;
        RSSFeedItem rssItem;
        public CollectionViewRssPage()
        {
        InitializeComponent();
        rssItem = new RSSFeedItem();
        viewModel = new RssItemViewModel();
        BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.Url = Url;
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
                rssLayout.IsVisible = false;
                webLayout.IsVisible = true;
            }
        }
        void OnBackButtonClicked(object sender, EventArgs args)
        {
            // Hide and make visible.
            webLayout.IsVisible = false;
            rssLayout.IsVisible = true;
        }
    }
}
