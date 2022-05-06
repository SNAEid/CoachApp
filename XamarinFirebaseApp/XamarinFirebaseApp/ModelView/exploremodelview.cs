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

namespace XamarinFirebaseApp.ModelView
{
    public class exploremodelview : BaseViewModel

    {

        public string FistName { get; set; }

        public string LastName { get; set; }

    
        public string Course { get; set; }

        public string City { get; set; }
      
        public string Phone { get; set; }
        public string Email { get; set; }


       



        private ExploreServices Services;
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

        public exploremodelview()
        {
            Services = new ExploreServices();
            Coaches = Services.getCoach();
            AddCoachesCommand = new Command(async () => await AddCoachAsync(FistName, LastName, Course, City, Phone, Email));
        }
        private async Task AddCoachAsync(string fistName, string lastName, string course, string city, string phone,string Email)
        {
            await Services.AddCoach(fistName, lastName, course, city, phone,Email);
        }

     
    }
}








