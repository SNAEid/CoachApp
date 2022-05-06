using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Views;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoachDetails : ContentPage
    {
        public CoachDetails(string city, string fistName,  string lastName,  string phone, string course ,string email,string ID)
        {
            InitializeComponent();

            lasnameshow.Text = lastName;
            firsnameshow.Text = fistName;
            courseshow.Text = course;
            locationshow.Text = city;
            phonenumbershow.Text = phone;
            emailshow.Text = email;
            idshow.Text = ID;

            ImageButton imageButton = new ImageButton
            {
                Source = "XamarinLogo.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            listBox1.ItemsSource = new HomePageModelView().Coaches;






        }



        private void dateView_Clicked(object sender, EventArgs e)
        {
                      App.Current.MainPage = new DatesPage();

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