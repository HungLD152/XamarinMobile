using System;

namespace VnXNews.Models
{
    public class Item
    {
        public string Id { get; set; }
        public int IdRss { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }
        public string AuthorEmail { get; set; }
    }
}