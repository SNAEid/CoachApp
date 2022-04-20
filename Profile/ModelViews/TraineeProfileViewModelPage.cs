using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Profile.Models;
using Profile.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;


namespace Profile.ModelViews
{
    public class TraineeProfileViewModelPage : BaseViewModel
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public Uri Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string UserName
        {
            get { return $"{FistName} {LastName}"; }
            set { }
        }
        
        public DBFirebase services;
        public Command AddCoachesCommand { get; }
        public Command AddTimesCommand { get; }

        private ObservableCollection<TraineeProfileModelPage> _coaches = new ObservableCollection<TraineeProfileModelPage>();

        public ObservableCollection<TraineeProfileModelPage> Coaches
        {
            get { return _coaches; }
            set
            {
                _coaches = value;
                OnPropertyChanged("Coaches");
            }
        }
        private ObservableCollection<TraineeProfileModelPage> _Times = new ObservableCollection<TraineeProfileModelPage>();
        public ObservableCollection<TraineeProfileModelPage> Times
        {
            get { return _Times; }
            set
            {
                _Times = value;
                OnPropertyChanged("Times");
            }
        }
        

        public TraineeProfileViewModelPage()
        {
            services = new DBFirebase();
            
            Coaches = services.GetCoach();
            AddCoachesCommand = new Command(async () => await AddCoachAsync(Image, UserName, Email, Phone, Location));

            Times = services.GetTime();
            AddTimesCommand = new Command(async () => await AddTimeAsync(Date));
            
        }

        private async Task AddCoachAsync(Uri image, string userName, string email, string phone, string location)
        {
            await services.AddCoach(image, userName, email, phone, location);
        }
        private async Task AddTimeAsync(string date)
        {
            await services.AddTime(date);
        }
    }
}
