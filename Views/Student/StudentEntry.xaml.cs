using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentEntry : ContentPage
    {

        StudentRepository repository = new StudentRepository();
        public StudentEntry()
        {
            InitializeComponent();
        }

        private async void ButtonSave_Clicked(object sender , EventArgs e)
        {
            string name = TxtName.Text;
            string phone = TxtPhone.Text;
            string city = TxtCity.Text;
            string course = TxtCourse.Text;


            if (string.IsNullOrEmpty(name))
            {
               await DisplayAlert("Warning", "Please enter your name ", "Cancel"); 
            }

            if (string.IsNullOrEmpty(phone))
            {
               await  DisplayAlert("Warning", "Please enter your phone ", "Cancel"); 
            }

            if (string.IsNullOrEmpty(city))
            {
                await DisplayAlert("Warning", "Please enter your city ", "Cancel");
            }

            if (string.IsNullOrEmpty(course))
            {
                await DisplayAlert("Warning", "Please enter your course ", "Cancel");
            }

            StudentModel student = new StudentModel();
            student.Name = name;
            student.Phone = phone;
            student.City = city;
            student.Course = course;


            var isSaved =await repository.Save(student);

            if (isSaved)
            {
                await DisplayAlert("Information", "Student has been saved. ", "OK");
                Clear(); 
            }
            else
            {
                await DisplayAlert("Error", "Student saved faild. ", "OK");
            }
        }
        public void Clear()
        {
            TxtName.Text = String.Empty;
            TxtPhone.Text = String.Empty;
            TxtCity.Text = string.Empty;
            TxtCourse.Text = string.Empty;

        }

    }
}