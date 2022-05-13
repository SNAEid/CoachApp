using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace XamarinFirebaseApp.Services
{
    public class ExploreServices
    {
        FirebaseClient client;

        public string GetUserId { get;  set; }

        public ExploreServices()
        {
            client = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/");

        }

        public  ObservableCollection<Coach> getCoach()
        {
            var CoachData = client.Child("Coach").AsObservable<Coach>().AsObservableCollection();

            return CoachData;
        }

        public async Task AddCoach(string firstName, string lname, string course, string city, string phone,string email )
        {
            Coach c = new Coach() { FirstName = firstName, LastName = lname, Course = course, City = city, Phone = phone,Email=email};
            await client.Child("Coach").PostAsync(c);
        }


        public async Task<bool> Save(Coach coaches)
        {
            var data = await client.Child(nameof(Coach)).PostAsync(JsonConvert.SerializeObject(coaches));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }


        public async Task<List<Coach>> GetAll()
        {
            return (await client.Child(nameof(Coach)).OnceAsync<Coach>()).Select(item => new Coach
            {
                Phone = item.Object.Phone,
                FirstName = item.Object.FirstName,
                City = item.Object.City,
                Course = item.Object.Course,
                Image = item.Object.Image,

              
            }).ToList();
        }

        public async Task<List<Coach>> GetAllByName(string name)
        {
            return (await client.Child(nameof(Coach)).OnceAsync<Coach>()).Select(item => new Coach
            {
                Phone = item.Object.Phone,
                FirstName = item.Object.FirstName,
                City = item.Object.City,
                Course = item.Object.Course,
                Image = item.Object.Image,
                CoachId = item.Key
            }).Where(c => c.FirstName.ToLower().Contains(name.ToLower())).ToList();
        }

        public async Task<List<Coach>> GetAllByCity(string city)
        {
            return (await client.Child(nameof(Coach)).OnceAsync<Coach>()).Select(item => new Coach
            {
                City = item.Object.City,
                Phone = item.Object.Phone,
                FirstName = item.Object.FirstName,

                Image = item.Object.Image,
                CoachId = item.Key
            }).Where(x => x.City.ToLower().Contains(city.ToLower())).ToList();
        }






    }
}