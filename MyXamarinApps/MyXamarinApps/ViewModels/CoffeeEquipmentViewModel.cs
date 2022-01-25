using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyXamarinApps.ViewModels
{
    public class CoffeeEquipmentViewModel:BindableObject
    {
        public ICommand IncreaseCount { get; }
        public CoffeeEquipmentViewModel()
        {
            IncreaseCount = new Command(OnIncrease);
        }

        private void OnIncrease()
        {
            count++;
            CountDisplay = $"Anda klik {count} kali";
        }

        int count = 0;
        private string countDisplay = "Count Display";
        public string CountDisplay
        {
            get { return countDisplay; }
            set
            {
                if (value == countDisplay)
                    return;
                countDisplay = value;
                OnPropertyChanged();
            }
        }
    }
}
