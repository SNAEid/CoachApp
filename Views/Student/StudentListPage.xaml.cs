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
    public partial class StudentListPage : ContentPage
    {
        StudentRepository studentRepository = new StudentRepository(); 
        public  StudentListPage()
        {
            InitializeComponent();

            StudentListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
            
        }
        protected override async void OnAppearing()
        { 
            var students = await studentRepository.GetAll();
            StudentListView.ItemsSource = null;
            StudentListView.ItemsSource = students;
            StudentListView.IsRefreshing = false;


        }


        private void NavigateButton_OnClicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new StudentListPage();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            App.Current.MainPage = new profile();


        }


        private void AddToolBarItem_Clicked(object sender , EventArgs e)
        {
            Navigation.PushModalAsync(new StudentEntry()); 
        }

        private async void TxtSearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchValue = TxtSearch.Text;
            if (!string.IsNullOrEmpty(searchValue))
            { 
                var students =await studentRepository.GetAllByName(searchValue);
              

                StudentListView.ItemsSource = null;
                StudentListView.ItemsSource = students;

            }
            else
            {
                OnAppearing();
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "Cources")
            {
                vBox.Color = Color.Silver;
                pBox.Color = Color.FromHex("#FFA500"); 

              
                StudentListView.IsVisible = false;
                listView.IsVisible = true; 
            }
            else
            {
                StudentListView.IsVisible = true;

                listView.IsVisible = false;


                vBox.Color = Color.FromHex("#FFA500");
                pBox.Color = Color.Silver;


            }
        }
        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchValue = TxtSearch.Text;
            if (!string.IsNullOrEmpty(searchValue))
            {
                var students = await studentRepository.GetAllByName(searchValue);
                StudentListView.ItemsSource = null;
                StudentListView.ItemsSource = students;
            }
            else
            {
                OnAppearing();
            }
        }

        
    }
}