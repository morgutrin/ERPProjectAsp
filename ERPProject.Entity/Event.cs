using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class Event
    {


        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsNotificationSended { get; set; }

        [ForeignKey("Employee")]

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
