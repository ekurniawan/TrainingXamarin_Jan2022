using MvvmHelpers;
using MyXamarinApps.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class CoffeeEquipmentViewModel:ViewModelBase
    {
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public AsyncCallback RefreshCommand { get; }

        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            Coffee = new ObservableRangeCollection<Coffee>();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybagmin.png";
        }

       
    }
}
