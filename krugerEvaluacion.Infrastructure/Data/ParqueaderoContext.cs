using Microsoft.EntityFrameworkCore;
using krugerEvaluacion.Core.Entities;
using System.Reflection;

namespace krugerEvaluacion.Infrastructure.Data
{
    public partial class ParqueaderoContext : DbContext
    {
        public ParqueaderoContext()
        {
        }

        public ParqueaderoContext(DbContextOptions<ParqueaderoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-JOUQLL7\\SQLEXPRESS2022;initial catalog=ParqueaderoDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        //}
    }
}
