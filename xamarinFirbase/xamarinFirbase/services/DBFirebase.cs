using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using xamarinFirbase.Models;
using Firebase.Database;
using Firebase.Database.Query;
namespace xamarinFirbase.services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://test499-2b0e7-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<Coach> getCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<Coach>().AsObservableCollection();
            return CoachData;
        }

       

        public async Task AddCoach(string firstName,string lastName, TimeSpan saveTime, int age , string phone ,string password  )
        {
            Coach c=new Coach() {
                FirstName= firstName, LastName = lastName,SaveTime = saveTime, Age = age , Phone = phone , Password = password 
            };
            await client.Child("Coach").PostAsync(c);
        }

      

    }
}
