using MvvmHelpers;
using MvvmHelpers.Commands;
using MyXamarinApps.Services;
using MyXamarinApps.Shared;
using MyXamarinApps.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class CoffeeViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; set; }
        public AsyncCommand AppearCommand { get; set; }
        public AsyncCommand AddCommand { get; set; }
        public AsyncCommand<Coffee> SelectCommand { get; set; }
        public AsyncCommand<Coffee> RemoveCommand { get; set; }


        private ICoffee coffeeService;
        public CoffeeViewModel()
        {
            Title = "Coffee Equipment";
            coffeeService = DependencyService.Get<ICoffee>();
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
            AppearCommand = new AsyncCommand(Appear);
            AddCommand = new AsyncCommand(Add);
            SelectCommand = new AsyncCommand<Coffee>(Selected);
            RemoveCommand = new AsyncCommand<Coffee>(Remove);
        }

        private async Task Remove(Coffee coffee)
        {
            var status = await Application.Current.MainPage.DisplayAlert("Confirmation", 
                "Are you sure want to delete ?", "Yes", "No");
            if (status)
            {
                await coffeeService.Remove(coffee.Id);
                //await Appear();
                Coffee.Remove(coffee);
            }
        }

        private async Task Selected(Coffee coffee)
        {
            if (coffee == null)
                return;
            var route = $"{nameof(DetailCoffeePage)}?CoffeeId={coffee.Id}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Add()
        {
            var route = $"{nameof(AddCoffeePage)}";
            await Shell.Current.GoToAsync(route);
        }

        private async Task Appear()
        {
            /*if (Coffee.Count == 0)
                await Refresh();*/
            Coffee.Clear();
            var data = await coffeeService.GetAll();
            Coffee.AddRange(data);
        }

        private async Task Refresh()
        {
            var current = Connectivity.NetworkAccess;
            if(current != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Info",
                    "Tidak ada koneksi internet", "OK");
            }

            IsBusy = true;
            await Task.Delay(1000);
            Coffee.Clear();
            var data = await coffeeService.GetAll();
            Coffee.AddRange(data);
            IsBusy = false;
        }
    }
}
