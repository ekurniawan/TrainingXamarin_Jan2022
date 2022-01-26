using MvvmHelpers.Commands;
using MyXamarinApps.DAL;
using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class AddCoffeeSQLiteViewModel : ViewModelBase
    {
        public AsyncCommand SaveCommand { get; set; }
        public AddCoffeeSQLiteViewModel()
        {
            Title = "Add Coffee";
            SaveCommand = new AsyncCommand(Save);
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string roaster;
        public string Roaster
        {
            get => roaster;
            set => SetProperty(ref roaster, value);
        }

        private async Task Save()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Roaster))
            {
                return;
            }

            var newCoffee = new Coffee
            {
                Name = Name,
                Roaster = Roaster
            };
            try
            {
                await CoffeeSQLiteDAL.AddCoffee(newCoffee);
                await Application.Current.MainPage.DisplayAlert("Info", $"Berhasil menambahkan {Name}", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
