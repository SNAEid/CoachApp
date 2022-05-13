using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;
using XamarinFirebaseApp.Model;

namespace XamarinFirebaseApp
{
    public class CoachRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/"); 

        public async Task<bool> Save(Coach coaches)
        {
            var data = await firebaseClient.Child(nameof(Coach)).PostAsync(JsonConvert.SerializeObject(coaches));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true; 
            }
            return false;
        }


        public async Task<List<Coach>> GetAll()
        {
            return (await firebaseClient.Child(nameof(Coach)).OnceAsync<Coach>()).Select(item => new Coach
            {
                Phone = item.Object.Phone,
                FirstName = item.Object.FirstName,
                City = item.Object.City,
                Course = item.Object.Course,
                Image = item.Object.Image,
                CoachId = item.Key
            }).ToList(); 
        }

        public async Task<List<Coach>> GetAllByName(string firstName)
        {
            return (await firebaseClient.Child(nameof(Coach)).OnceAsync<Coach>()).Select(item => new Coach
            {
                Phone = item.Object.Phone,
                FirstName = item.Object.FirstName,
                City = item.Object.City,
                Course = item.Object.Course,
                Image = item.Object.Image,
                CoachId = item.Key

            }).Where(c=>c.FirstName.ToLower().Contains(firstName.ToLower())).ToList();
        }

        public async Task<List<Coach>> GetAllByCity(string city)
        {
            return (await firebaseClient.Child(nameof(Coach)).OnceAsync<Coach>()).Select(item => new Coach
            {
                City = item.Object.City,
                Phone = item.Object.Phone,
                CoachId = item.Key , 
                FirstName = item.Object.FirstName ,

                Image = item.Object.Image,
            }).Where(x => x.City.ToLower().Contains(city.ToLower())).ToList();
        }


       


    }
}
