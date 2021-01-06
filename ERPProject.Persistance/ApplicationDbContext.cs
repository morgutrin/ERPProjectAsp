using ERPProject.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ERPProject.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ERPDBConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ExternalRelease> ExternalReleases { get; set; }
        public DbSet<ExternalReleaseRow> ExternalReleaseRows { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<OperatorRoles> OperatorRoles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<ExternalReceiptRow> ExternalReceiptRows { get; set; }
        public DbSet<ExternalReceipt> ExternalReceipts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Amortization> Amortizations { get; set; }
        public DbSet<AmortizationRow> AmortizationRows { get; set; }



    }
}
