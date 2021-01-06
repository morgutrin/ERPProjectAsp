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
        Order GetOrder(int id);
        IEnumerable<OrderRow> GetOrderRows(int id);
        void DeleteOrder(int id);
        void CloseOrder(int id);
        void OpenOrder(int id);
        void UpdateOrder(Order order);
    }
}
