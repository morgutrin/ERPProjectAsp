using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Login
{
    public class LoginIndexModelView
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
        public string Login { get; set; }
        public string Roles { get; set; }
    }
}