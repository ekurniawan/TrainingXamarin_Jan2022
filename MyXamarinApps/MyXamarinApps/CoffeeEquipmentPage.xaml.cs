﻿using MyXamarinApps.ViewModels;
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
       
        public CoffeeEquipmentPage()
        {
            InitializeComponent();
            BindingContext = new CoffeeEquipmentViewModel();
        }
    }
}