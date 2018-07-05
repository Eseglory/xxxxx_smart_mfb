using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class Events
    {
        public string id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        //public string staffCode { get; set; }
        public string Classes { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        //public int[] dow { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string description { get; set; }

        public bool allDay { get; set; }
    }
}