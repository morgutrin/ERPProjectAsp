using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using ERPProject.Entity;
using ERPProject.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ERPProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IEventService _eventService;
        public HomeController(ILoginService service, IEventService eService)
        {
            _loginService = service;
            _eventService = eService;
        }
        public ActionResult Index()
        {

            //var sched = new DHXScheduler(this);
            //sched.Skin = DHXScheduler.Skins.Flat;
            //sched.LoadData = true;
            //sched.EnableDataprocessor = true;

            //sched.InitialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return View();
        }
        //public ContentResult Data()
        //{
        //    //  return (new SchedulerAjaxData(
        //    //          _eventService.GetUserEvents(_loginService.GetEmployeeId(User.Identity.Name)).Select(e => new { e.Id, e.Text, e.StartDate, e.EndDate })
        //    //       )
        //    //   );
        //    var userEvents = _eventService.GetUserEvents(_loginService.GetEmployeeId(User.Identity.Name)).Select(x =>
        //        new EventWrapper
        //        {
        //            id = x.Id,
        //            start_date = x.StartDate.ToString(CultureInfo.InvariantCulture),
        //            end_date = x.EndDate.ToString(CultureInfo.InvariantCulture),
        //            text = x.Text
        //        });
        //    return new SchedulerAjaxData(userEvents);

        //}

        //public ContentResult Save(int? id, FormCollection actionValues)
        //{
        //    var action = new DataAction(actionValues);
        //    var changedEvent = DHXEventsHelper.Bind<EventWrapper>(actionValues);

        //    Event userEvent = new Event
        //    {
        //        EmployeeId = _loginService.GetEmployeeId(User.Identity.Name),
        //        Text = changedEvent.text,
        //        StartDate = DateTime.Parse(changedEvent.start_date),
        //        EndDate = DateTime.Parse(changedEvent.end_date)
        //    };
        //    try
        //    {
        //        switch (action.Type)
        //        {
        //            case DataActionTypes.Insert:
        //                userEvent.IsNotificationSended = false;
        //                _eventService.AddEvent(userEvent);
        //                break;
        //            case DataActionTypes.Delete:
        //                var myEvent = _eventService.GetEvent(int.Parse(action.SourceId.ToString()));
        //                changedEvent = new EventWrapper
        //                {
        //                    id = myEvent.Id,
        //                    start_date = myEvent.StartDate.ToString(CultureInfo.InvariantCulture),
        //                    end_date = myEvent.EndDate.ToString(CultureInfo.InvariantCulture),
        //                    text = myEvent.Text
        //                };
        //                _eventService.DeleteEvent(int.Parse(action.SourceId.ToString()));

        //                break;
        //            case DataActionTypes.Update:
        //                myEvent = _eventService.GetEvent(int.Parse(action.SourceId.ToString()));
        //                userEvent.Id = changedEvent.id;
        //                _eventService.UpdateEvent(userEvent);
        //                var wrapper = new EventWrapper
        //                {
        //                    id = myEvent.Id,
        //                    start_date = myEvent.StartDate.ToString(CultureInfo.InvariantCulture),
        //                    end_date = myEvent.EndDate.ToString(CultureInfo.InvariantCulture),
        //                    text = myEvent.Text
        //                };
        //                DHXEventsHelper.Update(wrapper, changedEvent, new List<string> { "id" });
        //                // var target = entities.Events.Single(e => e.id == changedEvent.id);
        //                //   DHXEventsHelper.Update(target, changedEvent, new List<string> { "id" });
        //                break;
        //        }

        //        action.TargetId = changedEvent.id;
        //    }
        //    catch (Exception a)
        //    {
        //        action.Type = DataActionTypes.Error;
        //    }

        //    return (new AjaxSaveResponse(action));
        //}
        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        public class EventWrapper
        {
            public int id { get; set; }
            public string text { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
        }
    }
}