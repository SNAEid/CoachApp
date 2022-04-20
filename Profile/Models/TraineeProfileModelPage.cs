using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Profile.Models
{
    public class TraineeProfileModelPage
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        [JsonProperty("Image")]
        public Uri Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string UserName
        {
            get { return $"{FistName} {LastName}"; }
            set { }
        }
        [JsonIgnore]
        public string Key { get; set; }
    }
}
