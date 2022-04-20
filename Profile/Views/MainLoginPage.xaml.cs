using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainLoginPage : ContentPage
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

        public void MyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPageView());
        }

        /*private void GoogleButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ());
        }*/


        
    }
}