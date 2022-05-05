using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;

namespace XamarinFirebaseApp
{
    public class StudentRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://mycoachapp-8a02a-default-rtdb.firebaseio.com/"); 

        public async Task<bool> Save(StudentModel student)
        {
            var data = await firebaseClient.Child(nameof(StudentModel)).PostAsync(JsonConvert.SerializeObject(student));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true; 
            }
            return false;
        }


        public async Task<List<StudentModel>> GetAll()
        {
            return (await firebaseClient.Child(nameof(StudentModel)).OnceAsync<StudentModel>()).Select(item => new StudentModel
            {
                Phone = item.Object.Phone,
                Name = item.Object.Name,
                City = item.Object.City,
                Course = item.Object.Course,
                Image = item.Object.Image,
                Id = item.Key
            }).ToList(); 
        }

        public async Task<List<StudentModel>> GetAllByName(string name)
        {
            return (await firebaseClient.Child(nameof(StudentModel)).OnceAsync<StudentModel>()).Select(item => new StudentModel
            {
                Phone = item.Object.Phone,
                Name = item.Object.Name,
                City = item.Object.City,
                Course = item.Object.Course,
                Image = item.Object.Image,
                Id = item.Key
            }).Where(c=>c.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public async Task<List<StudentModel>> GetAllByCity(string city)
        {
            return (await firebaseClient.Child(nameof(StudentModel)).OnceAsync<StudentModel>()).Select(item => new StudentModel
            {
                City = item.Object.City,
                Phone = item.Object.Phone,
                Name = item.Object.Name,
                
                Image = item.Object.Image,
                Id = item.Key
            }).Where(x => x.City.ToLower().Contains(city.ToLower())).ToList();
        }


       


    }
}
