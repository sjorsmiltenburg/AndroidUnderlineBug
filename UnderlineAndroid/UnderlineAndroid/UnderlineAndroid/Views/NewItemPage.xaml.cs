using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnderlineAndroid.Models;
using UnderlineAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderlineAndroid.Views
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