using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERPProject.Entity
{
    [Table("Contractors")]
    public class Contractor
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TIN { get; set; }
        public CountrySign CountrySign { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<ContactPerson> ContactPersons { get; set; }
    }
}
