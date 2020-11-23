using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Event
{
    public class EventCreateModelView
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}