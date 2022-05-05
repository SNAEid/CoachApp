using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;


namespace XamarinFirebaseApp.Services
{
    internal class HomePageServices
    {


        FirebaseClient client;

        public HomePageServices()
        {
            client = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<HomePage> getCoach()
        {
            var CoachData = client.Child("Time1").AsObservable<HomePage>().AsObservableCollection();



            return CoachData;



        }



        public async Task AddCoach(string date, int Coachid1, string coachStartTime1, string coachEndTime1, string coachCourse, string traineeName, int Coachid2, string coachStartTime2, string coachEndTime2, string coachCourse2, string traineeName2, int Coachid3, string coachStartTime3, string coachEndTime3, string coachCourse3, string traineeName3)
        {
            HomePage c = new HomePage() { CoachDate = date, coachid1 = Coachid1, CoachStartTime1 = coachStartTime1, CoachEndTime1 = coachEndTime1, CoachCourse = coachCourse, TraineeName = traineeName, coachid2 = Coachid2, CoachStartTime2 = coachStartTime2, CoachEndTime2 = coachEndTime2, CoachCourse2 = coachCourse2, TraineeName2 = traineeName2, coachid3 = Coachid3, CoachStartTime3 = coachStartTime3, CoachEndTime3 = coachEndTime3, CoachCourse3 = coachCourse3, TraineeName3 = traineeName3 };
            await client.Child("Time1").PostAsync(c);
        }
    }
}
