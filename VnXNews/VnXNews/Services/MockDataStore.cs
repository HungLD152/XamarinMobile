using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using VnXNews.Models;

namespace VnXNews.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Trục lợi dịch Covid-19, hàng nghìn tài khoản bị Amazon đóng băng", Description="Hàng nghìn tài khoản bán hàng đã bị tập đoàn bán lẻ Amazon xóa sổ khi tìm cách trục lợi bằng hành vi tăng giá các mặt hàng thiết yếu được nhiều người tìm mua." }
            };
        }

        public async Task<List<Item>> ParseFeed()
        {
            return await Task.Run(() =>
            {
                var rss = "https://www.24h.com.vn/upload/rss/trangchu24h.rss";
                var xdoc = XDocument.Parse(rss);
                var id = 0;
                return (from item in xdoc.Descendants("item")
                        select new Item
                        {
                            Title = (string)item.Element("title"),
                            Description = (string)item.Element("description"),
                            Link = (string)item.Element("link"),
                            PublishDate = (string)item.Element("pubDate"),
                            AuthorEmail = (string)item.Element("author"),
                            IdRss = id++
                        }).ToList();
            });
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}