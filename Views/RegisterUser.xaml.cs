using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterUser : ContentPage
    {
        UserRepository _userRepository = new UserRepository(); 
        public RegisterUser()
        {
            InitializeComponent();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                string confirmPassword = TxtConfirmPass.Text;


                


                if (string.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "Please enter your name ", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Please enter your email ", "Cancel");
                    return;
                }

                if (password.Length<6)
                {
                    await DisplayAlert("Warning", "password should be more 6 digit", "Cancel");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Please enter your password ", "Cancel");
                    return;
                }
                if (string.IsNullOrEmpty(confirmPassword))
                {
                    await DisplayAlert("Warning", "Please enter confirm password ", "Cancel");
                    return;
                }

                if (password != confirmPassword)
                {
                    await DisplayAlert("Warning", "password not match .. ", "Cancel");
                    return;
                }

                bool isSave = await _userRepository.Register(email, name, password);
                if (isSave)
                {
                    await DisplayAlert("Register user", "Regestiration compleated ", "ok");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Register user", "Regestiration faild ", "ok");

                }
            }
            catch(Exception exception)
            {
                if (exception.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Warning", "EMAIL_EXISTS", "ok");
                }
                else
                {
                    await DisplayAlert("Errore", exception.Message , "ok");
                }
            }

            
        }
    }
}