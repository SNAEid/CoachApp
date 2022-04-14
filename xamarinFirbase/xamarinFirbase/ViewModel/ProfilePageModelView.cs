using MvvmHelpers;
using MvvmHelpers.Commands;
using ReadDB.Model;
using ReadDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ReadDB.ModelView
{
    public class CoachProfileModelView : BaseViewModel

    {

        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
        public string Course { get; set; }


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

       
            public CoachProfileModelView()
            {
                services = new DBFirebase();
                Coaches = services.getCoach();
                AddCoachesCommand = new Command(async () => await AddCoachAsync(FistName, LastName, Email , Course , Phone));
            }
            private async Task AddCoachAsync(string firstName, string lastName, string email , string course , string phone )
            {
                await services.AddCoach(firstName, lastName,email , course , phone );
            }
        }
    }
