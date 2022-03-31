using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App52.Model;
using App52.Services;
using MvvmHelpers;
using Firebase.Database;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace App52.ModelView
{
    public class ContinueRegesrtationModelView : BaseViewModel
    {

       
        public string Address { get; set; }

        private DBFirebase services;
        public Command AddCoachesCommandc { get; }

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


        public ContinueRegesrtationModelView()
        {
            services = new DBFirebase();
            Coaches = services.getCoach();
            AddCoachesCommandc = new Command(async () => await ContinueInformationAsync( Address));
        }
        private async Task ContinueInformationAsync(string address)
        {
            await services.ContinueInformation(address);
        }

    }
}
