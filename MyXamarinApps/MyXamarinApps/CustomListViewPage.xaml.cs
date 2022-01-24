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
    public partial class CustomListViewPage : ContentPage
    {
        private List<Course> lstCourse;
        public CustomListViewPage()
        {
            InitializeComponent();
            lstCourse = new List<Course>()
            {
                new Course{Title="Xamarin Form",Description="Cross Platform Mobile App Dev",
                Pic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg",Price=200},
                new Course{Title="ASP Core Web API",Description="RESTful Web API",
                Pic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg",Price=250},
                new Course{Title ="Blazor Dev",Description="SPA web development with CSharp",
                Pic="https://i0.wp.com/blog.mzikmund.com/wp-content/uploads/2019/02/microsoft-xamirin-1.jpg",Price=300}
            };
            lvCourse.ItemsSource = lstCourse;
        }

        private void lvCourse_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Course)e.Item;
            DisplayAlert("Info", $"{data.Title} - {data.Price}", "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}