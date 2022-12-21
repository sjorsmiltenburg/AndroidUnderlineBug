using System.ComponentModel;
using UnderlineAndroid.ViewModels;
using Xamarin.Forms;

namespace UnderlineAndroid.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}