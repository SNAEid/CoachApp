using Firebase.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace LastCa
{
    public partial class MainPage : ContentPage
    {
      //FirebaseClient firbaseClient = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");
        public MainPage()
        {
            InitializeComponent();
            //  calendar.MinimumDate = new DateTime(1970, 1, 1);
            //  calendar.MaximumDate = new DateTime(2030, 1, 1);
            var date = DateTime.Today;
            calendar.AppointmentsSource = new List<Appointment>{
                    new Appointment 
                    {
                        Title = " Dance Training" ,
                        Detail = " C:Jenny",
                        StartDate = date.AddHours(10),
                        EndDate = date.AddHours(11),
                        Color = Color.Orange
                    }
            };

        }
    }
}
