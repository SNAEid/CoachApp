using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using App52.Model;
using Firebase.Database;
using Firebase.Database.Query;
namespace App52.Services
{
    public class DBFirebaseHome
    {
        FirebaseClient client;

        public DBFirebaseHome()
        {
            client = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<HomePage> getCoach()
        {
            var CoachData = client.Child("Time1").AsObservable<HomePage>().AsObservableCollection();

            return CoachData;
        }

            public async Task AddCoach(string time1, string date1,int id1,string title1)
        {
            HomePage c=new HomePage() { Time = time1 ,Date=date1,id=id1,Title=title1};
            await client.Child("Time1").PostAsync(c);
        }

    }
}