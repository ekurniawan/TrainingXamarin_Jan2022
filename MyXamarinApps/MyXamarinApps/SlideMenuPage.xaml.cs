using MyXamarinApps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlideMenuPage : ContentPage
    {
        public ListView ListView;
        public SlideMenuPage()
        {
            InitializeComponent();
            ListView = lvMenuSide;
            BindingContext = new SlideMenuPageViewModel();
        }
    }

    class SlideMenuPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MyMenuItem> MenuItems { get; set; }

        public SlideMenuPageViewModel()
        {
            MenuItems = new ObservableCollection<MyMenuItem>(new[]
            {
                new MyMenuItem(){Id=0,Title="Main Page",TargetType=typeof(MainPage),ImageIcon="ic_add.png"},
                new MyMenuItem(){Id=1,Title="Custom List",TargetType=typeof(CustomListViewPage),ImageIcon="ic_add.png"},
                new MyMenuItem(){Id=2,Title="Tab Page",TargetType=typeof(MyTabbedPage),ImageIcon="ic_add.png"},
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}