using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IEmployeeService
    {
        void Create(Employee newEmployee);
        Employee GetById(int employeeId);
        void Update(Employee employee);
        void Update(int employeeId);
        void Delete(int employeeId);
        IEnumerable<Employee> GetAll();
        void Hire(int employeeId);
        bool EmailExist(string email);


    }
}
