using System;
using System.Collections.Generic;
using System.ComponentModel;
using VnXNews.ViewModels;
using Xamarin.Forms;

namespace VnXNews.Views
{
    public partial class TabItem : StackLayout
    {
        public string Parameter { get; set; }
        public event EventHandler<string> OnTabItemClicked;

        public TabItem()
        {
            InitializeComponent();
        }

        private void OnContentTapped(object sender, EventArgs e)
        {
            OnTabItemClicked?.Invoke(this, Parameter);
        }

    }
}
