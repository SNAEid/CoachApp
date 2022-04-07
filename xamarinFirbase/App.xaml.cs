using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinFirbase.Views;

namespace xamarinFirbase
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =
                new Views.CoachPage();
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
