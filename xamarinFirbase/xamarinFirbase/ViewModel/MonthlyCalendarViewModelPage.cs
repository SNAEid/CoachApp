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
        EventCollection _events;

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
            Items = new ObservableCollection<MonthlyCalendarModelPage>();

            var GetItems = (await fc
              .Child("Time1")
              .OnceAsync<MonthlyCalendarModelPage>()).Select(item => new MonthlyCalendarModelPage
              {
                  Description = item.Object.Description,
                  Date = item.Object.Date,
                  Title = item.Object.Title
              });

            int count = 0;
            foreach (var item in GetItems)
            {

                Items.Add(item);
                count++;
                if (count >= listcount)
                    break;
            }
        }

        private async void Delete()
        {
            var selected = Items.Where(k => k.Date == _selectedDate.Date).FirstOrDefault();

            await fc.Child("Time1").Child(selected.Title).DeleteAsync();

            Items.Remove(selected);
        }

        private ObservableCollection<MonthlyCalendarModelPage> items;
        public ObservableCollection<MonthlyCalendarModelPage> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public EventCollection Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged();
            }
        }

    }
}
