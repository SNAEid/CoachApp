using App1.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthlyCal : ContentPage
    {
        public MonthlyCal()
        {
            InitializeComponent();
            BindingContext = new DBModelView();

        }
        
    }
}