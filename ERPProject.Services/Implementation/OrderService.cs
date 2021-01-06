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
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CloseOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            order.Status = Status.closed;
            _context.Orders.AddOrUpdate(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Single(x => x.Id == id);
            _context.OrderRows.RemoveRange(order.OrderRows);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public Order GetOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }

        public IEnumerable<OrderRow> GetOrderRows(int id)
        {
            return _context.OrderRows.Where(x => x.OrderId == id).ToList();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        public void OpenOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            order.Status = Status.open;
            _context.Orders.AddOrUpdate(order);
            _context.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.OrderRows.RemoveRange(_context.OrderRows.Where(x => x.OrderId == order.Id));
            _context.Orders.Remove(GetOrder(order.Id));
            _context.SaveChanges();
        }
    }
}
