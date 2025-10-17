using EjerciciosORM.Entidades;

namespace EjerciciosORM.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly List<Empleado> _empleados =
        [
            new Empleado { IdEmpleado = 1, Nombre = "Analía", Titulo = "Manager", Pais = "Argentina", Edad = 45 },
            new Empleado { IdEmpleado = 2, Nombre = "Luisina", Titulo = "Developer", Pais = "Chile", Edad = 30 },
            new Empleado { IdEmpleado = 3, Nombre = "María", Titulo = "Developer", Pais = "Argentina", Edad = 28 },
            new Empleado { IdEmpleado = 4, Nombre = "Carlota", Titulo = "Tester", Pais = "Uruguay", Edad = 33 }
        ];

        private readonly List<Producto> _productos =
        [
            new Producto { IdProducto = 1, NombreProducto = "Notebook HP", Categoria = "Electrónica" },
            new Producto { IdProducto = 2, NombreProducto = "Mouse Logitech", Categoria = "Accesorios" },
            new Producto { IdProducto = 3, NombreProducto = "Teclado Samsung", Categoria = "Accesorios" }
        ];

        public Task<List<Empleado>> GetTodosLosEmpleadosAsync() => Task.FromResult(_empleados);

        public Task<int> GetCantidadEmpleadosAsync() => Task.FromResult(_empleados.Count);

        public Task<Empleado?> GetEmpleadoPorIdAsync(int id) =>
            Task.FromResult(_empleados.FirstOrDefault(e => e.IdEmpleado == id));

        public Task<Empleado?> GetEmpleadoPorNombreAsync(string name) =>
            Task.FromResult(_empleados.FirstOrDefault(e => e.Nombre.Equals(name, StringComparison.OrdinalIgnoreCase)));

        public Task<Empleado?> GetEmpleadoPorTituloAsync(string title) =>
            Task.FromResult(_empleados.FirstOrDefault(e => e.Titulo.Equals(title, StringComparison.OrdinalIgnoreCase)));

        public Task<Empleado?> GetEmpleadoPorPaisAsync(string country) =>
            Task.FromResult(_empleados.FirstOrDefault(e => e.Pais.Equals(country, StringComparison.OrdinalIgnoreCase)));

        public Task<List<Empleado>> GetTodosLosEmpleadosPorPaisAsync(string country) =>
            Task.FromResult(_empleados
                .Where(e => e.Pais.Equals(country, StringComparison.OrdinalIgnoreCase))
                .ToList());

        public Task<Empleado?> GetEmpleadoMasGrandeAsync() =>
            Task.FromResult(_empleados.OrderByDescending(e => e.Edad).FirstOrDefault());

        // Aclaración para Sabri: tuve que cambiar de List<string, int> a Dictionary<string, int>
        // porque las tuplas (string, int) no se serializan bien a JSON y en el endpoint no me mostraba
        // nada.
        public Task<Dictionary<string, int>> GetCantEmpleadosPorTituloAsync()
        {
            var result = _empleados
                .GroupBy(e => e.Titulo)
                .ToDictionary(g => g.Key, g => g.Count());

            return Task.FromResult(result);
        }

        public Task<List<Producto>> GetProductosConCategoriaAsync()
        {
            return Task.FromResult(_productos);
        }

        public Task<List<Producto>> GetProductosQueContenganAsync(string palabra)
        {
            return Task.FromResult(_productos
                .Where(p => p.NombreProducto.Contains(palabra, StringComparison.OrdinalIgnoreCase))
                .ToList());
        }

    }
}
