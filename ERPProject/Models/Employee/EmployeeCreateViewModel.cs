
using ERPProject.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Models.Employee
{
    public class EmployeeCreateViewModel
    {

        public HttpPostedFileBase ImageFile { get; set; }
        [Required(ErrorMessage = "Employee field is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }

        [Required(ErrorMessage = "First name field is required"), StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + (String.IsNullOrEmpty(SecondName) ? " " : SecondName + " ") + LastName; }
            set { }
        }

        public string Gender { get; set; }
        //   [Display(Name = "Photo")]
        //  public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [Remote("IsEmailExist", "Employee", ErrorMessage = "Email exist in database")]
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