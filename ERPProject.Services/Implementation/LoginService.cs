using ERPProject.Entity;
using ERPProject.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public event CreateOperatorEventHandler OnOperatorCreated;

        public Operator GetOperator(string login)
        {
            return _context.Operators.FirstOrDefault(x => x.Login.Equals(login));
        }

        public Operator GetOperator(int id)
        {
            return _context.Operators.Single(x => x.Id.Equals(id));
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

        public void DeleteOperator(int id)
        {
            var operatorToDelete = GetOperator(id);
            _context.Operators.Remove(operatorToDelete);
            _context.SaveChanges();
        }

        public void CreateOperator(Operator oOperator, int[] selectedRoles)
        {
            _context.Operators.Add(oOperator);
            _context.SaveChanges();
            var getOperator = GetOperator(oOperator.Login);
            var employee = _context.Operators.FirstOrDefault(x => x.EmployeeId.Equals(oOperator.EmployeeId));
            List<OperatorRoles> roles = new List<OperatorRoles>();
            foreach (var operatorRole in selectedRoles)
            {
                _context.OperatorRoles.Add(new OperatorRoles
                {
                    OperatorId = getOperator.Id,
                    RoleId = operatorRole

                });

            }
            //  OnOperatorCreated?.Invoke(getOperator, employee.Employee.Email);
            _context.SaveChanges();


        }

        public List<Operator> GetAll()
        {

            return _context.Operators.ToList();
        }

        public string GetEmployeeRolesString(int employeeId)
        {
            string temp = "";
            var @operator = _context.Operators.FirstOrDefault(x => x.EmployeeId.Equals(employeeId));
            var roles = _context.OperatorRoles.Where(x => x.OperatorId.Equals(@operator.Id)).Select(x => new
            {
                x.Role.Name
            }).ToArray();
            foreach (var role in roles)
            {
                temp += role.Name + ", ";
            }


            return temp;
        }

        public int GetEmployeeId(string login)
        {
            return _context.Operators.FirstOrDefault(x => x.Login.Equals(login)).EmployeeId;
        }

        public bool IsLoginExist(string login)
        {
            return _context.Operators.Any(x => x.Login.Equals(login));
        }
    }
}
