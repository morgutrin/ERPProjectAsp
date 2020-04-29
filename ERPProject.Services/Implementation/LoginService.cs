﻿using ERPProject.Entity;
using ERPProject.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Operator GetOperator(string login)
        {
            return _context.Operators.FirstOrDefault(x => x.Login.Equals(login));
        }

        public string[] GetRoles(string login)
        {
            var oOperator = GetOperator(login) ?? throw new ArgumentNullException("GetOperator(login)");
            var operatorRoles = oOperator.OperatorRoles.ToList().Select(x => x.Role.Name);
            return operatorRoles.ToArray();
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void CreateOperator(Operator oOperator)
        {
            throw new NotImplementedException();
        }
    }
}
