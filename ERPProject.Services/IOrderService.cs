using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IOrderService
    {
        void SaveOrder(Order order);
        IEnumerable<Order> GetOrders();
    }
}
