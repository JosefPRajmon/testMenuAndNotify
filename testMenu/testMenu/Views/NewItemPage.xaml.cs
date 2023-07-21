using System;
using System.Collections.Generic;
using System.ComponentModel;
using testMenu.Models;
using testMenu.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMenu.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}