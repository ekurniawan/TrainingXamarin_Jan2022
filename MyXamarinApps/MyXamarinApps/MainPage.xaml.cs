using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarinApps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSimpleList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SimpleListViewPage());
        }

        private async void menuCustom_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomListViewPage());
        }

        private async void menuImage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewWithImagePage());
        }
    }
}
