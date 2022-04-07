using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mycoachEpic2.Epic2ViewModels
{
   

        public class ViewModelBase : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;


            protected bool setProperty<T>(ref T storage ,T value,[CallerMemberName] string propertyNmae = null)
            {
                if (object.Equals(storage, value))
                    return false;

                storage = value;
                OnPropertyChanged(propertyNmae);
                return true;
            }

            protected void  OnPropertyChanged(string propertyNmae)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNmae));
            }


        }


    }

