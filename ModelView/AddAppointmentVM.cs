using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Models;
using XamarinFirebaseApp.Services;
using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace XamarinFirebaseApp.ModelView
{
    public class AddAppointmentVM : BaseViewModel

    {
        public string IdCoach { get; set; }

        public Guid AppointmentId { get; set; }

        public string Title { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public DateTime Date { get; set; }

      

        private TDateDB Services;
        public Command AddTimeCommand { get; }

        private ObservableCollection<TDate> _tDates = new ObservableCollection<TDate>();

        public ObservableCollection<TDate> Appointments
        {
            get { return _tDates; }
            set
            {
                _tDates = value;
                OnPropertyChanged();
            }
        }

        public string GetUserId { get; private set; }

        public AddAppointmentVM()
        {
            Services = new TDateDB();
            Appointments = Services.GetTDate();
            AddTimeCommand = new Command(async () => await AddTimeAsync(IdCoach, Title, StartTime, EndTime, Date));
        }
        private async Task AddTimeAsync(string idCoach , string title , TimeSpan startTime, TimeSpan endTime, DateTime date)
        {

            try
            {
                var oauthToken = await SecureStorage.GetAsync("UserId");
                GetUserId = oauthToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await Services.AddTDate(idCoach ,title, startTime, endTime, date);
        }

    }
}

    

        





