namespace DAL.ContextDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;

    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
            : base("name=InventoryContext")
        {
        }

        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<MonthlyReport> MonthlyReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.position)
                .WillCascadeOnDelete(false);
        }
    }
}
