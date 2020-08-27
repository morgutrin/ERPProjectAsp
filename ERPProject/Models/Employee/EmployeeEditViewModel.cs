using ERPProject.Entity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ERPProject.Models.Employee
{
    public class EmployeeEditViewModel
    {
        public int ID { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [Required(ErrorMessage = "Employee field is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "First name field is required"), StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }


        public string Gender { get; set; }
        // [Display(Name = "Photo")]
        // public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string IdDocumentNo { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Required, MaxLength(150)]
        public string Address { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(9)]
        public string PostCode { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

    }
}
