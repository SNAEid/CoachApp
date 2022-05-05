using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFireBaseApp;

namespace XamarinFirebaseApp.Views.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomPage : ContentPage
    {
        public WelcomPage()
        {
            InitializeComponent();
        }

        

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new MainPage());


        }
    }
}