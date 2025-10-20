using EjerciciosORM.Contexto;
using EjerciciosORM.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EjerciciosORM.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly DataContext _context;

        public Repositorio(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Employee>> GetTodosLosEmpleadosAsync()
        {
            return await this._context.Employees.ToListAsync();
        }


        public async Task<int> GetCantidadEmpleadosAsync()
        {
            return await this._context.Employees.CountAsync();
        }

        public async Task<Employee?> GetEmpleadoPorIdAsync(int id)
        {
            return await this._context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<Employee?> GetEmpleadoPorNombreAsync(string name)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.FirstName.ToLower() == name.ToLower());
        }

        public async Task<Employee?> GetEmpleadoPorTituloAsync(string title)
        {
            return await this._context.Employees.FirstOrDefaultAsync(e => e.Title.ToLower() == title.ToLower());
        }

        public async Task<Employee?> GetEmpleadoPorPaisAsync(string country)
        {
            return await this._context.Employees.FirstOrDefaultAsync(e => e.Country.ToLower() == country.ToLower());
        }

        public async Task<List<Employee>> GetTodosLosEmpleadosPorPaisAsync(string country)
        {
            return await _context.Employees.Where(e => e.Country.ToLower() == country.ToLower()).ToListAsync();
        }

        public async Task<Employee?> GetEmpleadoMasGrandeAsync()
        {
            return await _context.Employees.OrderBy(e => e.BirthDate).FirstOrDefaultAsync();
        }

        public async Task<List<object>> GetCantEmpleadosPorTituloAsync()
        {
            return await _context.Employees.GroupBy(e => e.Title).Select(g => new
            {
                Titulo = g.Key,
                Cantidad = g.Count()
            }).ToListAsync<object>();
        }

        public async Task<List<Product>> GetProductosConCategoriaAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductosQueContenganAsync(string palabra)
        {
            palabra = palabra.ToLower();
            return await _context.Products
                .Where(p => p.ProductName.ToLower().Contains(palabra))
                .ToListAsync();
        }

    }
}
