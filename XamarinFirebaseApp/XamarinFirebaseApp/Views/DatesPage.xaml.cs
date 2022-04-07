using XamarinFirebaseApp.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp.Model;

namespace XamarinFirebaseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatesPage : ContentPage
    {
        public DatesPage()
        {

            InitializeComponent();
            BindingContext = new HomePageModelView();

        }



    }
}