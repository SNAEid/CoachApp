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
    public partial class WeeklyCal : ContentPage
    {
        public WeeklyCal()
        {
            InitializeComponent();
            BindingContext = new DBModelView();

        }
    }
}