using ERPProject.Entity;
using ERPProject.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services.Implementation
{
    public class ContractorService : IContractorService
    {
        private readonly ApplicationDbContext _context;
        public ContractorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Contractor contractor)
        {
            _context.Contractors.Add(contractor);
            _context.SaveChanges();
        }

        public void Delete(int contractorId)
        {

            _context.Contractors.Remove(GetById(contractorId));
            _context.SaveChanges();
        }

        public void Update(int contractorId)
        {
            _context.Contractors.AddOrUpdate(GetById(contractorId));
            _context.SaveChanges();
        }

        public Contractor GetById(int id)
        {
            return _context.Contractors.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Contractor> GetAll() => _context.Contractors;

    }
}
