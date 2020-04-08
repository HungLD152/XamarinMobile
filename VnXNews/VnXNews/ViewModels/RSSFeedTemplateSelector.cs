using System;
using VnXNews.Models;
using Xamarin.Forms;

namespace VnXNews.ViewModels
{
    public class RSSFeedTemplateSelector : DataTemplateSelector 
    {
        public DataTemplate ValidTemplate { get; set; }

        public DataTemplate InvalidTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is RSSFeedItem)
            {
                var data = item as RSSFeedItem;
                if (!string.IsNullOrEmpty(data.Thumbnail))
                    return InvalidTemplate;
            }
            return ValidTemplate;
        }
    }
}
