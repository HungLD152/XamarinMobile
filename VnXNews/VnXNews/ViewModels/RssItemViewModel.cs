using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Input;
using System.Xml.Linq;
using VnXNews.Models;
using Xamarin.Forms;

namespace VnXNews.ViewModels
{
    public class RssItemViewModel : BaseViewModel
    {
        
        public string Url { get; set; }
        public string Parameter { get; set; }
        public string searchText { get; set; }
        public ObservableCollection<RSSFeedItem> Items { get; set; } = new ObservableCollection<RSSFeedItem>();
        bool isRefreshing;

        public RssItemViewModel()
        {
            RefreshCommand = new Command(
                execute: () =>
                {
                   LoadRssFeed();
                },
                canExecute: () =>
                {
                    return !IsRefreshing;
                });

        }

        #region property RefreshCommand
        public ICommand RefreshCommand { private set; get; }

        public bool IsRefreshing
        {
            set { SetProperty(ref isRefreshing, value); }
            get { return isRefreshing; }
        }
        #endregion
        #region Load LoadRssFeed url rss
        public void LoadRssFeed()
        {
            WebRequest request = WebRequest.Create(Url);
            request.BeginGetResponse((args) =>
            {
                // Download XML.
                Stream stream = request.EndGetResponse(args).GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string xml = reader.ReadToEnd();

                // Parse XML to extract data from RSS feed.
                XDocument doc = XDocument.Parse(xml);
                XElement rss = doc.Element(XName.Get("rss"));
                XElement channel = rss.Element(XName.Get("channel"));

                // Set Title property.
                Title = channel.Element(XName.Get("title")).Value;

                // Set Items property.
                List<RSSFeedItem> list =
                    channel.Elements(XName.Get("item")).Select((XElement element) =>
                    {
                        return new RSSFeedItem()
                        {
                            Title = element.Element(XName.Get("title")).Value,
                            Description = element.Element(XName.Get("description")).Value,
                            Link = element.Element(XName.Get("link")).Value,
                            PubDate = element.Element(XName.Get("pubDate")).Value,
                            Thumbnail = ""
                        };
                    }).ToList();
                list.Add(new RSSFeedItem()
                {
                    Title = "TopCách ly toàn xã hội từ 1/4 trên toàn quốc: Người dân cần tuân thủ những gì?",
                    Description = "Cách ly toàn xã hội từ 1/4 trên toàn quốc: Người dân cần tuân thủ những gì?",
                    Link = "https://www.24h.com.vn/tin-tuc-trong-ngay/cach-ly-toan-xa-hoi-tu-1-4-tren-toan-quoc-nguoi-dan-can-tuan-thu-nhung-gi-c46a1136809.html",
                    PubDate = "Wed, 01 Apr 2020 14:13:34 +0700",
                    Thumbnail = "https://gamek.mediacdn.vn/2017/smile-emojis-icon-facebook-funny-emotion-women-s-premium-long-sleeve-t-shirt-1500882676711.jpg"
                }) ;
                list.Add(new RSSFeedItem()
                {
                    Title = "Top1Cách ly toàn xã hội từ 1/4 trên toàn quốc: Người dân cần tuân thủ những gì?",
                    Description = "Cách ly toàn xã hội từ 1/4 trên toàn quốc: Người dân cần tuân thủ những gì?",
                    Link = "https://www.24h.com.vn/tin-tuc-trong-ngay/cach-ly-toan-xa-hoi-tu-1-4-tren-toan-quoc-nguoi-dan-can-tuan-thu-nhung-gi-c46a1136809.html",
                    PubDate = "Wed, 01 Apr 2020 14:13:34 +0700",
                    Thumbnail = "https://gamek.mediacdn.vn/2017/smile-emojis-icon-facebook-funny-emotion-women-s-premium-long-sleeve-t-shirt-1500882676711.jpg"
                });
                var lstItem = list.OrderByDescending(s => s.PubDateTime).ToList();
                try
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        Items = lstItem.Where(s => s.Title.ToLower().Contains(searchText.ToLower())).ToList().ToObservableCollection();
                    }
                    else
                    {
                        Items = lstItem.ToObservableCollection();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                // Set IsRefreshing to false to stop the 'wait' icon.
                IsRefreshing = false;
            }, null);
        }
        #endregion
    }
    #region ObservableExtensions
    public static class ObservableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> items)
        {
            var collection = new ObservableCollection<T>();
            foreach (var item in items)
                collection.Add(item);
            return collection;
        }
    }
    #endregion
   
}
