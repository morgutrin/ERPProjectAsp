using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERPProject.Entity
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateJoined { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string IdDocumentNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Phone { get; set; }

        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(9)]
        public string PostCode { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}