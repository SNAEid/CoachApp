using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Model;
using XamarinFirebaseApp.ModelView;


namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchExplorePage : ContentPage
    {
        public SearchExplorePage()
        {
            InitializeComponent();

            CoachestListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }

        CoachRepository studentRepository = new CoachRepository();
        

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var mydetails = e.Item as Coach;
            await Navigation.PushAsync(new CoachDetails(mydetails.City, mydetails.FirstName, mydetails.LastName, mydetails.Phone, mydetails.Course, mydetails.Email, mydetails.CoachId));



        }

        protected override async void OnAppearing()
        {
            var coaches = await studentRepository.GetAll();
            CoachestListView.ItemsSource = null;
            CoachestListView.ItemsSource = coaches;
            CoachestListView.IsRefreshing = false;


        }


        private void NavigateButton_OnClicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new SearchExplorePage();
        }




       
        private async void TxtSearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchValue = TxtSearch.Text;
            if (!string.IsNullOrEmpty(searchValue))
            {
                var coaches = await studentRepository.GetAllByName(searchValue);


                CoachestListView.ItemsSource = null;
                CoachestListView.ItemsSource = coaches;

            }
            else
            {
                OnAppearing();
            }
        }

        private async void explore_clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchExplorePage());
        }


        private void home_clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HomePageview());


        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "Cources")
            {
                vBox.Color = Color.Silver;


                CoachestListView.IsVisible = false;
            }
            else
            {
                CoachestListView.IsVisible = true;





            }
        }
        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchValue = TxtSearch.Text;
            if (!string.IsNullOrEmpty(searchValue))
            {
                var coaches = await studentRepository.GetAllByName(searchValue);
                CoachestListView.ItemsSource = null;
                CoachestListView.ItemsSource = coaches;
            }
            else
            {
                OnAppearing();
            }
        }

        private void ButtonHome_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePageview();


        }

        private void Profile_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new AddAppointment());

        }

        private void Explore_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SearchExplorePage());

        }

    }
}