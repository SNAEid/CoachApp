using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Services;
using XamarinFirebaseApp.Views;
using XamarinFirebaseApp.Views.CalenderView;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageview : ContentPage
    {



        public HomePageview()
        {
            InitializeComponent();

            listBox1.ItemsSource = new HomePageModelView().Coaches;
            

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {


            App.Current.MainPage = new Calender();




        }


        private void Calender_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AddAppointment();


        }

        private void ButtonHome_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePageview();


        }

        private void Profile_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new WeeklyCal());

        }

        private void Explore_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SearchExplorePage());

        }
    }
}