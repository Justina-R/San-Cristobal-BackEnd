using EjerciciosORM.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EjerciciosORM.Contexto
{
    public class DataContext : DbContext

    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
