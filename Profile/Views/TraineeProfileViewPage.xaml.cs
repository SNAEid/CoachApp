using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Profile.ModelViews;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TraineeProfileViewPage : ContentPage
    {
        public TraineeProfileViewPage()
        {
            InitializeComponent();
            BindingContext = new TraineeProfileViewModelPage();
        }
        public async void Pick_ImageButton_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Perform required operation after examining e.Value
        }

        public void More_Button_Clicked(object sender, EventArgs e)
        {
        }
        public void Join_Button_Clicked(object sender, EventArgs e)
        {
        }
    }
}