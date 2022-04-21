using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using explore.modelview;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace explore.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoachDetails : ContentPage
    {
        public CoachDetails(string   location, string   fistName,  string  lastName,  string phone,string course ,string email,string ID)
        {
            InitializeComponent();

            lasnameshow.Text = lastName;
            firsnameshow.Text = fistName;
            courseshow.Text = course;
            locationshow.Text = location;
            phonenumbershow.Text = phone;
            emailshow.Text = email;
            idshow.Text = ID;





            ImageButton imageButton = new ImageButton
            {
                Source = "XamarinLogo.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            




        }

        

        private void dateView_Clicked(object sender, EventArgs e)
        {
                      App.Current.MainPage = new DatesPage();

        }
    }
}