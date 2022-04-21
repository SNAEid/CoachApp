using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using explore.model;
using Firebase.Database;
using Firebase.Database.Query;
namespace explore.services
{
    public class DB
    {
        FirebaseClient client;

        public DB()
        {
            client = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<Coaches> getCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<Coaches>().AsObservableCollection();

            return CoachData;
        }

        public async Task AddCoach(string fname, string lname, string course, string location, string phone,string Email ,string ID, string TIME1, string TIME2, string TIME3, string date)
        {
            Coaches c = new Coaches() { FistName = fname, LastName = lname, Course = course, Location = location, Phone = phone,email=Email,id=ID,time1=TIME1,time2=TIME2,time3=TIME3,Date=date};
            await client.Child("Coach").PostAsync(c);
        }


    }
}