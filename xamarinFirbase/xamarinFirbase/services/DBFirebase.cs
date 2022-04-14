using Firebase.Database;
using Firebase.Database.Query;
using ReadDB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ReadDB.Services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<Coach> getCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<Coach>().AsObservableCollection();
            return CoachData;
        }
        public async Task AddCoach(string firstName, string lastName , string email , string course , string phone)
        {
            Coach c = new Coach() { FistName = firstName, LastName = lastName, Email=email , Course=course , Phone=phone};
            await client.Child("Coach").PostAsync(c);
        }

        internal Task AddCoach(string firstName, string lastName, int age)
        {
            throw new NotImplementedException();
        }
    }
}
