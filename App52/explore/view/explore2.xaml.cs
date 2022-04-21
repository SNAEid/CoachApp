using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using explore.modelview;
using Xamarin.Forms;
using explore.model;
using explore.view;
using Xamarin.Forms.Xaml;

namespace explore.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class explore2 : ContentPage
    {          

        public explore2()
        {
            InitializeComponent();
            BindingContext = new exploremodelview();

        }

       



      

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var mydetails = e.Item as Coaches;
            await Navigation.PushAsync(new CoachDetails(mydetails.Location, mydetails.FistName, mydetails.LastName, mydetails.Phone, mydetails.Course ,mydetails.email,mydetails.id));



        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "Cources")
            {
                vBox.Color = Color.Silver;
                pBox.Color = Color.FromHex("#FFA500");
                listView.IsVisible = false;
                Listview.IsVisible = true;
            }
            else
            {
                listView.IsVisible = true;

                Listview.IsVisible = false;


                vBox.Color = Color.FromHex("#FFA500");
                pBox.Color = Color.Silver;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}