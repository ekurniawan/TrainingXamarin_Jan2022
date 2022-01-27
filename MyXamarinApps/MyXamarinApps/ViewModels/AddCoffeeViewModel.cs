using MvvmHelpers.Commands;
using MyXamarinApps.Services;
using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class AddCoffeeViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; set; }

        private ICoffee coffeeService;
        public AddCoffeeViewModel()
        {
            Title = "Add Coffee";
            SaveCommand = new AsyncCommand(Save);
            coffeeService = DependencyService.Get<ICoffee>();
        }

        private async Task Save()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(roaster))
            {
                return;
            }
            var newCoffee = new Coffee
            {
                Name = Name,
                Roaster = Roaster,
                Image = "luwak.png"
            };
            await coffeeService.Add(newCoffee);
            await Shell.Current.GoToAsync("..");
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string roaster;
        public string Roaster
        {
            get { return roaster; }
            set { SetProperty(ref roaster, value); }
        }

    }
}
