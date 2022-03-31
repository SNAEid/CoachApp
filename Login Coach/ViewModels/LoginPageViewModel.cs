using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Login_Coach.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private string _errorMessage;
        public event PropertyChangedEventHandler PropertyChanged;
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                this._errorMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
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

