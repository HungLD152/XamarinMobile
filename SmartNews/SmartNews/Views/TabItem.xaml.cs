using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace SmartNews.Views
{
    public partial class TabItem : StackLayout
    {

        public string TitleBar { get; set; }
        public string Parameter { get; set; }
        public event EventHandler<string> OnTabItemClicked;

        public TabItem()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnContentTapped(object sender, EventArgs e)
        {
            OnTabItemClicked?.Invoke(this, Parameter);
        }
    }
}
