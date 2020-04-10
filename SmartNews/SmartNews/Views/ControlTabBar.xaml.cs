using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SmartNews.Views
{
    public partial class ControlTabBar : ScrollView
    {
        public string Title { get; set; }
        public event EventHandler<string> OnTabBarClicked;
        private static BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(ControlTabBar), null, BindingMode.TwoWay);
        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ControlTabBar()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ItemsSourceProperty.PropertyName)
            {
                var item = new TabItem();
                var viewcell = new ViewCell();
                ItemsSource = GetTabItems();
                BindableLayout.SetItemsSource(viewcell, ItemsSource);
                item.OnTabItemClicked += Item_OnTabItemClicked;
            }
        }

        private void OnTabbarTapped(object sender, EventArgs e)
        {
            OnTabBarClicked?.Invoke(this, Title);
        }

        private void Item_OnTabItemClicked(object sender, string e)
        {
            throw new NotImplementedException();
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
