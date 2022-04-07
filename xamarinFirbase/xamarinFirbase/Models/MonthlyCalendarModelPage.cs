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
        string _title, _description;
        DateTime _date;
        int _id;

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

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string SelectedImage => IsSelected ? "ic_check" : "ic_uncheck";
    }
}