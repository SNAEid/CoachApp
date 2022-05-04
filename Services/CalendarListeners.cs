using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Monthly_Calenar.Models;
using Firebase.Database;
using Firebase.Database.Query;
namespace Monthly_Calenar.services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://test499-2b0e7-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<MonthlyCalendarModelPage> getCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<MonthlyCalendarModelPage>()
                .AsObservableCollection();
            return CoachData;
        }

        public ObservableCollection<MonthlyCalendarModelPage> getAppointment()
        {
            var CoachData = client.Child("TDate").AsObservable<MonthlyCalendarModelPage>()
                .AsObservableCollection();
            return CoachData;
        }



        public async Task AddCoach(string city, string coachID, string course, string email, string firstName, string password, string phone)
        {
            MonthlyCalendarModelPage c = new MonthlyCalendarModelPage()
            {
                City = city,
                CoachId = coachID,
                Course = course,
                Email = email,
                FirstName = firstName,
                Password = password,
                Phone = phone
            };
            await client.Child("Coach").PostAsync(c);
        }

        public async Task AddTime(string appointmentId, DateTime date, string endTime, string startTime, string title)
        {
            MonthlyCalendarModelPage c = new MonthlyCalendarModelPage()
            {
                AppointmentId = appointmentId,
                Date = date,
                EndTime = endTime,
                StartTime = startTime,
                Title = title
            };
            await client.Child("TDate").PostAsync(c);
        }

    }
}