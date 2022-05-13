using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Model;
using XamarinFirebaseApp.Services;
using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using XamarinFirebaseApp.Views;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using XamarinFirebaseApp.Models;

namespace XamarinFirebaseApp.ModelView
{
    internal class DatesModelView
    {
        public Guid AppointmentId { get; set; }
        public string IdCoach { get; set; }

        public string Title { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



        public DateTime Date { get; set; }






        private HomePageServices Services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<TDate> _coaches = new ObservableCollection<TDate>();



        public ObservableCollection<TDate> Coaches
        {
            get
            {


                return _coaches;
            }
            set
            {
                _coaches = value;
               // OnPropertyChanged();
            }
        }



        public DatesModelView()
        {
            Initialize();


        }
        public async Task Initialize()
        {
            Services = new HomePageServices();
            Coaches = Services.getCoach();
        }
    }

}
