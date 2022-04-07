using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarinFirbase.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace xamarinFirbase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoachPage : ContentPage
    {
        public CoachPage()
        {
            InitializeComponent();
            BindingContext = new CoachesModelView();
        }

       

        private async void Onbtn_Clicked(object sender, EventArgs e)
        {
            
        }

      
    }

   

   
}