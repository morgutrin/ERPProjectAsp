using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERPProject.Entity
{
    [Table("ContactPersons")]
    public class ContactPerson
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Contractor Contractor { get; set; }
    }
}
