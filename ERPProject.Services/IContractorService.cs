using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IContractorService
    {
        void Create(Contractor contractor);
        void Delete(int contractorId);
        void Update(int contractorId);
        Contractor GetById(int id);
        IEnumerable<Contractor> GetAll();


    }
}
