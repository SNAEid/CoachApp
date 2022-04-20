using Calenders.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calenders.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthlyCal : ContentPage
    {
        public MonthlyCal()
        {
            InitializeComponent();
            BindingContext = new DBModelView();

        }
        /*
        public async void WeekView_Clicked(object sender , EventArgs e)
        {
            await Navigation.PushAsync(new WeeklyCal());
        }
        */
    }
}