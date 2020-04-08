using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VnXNews.Models;
using VnXNews.Views;
using VnXNews.ViewModels;

namespace VnXNews.Views
{
    public partial class RssFeedItemPage : ContentPage
    {
        public string Url { get; set; }
        RssItemViewModel viewModel;
        RSSFeedItem rssItem;
        public RssFeedItemPage()
        {
            InitializeComponent();
            rssItem = new RSSFeedItem();
            viewModel = new RssItemViewModel();
            viewModel.Url = "https://tinhte.vn/rss/";
            //viewModel.Url = Url;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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
