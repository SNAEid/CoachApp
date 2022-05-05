using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using Xamarin.Essentials;

namespace XamarinFirebaseApp.Services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<Coach> getCoaches()
        {
            var TraineeData = client.Child("Coach").AsObservable<Coach>().AsObservableCollection();
            return TraineeData;
        }



        private static string GetUserId { get; set; }
        public async Task AddCoachesId(string coachId)
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync("UserId");
                GetUserId = oauthToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Coach c = new Coach()
            {
                CoachId = GetUserId


            };
            await client.Child("Coach").PostAsync(c);
        }





        public async Task AddCoaches(string coachId, string firstName,string lastName, string email , string phone ,string password ,string city , string course)
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync("UserId");
                GetUserId = oauthToken;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Coach c =new Coach() {
                CoachId = GetUserId , 
              FirstName= firstName, LastName = lastName,Email = email, Phone = phone , Password = password , City = city , Course = course
            };
            await client.Child("Coach").PostAsync(c);
        }

        

    }
}
