using EmailSender;
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
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private EmailSenderService emailService;
        public EventService(ApplicationDbContext context)
        {
            _context = context;
            emailService = new EmailSenderService();
        }
        public IEnumerable<Event> GetUserEvents(int userId)
        {
            return _context.Events.Where(x => x.EmployeeId.Equals(userId));
        }

        public void AddEvent(Event eEvent)
        {
            _context.Events.Add(eEvent);
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            _context.Events.Remove(GetEvent(id));
            _context.SaveChanges();
        }

        public Event GetEvent(int id)
        {
            return _context.Events.Single(x => x.Id.Equals(id));
        }

        public void UpdateEvent(Event eventToSave)
        {
            _context.Events.AddOrUpdate(eventToSave);
            _context.SaveChanges();
        }

        public void SendNotification()
        {
            var events = _context.Events.Where(x => x.IsNotificationSended.Equals(false)).ToList();
            foreach (var eEvent in events)
            {
                // if(eEvent.StartDate.)
                emailService.SendNotification(eEvent, eEvent.Employee.Email);
            }
        }

        public bool IsNotificationSended(Event eventToCheck)
        {
            throw new NotImplementedException();
        }
    }
}
