using Microsoft.EntityFrameworkCore;
using AppCrud.Models;

namespace AppCrud.Data
{
    public class AppDBContext : DbContext
    {
        //Constructor
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }

        //Agregamos la tabla Empleado
        public DbSet<Empleado> Empleados { get; set; }
        //Definimos el esquema de la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Empleado>(tb =>
            {
                tb.HasKey(col => col.IdEmpleado);
                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.NombreCompleto).HasMaxLength(50);
                tb.Property(col => col.Correo).HasMaxLength(50);
            });

            //Definimos el nombre de la tabla 'cuidar la mayuscula y minuscula y "s" '
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
        }
    }
}
