using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Model; 
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using XamarinFirebaseApp.Models;
using Xamarin.Essentials;

namespace XamarinFirebaseApp.Services
{
    internal class HomePageServices
    {


        FirebaseClient client;

        public HomePageServices()
        {
            client = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/");

        }


        public ObservableCollection<TDate> getCoach()
        {
            
            var CoachData = client.Child("Coach").Child("-N1Nx7BKu0r-IUjNCWSi").Child("appointment").AsObservable<TDate>().AsObservableCollection();
            return CoachData;


        }
        public async Task<List<TDate>> GetAll()
        {
            return (await client.Child(nameof(TDate)).OnceAsync<TDate>()).Select(item => new TDate
            {
                Title = item.Object.Title,
                StartTime = item.Object.StartTime,
                EndTime = item.Object.EndTime,
                IdCoach = GetUserId,

                Date = item.Object.Date
            }).ToList(); 
        }

        private static string GetUserId { get; set; }
        public async Task<List<TDate>> GetAllById(string id)
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

            return (await client.Child(nameof(TDate)).OnceAsync<TDate>()).Select(item => new TDate
            {
                Title = item.Object.Title,
                StartTime = item.Object.StartTime,
                EndTime = item.Object.EndTime,
                IdCoach = GetUserId,

                Date = item.Object.Date 

            }).Where(x => x.IdCoach.Contains(id)).ToList();
        }

       
    }
}
