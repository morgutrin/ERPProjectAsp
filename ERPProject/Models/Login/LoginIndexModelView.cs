using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPProject.Models.Login
{
    public class LoginIndexModelView
    {

        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}