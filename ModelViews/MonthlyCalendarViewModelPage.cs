using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Monthly_Calenar.Models;
using Monthly_Calenar.Views;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Models;
using Firebase.Database.Query;
using Firebase.Database;
using System.Threading.Tasks;

namespace Monthly_Calenar.ModelViews
{
    public class MonthlyCalendarViewModelPage : BaseNotifyPropertyChanged
    {
        DateTime _selectedDate;

        public static string FirebaseClient = "https://my-coach-9875d-default-rtdb.firebaseio.com/Time1";
        public static string FrebaseSecret = "sm1gqTGJIum4vzfV3sDpzeIWSjZNaaUcLE87LqOn";

        public FirebaseClient fc = new FirebaseClient(FirebaseClient,
                                   new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(FrebaseSecret) });

        public ICommand AppointmentAddCommand { get; private set; }
        public ICommand AppointmentDeleteCommand { get; private set; }

        public int listcount = 5;

        public MonthlyCalendarViewModelPage()
        {
            SelectedDate = DateTime.Now;
            Events = new EventCollection();

            AppointmentAddCommand = new Command(PerformRefresh);
            AppointmentDeleteCommand = new Command(Delete);
            GetData();
        }

        private void PerformRefresh()
        {
            GetData();
        }

        private async void GetData()
        {
            Appointment = new ObservableCollection<MonthlyCalendarModelPage>();

            var GetItems = (await fc
              .Child("TDate")
              .OnceAsync<MonthlyCalendarModelPage>()).Select(item => new MonthlyCalendarModelPage
              {
                  AppointmentId =item.Object.AppointmentId,
                  Date = item.Object.Date,
                  EndTime = item.Object.EndTime,
                  StartTime = item.Object.StartTime,
                  Title = item.Object.Title
              });

            int count = 0;
            foreach (var item in GetItems)
            {

                Coach.Add(item);
                count++;
                if (count >= listcount)
                    break;
            }
        }

        private async void Delete()
        {
            var selected = Appointment.Where(k => k.Date == _selectedDate.Date).FirstOrDefault();

            await fc.Child("TDate").Child(selected.Title).DeleteAsync();

            Appointment.Remove(selected);
        }

        
        private ObservableCollection<MonthlyCalendarModelPage> coach = new ObservableCollection<MonthlyCalendarModelPage>();

        public ObservableCollection<MonthlyCalendarModelPage> Coach
        {
            get; set;
        }


        private ObservableCollection<MonthlyCalendarModelPage> appointment = new ObservableCollection<MonthlyCalendarModelPage>();

        public ObservableCollection<MonthlyCalendarModelPage> Appointment
        {
            get; set;
        }



        public DateTime SelectedDate
        {
            get; set;
        }

        public EventCollection Events
        {
            get; set;
        }

    }
}