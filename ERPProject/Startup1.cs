using Hangfire;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(ERPProject.Startup1))]

namespace ERPProject
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(
                @"Data Source=DESKTOP-MBQ7NHF\SQLEXPRESS;Initial Catalog=ERPSystemDb;Integrated Security=true; MultipleActiveResultSets=true");

            //      RecurringJob.AddOrUpdate((() => CheckInvestments()), Cron.Minutely);
            //     RecurringJob.AddOrUpdate((() => CheckDebits()), Cron.Minutely);
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
