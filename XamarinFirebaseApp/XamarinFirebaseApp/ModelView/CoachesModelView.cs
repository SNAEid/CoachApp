using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Model;
using XamarinFirebaseApp.Services;
using XamarinFirebaseApp.Views;

using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XamarinFirebaseApp.ModelView
{
    public class CoachesModelView : BaseViewModel

    {

        public string CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public string City { get; set; }
        public string Course { get; set; }




        private DBFirebase Services;
        public Command AddCoachesCommand { get; }
        public Command AddCoachIdCommand { get; }


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
            Services = new DBFirebase();
            Coaches = Services.getCoaches();
            AddCoachesCommand = new Command(async () => await AddCoachesAsync(CoachId, FirstName, LastName , Email , Phone , Password , City , Course));
        }
        private async Task AddCoachesAsync(string coachId,  string firstName, string lastName, string email , string phone , string password , string city , string course)
        {
            await Services.AddCoaches( coachId, firstName, lastName, email ,phone, password , city , course);
        }

       

    }
}

    

        





