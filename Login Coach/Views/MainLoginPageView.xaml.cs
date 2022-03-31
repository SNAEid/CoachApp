using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login_Coach.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainLoginPage : ContentPage
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void MyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPageView());
        }

        /*private void GoogleButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ());
        }*/



    }
}