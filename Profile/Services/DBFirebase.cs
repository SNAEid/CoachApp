using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Profile.Models;



namespace Profile.Services
{
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<TraineeProfileModelPage> GetCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<TraineeProfileModelPage>().AsObservableCollection();

            return CoachData;
        }
        public ObservableCollection<TraineeProfileModelPage> GetTime()
        {
            var CoachTime = client.Child("Time1").AsObservable<TraineeProfileModelPage>().AsObservableCollection();

            return CoachTime;
        }

        public async Task AddCoach(Uri Image, string UserName, string Email, string Phone, string Location)
        {
            TraineeProfileModelPage c = new TraineeProfileModelPage() { Image = Image, UserName = UserName, Email = Email, Phone= Phone, Location= Location };
            await client.Child("Coach").PostAsync(c);
        }

        public async Task AddTime(string Date)
        {
            TraineeProfileModelPage d = new TraineeProfileModelPage() { Date = Date };
            await client.Child("Time1").PostAsync(d);
        }
        public async Task<List<TraineeProfileModelPage>> GetAllUser()
        {
            try
            {
                var userlist = (await client
                .Child("Time1")
                .OnceAsync<TraineeProfileModelPage>()).Select(item =>
                new TraineeProfileModelPage
                {
                    Date = item.Object.Date,
                    Email = item.Object.Email,
                    UserName = item.Object.UserName,    
                    Phone = item.Object.Phone,
                    Location = item.Object.Location

                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public async Task<TraineeProfileModelPage> GetUser(string email = null, string name = null)
        {
            try
            {
                var allUsers = await GetAllUser();
                await client.Child("Time1")
                .OnceAsync<TraineeProfileModelPage>();

                if (email != null && email.Length > 0)
                {
                    return allUsers.Where(a => a.Email == "MohammadHamayel16@gmail.com").FirstOrDefault();
                }

                return allUsers.Where(a => a.UserName == name).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

    }
}
