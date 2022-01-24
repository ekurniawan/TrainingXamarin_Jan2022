using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridLayoutPage : ContentPage
    {
        public GridLayoutPage()
        {
            InitializeComponent();

            //imgLogo.Source = ImageSource.FromFile(Path.Combine("images", "monyet1.png"));

            imgLogo.Source = ImageSource.FromUri(new Uri("https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg")); 
        }

        private string _nama;
        public GridLayoutPage(string nama)
        {
            InitializeComponent();
            imgLogo.Source = ImageSource.FromUri(new Uri("https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg"));

            _nama = nama;

            entryFirstName.Text = _nama;
        }

        private async void btnGetUsername_Clicked(object sender, EventArgs e)
        {
            var username = Global.Instance.username;
            await DisplayAlert("Info", $"Username: {username}", "OK");
        }

        private async void btnGetCourse_Clicked(object sender, EventArgs e)
        {
            var data = Global.Instance.myCourse;
            await DisplayAlert("Info", $"Title: {data.Title} - Price: {data.Price}", "OK");
        }

        private async void btnGetPreference_Clicked(object sender, EventArgs e)
        {
            if (Preferences.ContainsKey("username"))
            {
                var username = Preferences.Get("username", String.Empty);
                await DisplayAlert("Info", $"Nilai username: {username}", "OK");
            }
            else
            {
                await DisplayAlert("Info", "Object PReferences belum ada","OK");
            }
        }

        private async void btnClearPreference_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("username");
            Preferences.Clear();
            await DisplayAlert("Info", "Semua data preference berhasil dihapus", "OK");
        }
    }
}