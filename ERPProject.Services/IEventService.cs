using ERPProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetUserEvents(int userId);
        void AddEvent(Event eEvent);
        void DeleteEvent(int id);
        Event GetEvent(int id);
        void UpdateEvent(Event eventToSave);
        void SendNotification();
        bool IsNotificationSended(Event eventToCheck);

    }
}
