using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
namespace XamarinFirebaseApp.Models

{

    public class TDate 
    {
        public Guid AppointmentId { get; set; }
        public string IdCoach { get; set; }

        public string Title { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



        public DateTime Date { get; set; }
       

    }
   

}
