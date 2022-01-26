using MvvmHelpers;
using MvvmHelpers.Commands;
using MyXamarinApps.DAL;
using MyXamarinApps.Shared;
using MyXamarinApps.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class CoffeeSQLiteViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; set; }
        public AsyncCommand AddCommand { get; set; }
        public AsyncCommand<Coffee> SelectCommand { get; set; }

        public CoffeeSQLiteViewModel()
        {
            Title = "Coffee SQLite";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            SelectCommand = new AsyncCommand<Coffee>(Selected);
        }

        private async Task Selected(Coffee coffee)
        {
            if (coffee == null)
                return;
            var route = $"{nameof(DetailCoffeeSQLPage)}?CoffeeId={coffee.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Add()
        {
            var route = $"{nameof(AddCoffeeSQLPage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Refresh()
        {
            IsBusy = true;
            Coffee.Clear();
            var results = await CoffeeSQLiteDAL.GetAllCoffee();
            Coffee.AddRange(results);
            IsBusy = false;
        }
    }
}
