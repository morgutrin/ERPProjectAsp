using ERPProject.Entity;
using ERPProject.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public delegate void CreateEmployeeEventHandler(string email, string firstname);

    public interface IEmployeeService
    {

        CreateEmployeeEventHandler CreateEmployeeEventHandler { get; set; }
        event CreateEmployeeEventHandler OnEmployeeCreated;
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
