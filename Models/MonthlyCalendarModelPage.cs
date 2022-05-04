using System;
using System.Collections.Generic;
using System.Text;
using Monthly_Calenar.ModelViews;
using System.Windows.Input;
using Xamarin.Forms;

namespace Monthly_Calenar.Models
{
    public class MonthlyCalendarModelPage : BaseNotifyPropertyChanged
    {
        bool _isSelected;
        public ICommand SelectedCommand { get; private set; }

       
        public MonthlyCalendarModelPage()
        { 
            SelectedCommand = new Command(() =>
            {
                IsSelected = !IsSelected;
            });
         }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedImage));
            }
        }

        //TDate
        public string AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Title { get; set; }

        //Coach
        public string City { get; set; }
        public string Course { get; set; }
        public string CoachId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public string SelectedImage => IsSelected ? "ic_check" : "ic_uncheck";
    }
}