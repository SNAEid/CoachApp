using Calenders.Model;
using Calenders.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Calenders.ModelView
{
    public class DBModelView : BaseViewModel
    {
        public string Date { get; set; }
        public string EndTime1 { get; set; }
        public string StartTime1 { get; set; }
        public int id { get; set; }
        public string title1 { get; set; }

        private DB services;
        public Command AddTimeCommand { get; }

        private ObservableCollection<DBModel> DataBase = new ObservableCollection<DBModel>();
         public ObservableCollection<DBModel> db
        {
            get
            { 
                return DataBase;
            }
            set 
            {
                DataBase = value;
                OnPropertyChanged();
            }

        }
        public DBModelView()
        {
            services = new DB();
            db = services.getTime();
            AddTimeCommand = new Command( async () => await AddTimeAsync (Date , EndTime1 , StartTime1 , id , title1));
        }
        private async Task AddTimeAsync ( string date , string endTime1 , string startTime1 , int ID , string tit1 )
        {
            await services .AddTime ( date , endTime1 , startTime1 , ID , tit1 );
        }

    }
}
