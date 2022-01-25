using MvvmHelpers;
using MvvmHelpers.Commands;
using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class CoffeeEquipmentViewModel:ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string,Coffee>> CoffeeGroup { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavoriteCommand { get; set; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroup = new ObservableRangeCollection<Grouping<string, Coffee>>();
            var image = "luwak.png";

            Coffee.Add(new Coffee { Roaster = "Otten Coffee", Name = "Italian Roasted", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Aceh Gayo", Image = image });
            Coffee.Add(new Coffee { Roaster = "Blue Bottle", Name = "Darked Roasted", Image = image });
            Coffee.Add(new Coffee { Roaster = "Otten Coffee", Name = "Kenya Kiambu", Image = image });
            Coffee.Add(new Coffee { Roaster = "Yes Plz", Name = "Pike Market", Image = image });
            Coffee.Add(new Coffee { Roaster = "Otten Coffee", Name = "Toraja", Image = image });

            CoffeeGroup.Add(new Grouping<string, Coffee>("Otten Coffee",Coffee.Where(c=>c.Roaster== "Otten Coffee")));
            CoffeeGroup.Add(new Grouping<string, Coffee>("Blue Bottle", Coffee.Where(c => c.Roaster == "Blue Bottle")));
            
            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>(Favorite);
        }

        private async Task Favorite(Coffee coffee)
        {
            if (coffee == null)
                return;
            await Application.Current.MainPage.DisplayAlert("Favorite", $"{coffee.Roaster} - {coffee.Name}", "OK");
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
