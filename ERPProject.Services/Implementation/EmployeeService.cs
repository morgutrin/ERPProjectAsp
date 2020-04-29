using ERPProject.Entity;
using ERPProject.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(x => x.Id.Equals(employeeId));
        }

        public void Update(Employee employee)
        {
            _context.Employees.AddOrUpdate(employee);
            _context.SaveChanges();
        }

        public void Update(int employeeId)
        {
            Update(GetById(employeeId));
        }



        public void Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            employee.IsActive = false;
            _context.Employees.AddOrUpdate(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public void Hire(int employeeId)
        {
            var employee = GetById(employeeId);
            employee.IsActive = true;
            _context.Employees.AddOrUpdate(employee);
            _context.SaveChanges();
        }

        public bool EmailExist(string email)
        {
            return _context.Employees.Any(x => x.Email.Equals(email));
        }
    }
}
