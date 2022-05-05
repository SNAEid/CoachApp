using System;
using System.Collections.Generic;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFirebaseApp;
using XamarinFirebaseApp.ModelView;
using XamarinFirebaseApp.Views.View;

namespace XFFireBaseApp
{
    public partial class MyDashboardPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDpJwmEi_i7lI2gDil8epd2AoPgUqiYfK4";
        public MyDashboardPage()
        {
            InitializeComponent();
            BindingContext = new CoachesModelView() ; 
            GetProfileInformationAndRefreshToken();
        }

        async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                var UserId = savedfirebaseauth.User.LocalId ;

                await SecureStorage.SetAsync("UserId", UserId); 
                DisplayAlert("Your User Id ", UserId, "cancel");



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }



        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new WelcomPage());

        }


    }
}