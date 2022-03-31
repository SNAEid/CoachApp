using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using XF_LancheApp.Model;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;

namespace XF_LancheApp.services
{



    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client =
                new FirebaseClient(" https://my-coach-9875d-default-rtdb.firebaseio.com/ ");
        }

        public async Task<bool> IsUserExists(string name)
        {
            var user = (await client.Child(" Users ")
                 .OnceAsync<Coaches>())
                .Where(u => u.Object.Username == name)
                .FirstOrDefault();
            return (user != null);
        }

        public async Task<bool> RegisterUser(string name, string passwd)
        {
            if (await IsUserExists(name) == false)
            {
                await client.Child(" Coach ")
                    .PostAsync(new Coaches()
                    {
                        Username = name,
                        Password = passwd
                    }) ;
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> LoginUser(string name, string passwd)
        {
            var user = (await client.Child(" Coach ")
                .OnceAsync<Coaches>())
                .Where(u => u.Object.Username == name)
                .Where(u => u.Object.Password == passwd)
                .FirstOrDefault();
            return (user != null);
        }
    }
}
