﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Profile.Views;

namespace Profile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new LoginPageView());
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
