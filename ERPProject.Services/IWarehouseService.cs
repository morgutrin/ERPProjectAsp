using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IWarehouseService
    {
        void SaveExternalReceipt(ExternalReceipt externalReceipt);
        ExternalReceipt GetExternalReceipt(string code);
        ExternalReceipt GetExternalReceipt(int id);
        IEnumerable<ExternalReceiptRow> GetExternalReceiptRows(int externalReceiptId);
        void SaveExternalReceiptRows(ExternalReceiptRow row);
        IEnumerable<ExternalReceipt> GetAll();
        void DeleteExternalReceipt(int id);
        //releases
        void SaveExternalRelease(ExternalRelease externalRelease);
        ExternalRelease GetExternalRelease(string code);
        ExternalRelease GetExternalRelease(int id);
        IEnumerable<ExternalRelease> GetEmployeeExternalReleases(int employeeId);
        void SaveExternalReleaseRows(ExternalReleaseRow row);
        IEnumerable<ExternalRelease> GetAllExternalReleases();
        IEnumerable<ExternalReleaseRow> GetExternalReleaseRows(int externalReleaseId);
        void DeleteExternalRelease(int id);
        //amortization
        void SaveAmortization(Amortization amortization);
        IEnumerable<Amortization> GetAllAmortizations();
        Amortization GetAmortization(int id);


    }
}
