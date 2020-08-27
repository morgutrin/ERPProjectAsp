using ERPProject.Entity;
using System;

namespace ERPProject.Models.Employee
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }
        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string LastName { get; set; }


        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime DateJoined { get; set; }
        public string Email { get; set; }

        public string IdDocumentNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }
    }
}