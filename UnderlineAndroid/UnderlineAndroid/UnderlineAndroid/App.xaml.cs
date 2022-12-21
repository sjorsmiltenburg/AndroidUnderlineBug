using System;
using UnderlineAndroid.Services;
using UnderlineAndroid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderlineAndroid
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
