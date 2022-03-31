using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Login_Coach.Views;

namespace Login_Coach
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainLoginPage());
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
