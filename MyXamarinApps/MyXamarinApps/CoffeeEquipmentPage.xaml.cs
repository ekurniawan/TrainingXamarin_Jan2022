using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXamarinApps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeEquipmentPage : ContentPage
    {
        public ICommand IncreaseCount { get; }
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
            IncreaseCount = new Command(OnIncrease);
            BindingContext = this;
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
            set {
                if (value == countDisplay)
                    return;
                countDisplay = value; 
                OnPropertyChanged();
            }
        }
        
    }
}