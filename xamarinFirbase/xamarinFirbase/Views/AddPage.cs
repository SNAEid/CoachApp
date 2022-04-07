using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LastCa.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage(DateTime selectedDate)
        {
            InitializeComponent();

            datePicker.MinimumDate = new DateTime(1970, 1, 1);
            datePicker.MaximumDate = new DateTime(2030, 1, 1);

            datePicker.Date = selectedDate.Date;
            timePicker.Time = DateTime.Now.TimeOfDay;
        }
        void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
