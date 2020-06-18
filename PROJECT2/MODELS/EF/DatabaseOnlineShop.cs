namespace MODELS.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseOnlineShop : DbContext
    {
        public DatabaseOnlineShop()
            : base("name=DatabaseOnlineShop")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<OldEmployee> OldEmployees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<OldEmployee>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<OldEmployee>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
