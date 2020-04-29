using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERPProject.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        //  [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string FullName { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PayMonth { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal ContractualHours { get; set; }
        public decimal OverTimeHours { get; set; }
        public decimal ContractualEarnings { get; set; }
        public decimal OverTimeEarnings { get; set; }
        public decimal TotalEarnings { get; set; }

    }
}
