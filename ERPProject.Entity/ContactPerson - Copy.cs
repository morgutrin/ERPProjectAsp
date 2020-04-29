using System;
using System.Collections.Generic;
using System.Text;

namespace ERPProject.Entity
{
    public class ContactPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Contractor Contractor { get; set; }
    }
}
