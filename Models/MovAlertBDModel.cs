namespace MovAlert.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovAlertBDModel : DbContext
    {
        public MovAlertBDModel()
            : base("name=MovAlertBDModel")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Incidencias> Incidencias { get; set; }
        public virtual DbSet<Monitoreos> Monitoreos { get; set; }
        public virtual DbSet<Monitoreos_Incidencias> Monitoreos_Incidencias { get; set; }
        public virtual DbSet<Requisitoriados> Requisitoriados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Equipos)
                .WithRequired(e => e.Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipos>()
                .HasMany(e => e.Monitoreos)
                .WithRequired(e => e.Equipos)
                .WillCascadeOnDelete(false);
        }
    }
}
