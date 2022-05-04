using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Monthly_Calenar.ModelViews;

namespace Monthly_Calenar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            calendar.MinimumDate = new DateTime(1970, 1, 1);
            calendar.MaximumDate = new DateTime(2030, 1, 1);

        }
    }
}