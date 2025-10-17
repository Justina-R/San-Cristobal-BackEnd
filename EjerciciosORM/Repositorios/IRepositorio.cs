using EjerciciosORM.Entidades;

namespace EjerciciosORM.Repositorios
{
    public interface IRepositorio
    {
        Task<List<Empleado>> GetTodosLosEmpleadosAsync();
        Task<int> GetCantidadEmpleadosAsync();
        Task<Empleado?> GetEmpleadoPorIdAsync(int id);
        Task<Empleado?> GetEmpleadoPorNombreAsync(string nombre);
        Task<Empleado?> GetEmpleadoPorTituloAsync(string titulo);
        Task<Empleado?> GetEmpleadoPorPaisAsync(string pais);
        Task<List<Empleado>> GetTodosLosEmpleadosPorPaisAsync(string pais);
        Task<Empleado?> GetEmpleadoMasGrandeAsync();
        Task<Dictionary<string, int>> GetCantEmpleadosPorTituloAsync();
        Task<List<Producto>> GetProductosConCategoriaAsync();
        Task<List<Producto>> GetProductosQueContenganAsync(string palabra);
    }
}
