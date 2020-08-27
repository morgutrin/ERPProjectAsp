using ERPProject.Entity;
using ERPProject.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services.Implementation
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ApplicationDbContext _context;

        public WarehouseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SaveExternalReceipt(ExternalReceipt externalReceipt)
        {
            _context.ExternalReceipts.Add(externalReceipt);
            _context.SaveChanges();
        }

        public ExternalReceipt GetExternalReceipt(string code)
        {
            return _context.ExternalReceipts.Single(x => x.Code.Equals(code));
        }

        public ExternalReceipt GetExternalReceipt(int id)
        {
            return _context.ExternalReceipts.Single(x => x.Id.Equals(id));
        }

        public IEnumerable<ExternalReceiptRow> GetExternalReceiptRows(int externalReceiptId)
        {
            return _context.ExternalReceiptRows.Where(x => x.ExternalReceiptId.Equals(externalReceiptId)).ToList();
        }

        public void SaveExternalReceiptRows(ExternalReceiptRow row)
        {
            _context.ExternalReceiptRows.Add(row);
            _context.SaveChanges();
        }

        public IEnumerable<ExternalReceipt> GetAll()
        {
            return _context.ExternalReceipts;
        }

        public void DeleteExternalReceipt(int id)
        {
            _context.ExternalReceipts.Remove(GetExternalReceipt(id));
            _context.SaveChanges();
        }

        public void SaveExternalRelease(ExternalRelease externalRelease)
        {
            _context.ExternalReleases.Add(externalRelease);
            _context.SaveChanges();
        }

        public ExternalRelease GetExternalRelease(string code)
        {
            return _context.ExternalReleases.Single(x => x.Code.Equals(code));
        }

        public ExternalRelease GetExternalRelease(int id)
        {
            return _context.ExternalReleases.Single(x => x.Id.Equals(id));
        }

        public IEnumerable<ExternalRelease> GetEmployeeExternalReleases(int employeeId)
        {
            return _context.ExternalReleases.Where(x => x.Employee.Id.Equals(employeeId)).ToList();
        }

        public void SaveExternalReleaseRows(ExternalReleaseRow row)
        {
            _context.ExternalReleaseRows.Add(row);
            _context.SaveChanges();
        }

        public IEnumerable<ExternalRelease> GetAllExternalReleases()
        {
            return _context.ExternalReleases;
        }

        public IEnumerable<ExternalReleaseRow> GetExternalReleaseRows(int externalReleaseId)
        {
            return _context.ExternalReleaseRows.Where(x => x.ExternalReleaseId.Equals(externalReleaseId)).ToList();
        }

        public void DeleteExternalRelease(int id)
        {
            _context.ExternalReleases.Remove(GetExternalRelease(id));
            _context.SaveChanges();
        }
    }
}
