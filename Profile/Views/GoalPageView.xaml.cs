using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalPageView : ContentPage
    {
        public GoalPageView()
        {
            InitializeComponent();
        }

        private void Done_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TraineeProfileViewPage());
        }

        public bool isWIP = false;
        public void HealthyHabits_Clicked(object sender, EventArgs e)
        {
            isWIP = !isWIP;
            if (isWIP == true)
            {
                this.HealthyHabits.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.HealthyHabits.BackgroundColor = Color.FromHex("#FFA500");
            }
        }

        public void MuscleButton_Clicked(object sender, EventArgs e)
        {
            isWIP = !isWIP;
            if (isWIP == true)
            {
                this.MuscleButton.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.MuscleButton.BackgroundColor = Color.FromHex("#FFA500");
            }
        }

        public void LooseWeightButton_Clicked(object sender, EventArgs e)
        {
            isWIP = !isWIP;
            if (isWIP == true)
            {
                this.LooseWeightButton.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.LooseWeightButton.BackgroundColor = Color.FromHex("#FFA500");
            }
        }

        public void CardioButton_Clicked(object sender, EventArgs e)
        {
            isWIP = !isWIP;
            if (isWIP == true)
            {
                this.CardioButton.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.CardioButton.BackgroundColor = Color.FromHex("#FFA500");
            }
        }

        public void OtherGoalButton_Clicked(object sender, EventArgs e)
        {
            isWIP = !isWIP;
            if (isWIP == true)
            {
                this.OtherGoalButton.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.OtherGoalButton.BackgroundColor = Color.FromHex("#FFA500");
            }
        }
    }
}