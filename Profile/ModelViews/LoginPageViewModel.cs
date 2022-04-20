using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Profile.ViewModels
{
    public class LoginPageViewModel
    {
        public string ErrorMessage{ get; set;}

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public ICommand LoginCommand { get; set; }
        public LoginPageViewModel()
        {
            LoginCommand = new Command(() => Login());
        }
        public async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                ErrorMessage = "Email is Empty";
            }
            else if (string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Password is Empty";
            }
            else
            {
                ErrorMessage = String.Empty;
                await App.Current.MainPage.DisplayAlert("welcom", "Hey  " + Email, "OK");
            }
        }

    }
}
