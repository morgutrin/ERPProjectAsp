using ERPProject.Entity;
using ERPProject.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services.Implementation
{
    public class InventoryService : IInventoryService
    {
        private readonly ApplicationDbContext _context;

        public InventoryService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void Create(Inventory newInventory)
        {
            _context.Inventories.Add(newInventory);
            _context.SaveChanges();
        }

        public Inventory GetById(int id)
        {
            return _context.Inventories.Include(x => x.Employee).FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Update(Inventory inventory)
        {
            _context.Inventories.AddOrUpdate(inventory);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            _context.Inventories.AddOrUpdate(GetById(id));
            _context.SaveChangesAsync();
        }


        public void Delete(int id)
        {
            _context.Inventories.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _context.Inventories.Include(x => x.Employee);
        }

        public void ChangeOwner(int id)
        {
            throw new NotImplementedException();
        }
        public bool IsCodeExist(string code)
        {
            return _context.Inventories.Any(x => x.Code.Equals(code));
        }
        public bool IsInventoryNumberExist(string inventory)
        {
            return _context.Inventories.Any(x => x.InventoryNumber.Equals(inventory));
        }
    }
}
