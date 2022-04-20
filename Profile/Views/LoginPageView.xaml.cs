﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Profile.ViewModels;

namespace Profile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageView : ContentPage
    {
        public LoginPageView()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

        private void MyLoginCommand_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FitnessLevelView());
        }
    }
}