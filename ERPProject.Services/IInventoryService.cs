using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IInventoryService
    {
        void Create(Inventory newInventory);
        Inventory GetById(int id);
        void Update(Inventory inventory);
        void Update(int id);
        void Delete(int id);
        IEnumerable<Inventory> GetAll();
        void ChangeOwner(int id);


    }
}
