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

namespace XamarinFirebaseApp.ModelView
{
    public class HomePageModelView : BaseViewModel

    {

        public string CoachDate { get; set; }
        public string CoachCourse { get; set; }
        public string CoachEndTime1 { get; set; }
        public string CoachStartTime1 { get; set; }

        public string TraineeName { get; set; }

        public int coachid1 { get; set; }
        public string CoachCourse2 { get; set; }
        public string CoachCourse3 { get; set; }


        public string CoachEndTime2 { get; set; }

        public string CoachEndTime3 { get; set; }

        public string TraineeName2 { get; set; }
        public string TraineeName3 { get; set; }
        public int coachid3 { get; set; }
        public int coachid2 { get; set; }

        public string CoachStartTime2 { get; set; }
        public string CoachStartTime3 { get; set; }




        private HomePageServices services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<HomePage> _coaches = new ObservableCollection<HomePage>();

      

        public ObservableCollection<HomePage> Coaches
        {
            get {
                

                return _coaches;
                 }
            set
            {
                _coaches = value;
                OnPropertyChanged();
            }
        }



        public HomePageModelView()
        {

         

            services = new HomePageServices();
            Coaches = services.getCoach();
            
            AddCoachesCommand = new Command(async () => await AddCoachAsync(CoachDate, coachid1, CoachStartTime1, CoachEndTime1, CoachCourse, TraineeName, coachid2, CoachStartTime2, CoachEndTime2, CoachCourse2, TraineeName2, coachid3, CoachStartTime3, CoachEndTime3, CoachCourse3, TraineeName3));

        }


        private async Task AddCoachAsync(  string  date,int Coachid1,string coachStartTime1,string coachEndTime1,string coachCourse,string traineeName, int Coachid2, string coachStartTime2, string coachEndTime2, string coachCourse2, string traineeName2, int Coachid3, string coachStartTime3, string coachEndTime3, string coachCourse3, string traineeName3)
        {
            await services.AddCoach(  date,  Coachid1, coachStartTime1, coachEndTime1,  coachCourse,  traineeName,  Coachid2,  coachStartTime2,  coachEndTime2,  coachCourse2,  traineeName2,  Coachid3,  coachStartTime3,  coachEndTime3,  coachCourse3,  traineeName3);
        }
    }
}

    

        





