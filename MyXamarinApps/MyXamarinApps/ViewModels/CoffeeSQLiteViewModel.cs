using MvvmHelpers;
using MvvmHelpers.Commands;
using MyXamarinApps.DAL;
using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyXamarinApps.ViewModels
{
    public class CoffeeSQLiteViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCommand RefreshCommand { get; set; }

        public CoffeeSQLiteViewModel()
        {
            Title = "Coffee SQLite";
            Coffee = new ObservableRangeCollection<Coffee>();

            RefreshCommand = new AsyncCommand(Refresh);
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
