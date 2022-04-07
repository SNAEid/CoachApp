using App1.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyCal : ContentPage
    {
        public WeeklyCal()
        {
            InitializeComponent();

            var date = DateTime.Today;
            calendar.AppointmentsSource = new List<Appointment>{

                    new Appointment {
                        Title = "Meeting with Tom",
                        Detail = "Sea Garden",
                        StartDate = date.AddHours(10),
                        EndDate = date.AddHours(11),
                        Color = Color.Tomato
                    },
                    new Appointment {
                        Title = "Lunch with Sara",
                        Detail = "Restaurant",
                        StartDate = date.AddHours(12).AddMinutes(30),
                        EndDate = date.AddHours(14),
                        Color = Color.DarkTurquoise
                    },
                    new Appointment {
                        Title = "Elle Birthday",
                        StartDate = date,
                        EndDate = date.AddHours(12),
                        IsAllDay = true
                    }
                };
        }


      

        private void buttonViews_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MonthlyCal());
        }
    }
}