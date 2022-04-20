using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Profile.Models;


namespace Profile.services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://my-coach-9875d-default-rtdb.firebaseio.com/");

        }

        public ObservableCollection<LoginPageModel> GetLoginCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<LoginPageModel>().AsObservableCollection();

            return CoachData;
        }

        public async Task<bool> IsUserExists(string userName)
        {
            var user = (await client.Child("Coach")
                 .OnceAsync<LoginPageModel>())
                 .Where(u => u.Object.Username == userName)
                 .FirstOrDefault();
            return (user != null);
        }

        public async Task<bool> RegisterUser(string userName, string password)
        {
            if (await IsUserExists(userName) == false)
            {
                await client.Child("Coach")
                    .PostAsync(new LoginPageModel()
                    {
                        Username = userName,
                        Password = password
                    });
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> LoginUser(string userName, string password)
        {
            var user = (await client.Child("Coach")
                .OnceAsync<LoginPageModel>())
                .Where(u => u.Object.Username == userName)
                .Where(u => u.Object.Password == password)
                .FirstOrDefault();
            return (user != null);
        }
    }
}
