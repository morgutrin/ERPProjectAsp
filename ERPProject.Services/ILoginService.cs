using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface ILoginService
    {
        Operator GetOperator(string login);
        string[] GetRoles(string login);
        List<Role> GetRoles();
        void CreateOperator(Operator oOperator, int[] selectedRoles);
    }
}
