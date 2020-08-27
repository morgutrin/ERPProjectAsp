using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public delegate void CreateOperatorEventHandler(Operator uOperator, string emailTo);
    public interface ILoginService
    {
        event CreateOperatorEventHandler OnOperatorCreated;
        Operator GetOperator(string login);
        Operator GetOperator(int id);
        string[] GetRoles(string login);
        List<Role> GetRoles();
        void DeleteOperator(int id);
        void CreateOperator(Operator oOperator, int[] selectedRoles);
        List<Operator> GetAll();
        string GetEmployeeRolesString(int employeeId);
        int GetEmployeeId(string login);
        bool IsLoginExist(string login);
    }
}
