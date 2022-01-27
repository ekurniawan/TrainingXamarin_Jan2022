using MyXamarinApps.Services;
using MyXamarinApps.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //dependency injection
            DependencyService.Register<ICoffee, CoffeeService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
