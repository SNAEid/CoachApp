using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_LancheApp.view;

namespace XF_LancheApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView());
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
