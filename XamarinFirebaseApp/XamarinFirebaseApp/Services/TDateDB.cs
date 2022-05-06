using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinFirebaseApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;

namespace XamarinFirebaseApp.Services
{
    public class TDateDB
    {
        FirebaseClient client;

        public TDateDB()
        {
            client = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/");

        }
        

       

     

        public ObservableCollection<TDate> GetTDate()
        {
            var TDateData = client.Child("TDate").AsObservable<TDate>().AsObservableCollection();
            return TDateData;
        }
        private static string GetUserId { get; set; }


        public async Task AddTDate(string idCoach , string title,  TimeSpan startTime, TimeSpan endTime, DateTime date)
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

            TDate c = new TDate()
            {

                AppointmentId = Guid.NewGuid() , 
                Title = title,
                IdCoach = GetUserId , 
                StartTime = startTime,
                EndTime = endTime,
                Date = date
            }; await client.Child($"/Coach/{"-N1Nx7BKu0r-IUjNCWSi"}/appointment").PostAsync(c);
            //await client.Child($"/Coach{GetUserId}/appointment/").PostAsync(c);
        }












    }
}
