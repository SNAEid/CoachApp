﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
namespace xamarinFirbase.Models

{

    public class Coach 
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeSpan SaveTime { get; set; }

        public int Age { get; set; }
        public string Phone { get; set; }

        public string Password { get; set; }
       

    }
   

}
