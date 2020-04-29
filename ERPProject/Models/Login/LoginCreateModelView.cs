using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Models.Login
{
    public class LoginCreateModelView
    {
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public int[] SelectedRoles { get; set; }
    }
}