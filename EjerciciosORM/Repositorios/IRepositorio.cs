using EjerciciosORM.Modelos;

namespace EjerciciosORM.Repositorios
{
    public interface IRepositorio
    {
        Task<List<Employee>> GetTodosLosEmpleadosAsync();
        Task<int> GetCantidadEmpleadosAsync();
        Task<Employee?> GetEmpleadoPorIdAsync(int id);
        Task<Employee?> GetEmpleadoPorNombreAsync(string nombre);
        Task<Employee?> GetEmpleadoPorTituloAsync(string titulo);
        Task<Employee?> GetEmpleadoPorPaisAsync(string pais);
        Task<List<Employee>> GetTodosLosEmpleadosPorPaisAsync(string pais);
        Task<Employee?> GetEmpleadoMasGrandeAsync();
        Task<List<object>> GetCantEmpleadosPorTituloAsync();
        Task<List<Product>> GetProductosConCategoriaAsync();
        Task<List<Product>> GetProductosQueContenganAsync(string palabra);
    }
}
