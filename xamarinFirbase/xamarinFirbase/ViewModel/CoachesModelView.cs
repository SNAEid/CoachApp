using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarinFirbase.Models;
using xamarinFirbase.services;
using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace xamarinFirbase.ModelView
{
    public class CoachesModelView : BaseViewModel

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan SaveTime { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

      

        private DBFirebase services;
        public Command AddCoachesCommand { get; }

        private ObservableCollection<Coach> _coaches = new ObservableCollection<Coach>();

        public ObservableCollection<Coach> Coaches
        {
            get { return _coaches; }
            set
            {
                _coaches = value;
                OnPropertyChanged();
            }
        }



        public CoachesModelView()
        {
            services = new DBFirebase();
            Coaches = services.getCoach();
            AddCoachesCommand = new Command(async () => await AddCoachAsync(FirstName, LastName , SaveTime, Age , Phone , Password));
        }
        private async Task AddCoachAsync(string firstName, string lastName, TimeSpan saveTime, int age , string phone , string password)
        {
            await services.AddCoach(firstName, lastName, saveTime, age ,phone, password);
        }

    }
}

    

        





