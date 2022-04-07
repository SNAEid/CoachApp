using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Newtonsoft.Json;
using Firebase.Auth;
using XamarinFirebaseApp.Views.View;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAppointment : ContentPage
    {
        public string WebAPIkey = "AIzaSyDpJwmEi_i7lI2gDil8epd2AoPgUqiYfK4";

        public AddAppointment()
        { 
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
            BindingContext = new AddAppointmentVM();
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
                var UserId = savedfirebaseauth.User.LocalId;


                await SecureStorage.SetAsync("UserId", UserId);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }



        }

        private async void Onbtn_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Home_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new NavigationPage(new WelcomPage());

        }

        private void ButtonHome_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePageview();


        }

        private void Profile_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new AddAppointment());

        }

        private void Explore_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SearchExplorePage());

        }
    }

   

   
}