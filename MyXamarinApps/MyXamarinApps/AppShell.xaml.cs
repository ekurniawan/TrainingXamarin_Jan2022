using MyXamarinApps.Views;
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
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CoffeeEquipmentPage), typeof(CoffeeEquipmentPage));
            Routing.RegisterRoute(nameof(CoffeeSQLitePage),typeof(CoffeeSQLitePage));
            Routing.RegisterRoute(nameof(AddCoffeeSQLPage),typeof(AddCoffeeSQLPage));
            Routing.RegisterRoute(nameof(DetailCoffeeSQLPage), typeof(DetailCoffeeSQLPage));
        }
    }
}