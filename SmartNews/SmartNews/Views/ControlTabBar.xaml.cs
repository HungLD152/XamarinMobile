using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using SmartNews.ViewModels;
using Xamarin.Forms;

namespace SmartNews.Views
{
    public partial class ControlTabBar : ScrollView
    {
        private RssItemViewModel viewModel = new RssItemViewModel();
        public string TitleBar { get; set; }
        public string Parameter { get; set; }
        public event EventHandler<string> OnTabBarClicked;
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList<TabBarItemModel>), typeof(ControlTabBar), null, BindingMode.TwoWay);
        public IList<TabBarItemModel> ItemsSource
        {
            get { return (IList<TabBarItemModel>)GetValue(ItemsSourceProperty); }
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
                Container.Children.Clear();
                if (ItemsSource?.Count > 0)
                    foreach (var data in ItemsSource)
                    {
                        //var item = new TabItem(data.TitleBar, data.Url);
                        var item = new TabItem() { TitleBar = data.TitleBar, Parameter = data.Url };
                        item.OnTabItemClicked += Item_OnTabItemClicked;
                        Container.Children.Add(item);
                    }
            }
        }

        private void Item_OnTabItemClicked(object sender, string e)
        {
            
        }


    }
    public class TabBarItemModel
    {
        public string TitleBar { get; set; }
        public string Url { get; set; }
        public Color ItemColor { get; set; }
    }
}
