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


    }
}
