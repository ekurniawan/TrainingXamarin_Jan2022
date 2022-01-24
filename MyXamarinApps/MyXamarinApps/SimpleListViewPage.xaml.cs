
using MyXamarinApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleListViewPage : ContentPage
    {
        private List<Course> lstLanguage;
        public SimpleListViewPage()
        {
            InitializeComponent();
            lstLanguage = new List<Course>()
            {
                new Course{Title="Xamarin Form",Description="Cross Platform Mobile App Dev"},
                new Course{Title="ASP Core Web API",Description="RESTful Web API"},
                new Course{Title ="Blazor Dev",Description="SPA web development with CSharp"}
            };
            lvData.ItemsSource = lstLanguage;
        }

        private void lvData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Course)e.Item;
            DisplayAlert("Info", $"Title: {data.Title} \n Desc: {data.Description}", "OK");

            ((ListView)sender).SelectedItem = null;
        }

        private async void btnCustomList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomListViewPage());
        }
    }
}