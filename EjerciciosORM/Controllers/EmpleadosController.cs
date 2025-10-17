using Microsoft.AspNetCore.Mvc;
using EjerciciosORM.Entidades;
using EjerciciosORM.Repositorios;

namespace EjerciciosORM.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public EmpleadosController(IRepositorio repo)
        {
            _repositorio = repo;
        }

        // Ejercicio 1: Consultar empleados
        [HttpGet("TodosLosEmpleados")]
        public async Task<ActionResult<List<Empleado>>> GetTodosLosEmpleados()
        {
            return Ok(await _repositorio.GetTodosLosEmpleadosAsync());
        }

        [HttpGet("CantidadEmpleados")]
        public async Task<ActionResult<int>> GetCantidadEmpleados()
        {
            return Ok(await _repositorio.GetCantidadEmpleadosAsync());
        }

        [HttpGet("EmpleadoPorID")]
        public async Task<ActionResult<Empleado>> GetEmpleadoPorId([FromQuery] int empleadoID)
        {
            var emp = await _repositorio.GetEmpleadoPorIdAsync(empleadoID);
            return emp is null ? NotFound() : Ok(emp);
        }

        [HttpGet("EmpleadosPorNombre")]
        public async Task<ActionResult<Empleado>> GetEmpleadoPorNombre([FromQuery] string nombreEmpleado)
        {
            var emp = await _repositorio.GetEmpleadoPorNombreAsync(nombreEmpleado);
            return emp is null ? NotFound() : Ok(emp);
        }

        [HttpGet("EmpleadoPorTitulo")]
        public async Task<ActionResult<Empleado>> GetEmpleadoPorTitulo([FromQuery] string titulo)
        {
            var emp = await _repositorio.GetEmpleadoPorTituloAsync(titulo);
            return emp is null ? NotFound() : Ok(emp);
        }

        [HttpGet("EmpleadoPorPais")]
        public async Task<ActionResult<Empleado>> GetEmpleadoPorPais([FromQuery] string country)
        {
            var emp = await _repositorio.GetEmpleadoPorPaisAsync(country);
            return emp is null ? NotFound() : Ok(emp);
        }

        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Empleado>>> GetTodosLosEmpeladosPorPais([FromQuery] string country)
        {
           return Ok(await _repositorio.GetTodosLosEmpleadosPorPaisAsync(country));
        }

        [HttpGet("ElEmpleadoMasGrande")]
        public async Task<ActionResult<Empleado>> GetEmpleadoMasGrande()
        {
           return Ok(await _repositorio.GetEmpleadoMasGrandeAsync());
        }

        // Ejercicio 2: Estadísticas
        [HttpGet("CantidadEmpleadosPorTitulos")]
        public async Task<ActionResult> GetCantEmpleadosPorTitulo()
        {
            return Ok(await _repositorio.GetCantEmpleadosPorTituloAsync());
        }

        // Ejercicio 3: Productos
        [HttpGet("ObtenerProductosConCategoria")]
        public async Task<ActionResult<List<Producto>>> GetProductosConCategoria()
        {
            return Ok(await _repositorio.GetProductosConCategoriaAsync());
        }

        [HttpGet("ObtenerProductosQueContienen")]
        public async Task<ActionResult<List<Producto>>> GetProductosQueContengan([FromQuery] string palabra)
        {
            var productoEncontrado = await _repositorio.GetProductosQueContenganAsync(palabra);
            if (productoEncontrado == null || !productoEncontrado.Any())
                return NotFound();

            return Ok(productoEncontrado);
        }
    }
}
