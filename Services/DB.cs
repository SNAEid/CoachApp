using Calenders.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Calenders.Services
{
    public class DB
    {
        FirebaseClient client;

        public DB()
        {
            client = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<DBModel> getTime()
        {
            var TimeData = client.Child("Time1").AsObservable<DBModel>().AsObservableCollection();

            return TimeData;
        }

        public async Task AddTime(string date, string endTime1, string startTime1, int ID, string tit1)
        {
            DBModel c = new DBModel() { Date = date, EndTime1 = endTime1, StartTime1 = startTime1, id = ID, title1 = tit1 };
            await client.Child("Time1").PostAsync(c);
        }


    }
}