using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFirebaseApp.Models
{
    internal class Appointments
    {
        public Guid CoachId { get; set; }

        public string Title { get; set; }
        public TimeSpan SaveTime { get; set; }

        public string Date { get; set; }



    }
}
