using explore.modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace explore.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatesPage : ContentPage
    {
        public DatesPage()
        {
            InitializeComponent();
            BindingContext = new exploremodelview();

        }
    }
}