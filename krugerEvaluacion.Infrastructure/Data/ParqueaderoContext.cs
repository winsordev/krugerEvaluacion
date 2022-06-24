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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=localhost,14333;Initial Catalog=ParqueaderoDB;Uid=sa;Pwd=zdf43sr5;Connect Timeout=3600; pooling='true'; Max Pool Size=200");
            optionsBuilder.UseSqlServer();
        }
    }
}
