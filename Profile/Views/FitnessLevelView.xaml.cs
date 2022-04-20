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
    public partial class FitnessLevelView : ContentPage
    {
        public FitnessLevelView()
        {
            InitializeComponent();
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GoalPageView());
        }

        public bool IsWIP = false;
        public void ChangeColor_Cliked(object sender, EventArgs e)
        { 
            IsWIP = !IsWIP;
            if (IsWIP == true)
            {
                
                this.NewButton.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.NewButton.BackgroundColor = Color.FromHex("#FFA500");
            }
        }

        public void ChangeColorBeginnerButton_Cliked(object sender, EventArgs e) 
        {
            IsWIP = !IsWIP;
            if (IsWIP == true)
            {

                this.BeginnerButton.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.BeginnerButton.BackgroundColor = Color.FromHex("#FFA500");
            }
        }

        public void ChangeColorIntermediate_Cliked(object sender, EventArgs e)
        {
            IsWIP = !IsWIP;
            if (IsWIP == true)
            {

                this.Intermediate.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.Intermediate.BackgroundColor = Color.FromHex("#FFA500");

            }
        }
        public void ChangeColorAdvanced_Cliked(object sender, EventArgs e)
        {
            IsWIP = !IsWIP;
            if (IsWIP == true)
            {

                this.Advanced.BackgroundColor = Color.FromHex("#424949");
            }
            else
            {
                this.Advanced.BackgroundColor = Color.FromHex("#FFA500");

            }

        }

    }
}