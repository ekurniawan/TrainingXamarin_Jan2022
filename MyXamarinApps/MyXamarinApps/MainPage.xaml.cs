using MyXamarinApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        private async void btnActionSheet_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Dikirimkan ke?", "Cancel", "Delete",
                "Twitter", "Instagram", "TikTok", "Facebook");
            await DisplayAlert("Info", $"Anda memilih {result}", "OK");
        }

        private async void btnKirimNilai_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridLayoutPage(entryName.Text));
        }

        private async void btnSetUsername_Clicked(object sender, EventArgs e)
        {
            Global.Instance.username = "ekurniawan";
            Course myCourse = new Course
            {
                Title = "Xamarin Forms",
                Description = "Cross Platform Mobile Dev with Xamarin Forms",
                Price = 200
            };
            Global.Instance.myCourse = myCourse;
            await DisplayAlert("Info", "Username berhasil disimpan pada global var", "OK");
        }

        private async void btnSetPreference_Clicked(object sender, EventArgs e)
        {
            if (!Preferences.ContainsKey("username")){
                Preferences.Set("username", entryName.Text);
                await DisplayAlert("Info", "Preferences berhasil dibuat", "OK");
            }
        }
    }
}
