using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Model;
using XamarinFirebaseApp.ModelView;
using XamarinFirebaseApp.Views.Student;
using XFFireBaseApp;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        FirebaseClient client;


        string webAPIKey = "AIzaSyCTJth0-c-fan6T6tl0sLHglOiymBb5xsw";


        public LoginPage()
        {

            InitializeComponent();

        }


        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(TxtEmail.Text, TxtPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushModalAsync(new MyDashboardPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }


        }


        private async void registerTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CoachPage()); 
        }
    }
}