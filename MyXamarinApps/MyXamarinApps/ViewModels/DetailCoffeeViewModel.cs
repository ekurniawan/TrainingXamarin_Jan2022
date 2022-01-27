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
    [QueryProperty(nameof(CoffeeId),nameof(CoffeeId))]
    public class DetailCoffeeViewModel : ViewModelBase
    {
        public string CoffeeId { get; set; }
        public AsyncCommand RefreshCommand { get; set; }
        public AsyncCommand EditCommand { get; set; }
        public AsyncCommand DoneCommand { get; set; }

        private ICoffee coffeeService;
        public DetailCoffeeViewModel()
        {
            Title = "Detail Coffee";
            coffeeService = DependencyService.Get<ICoffee>();
            RefreshCommand = new AsyncCommand(Refresh);
            EditCommand = new AsyncCommand(Edit);
            DoneCommand = new AsyncCommand(Done);
        }

        private async Task Done()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task Edit()
        {
            var editCoffee = new Coffee
            {
                Name = Name,
                Roaster = Roaster,
                Image = "luwak.png"
            };
            try
            {
                await coffeeService.Edit(int.Parse(CoffeeId), editCoffee);
                await Done();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        private async Task Refresh()
        {
            int.TryParse(CoffeeId, out var result);
            var coffee = await coffeeService.GetById(result);

            Id = coffee.Id;
            Name= coffee.Name;
            Roaster= coffee.Roaster;
            Image= coffee.Image;
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
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

        private string image;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }


    }
}
