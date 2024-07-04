using Microsoft.AspNetCore.Mvc;
using AppCrud.Data;
using AppCrud.Models;   
using Microsoft.EntityFrameworkCore;


namespace AppCrud.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDbContext;

        public EmpleadoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        /// <summary>
        /// Método que muestra la lista de empleados
        /// </summary>
        public async Task <IActionResult> Lista()
        {
            List<Empleado> listaEmpleados = await _appDbContext.Empleados.ToListAsync();
            return View(listaEmpleados);
        }

        [HttpGet]
        /// <summary>
        /// Método que muestra el formulario para crear un nuevo empleado
        /// </summary>
        public IActionResult Nuevo()
        {
           return View();
        }

        [HttpPost]
        /// <summary>
        /// Método que crea un nuevo empleado
        /// </summary>
        public async Task<IActionResult> Guardar(Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));            
        }

        [HttpGet]
        /// <summary>
        /// Metodo que muestra el detalle de un empleado
        /// </summary>
        public async Task<IActionResult> Detalle(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(empleado => empleado.IdEmpleado == id);
            return View(empleado);
        }

        [HttpGet]
        /// <summary>
        /// Metodo que muestra el formulario para editar un empleado
        /// </summary>
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(empleado => empleado.IdEmpleado == id);
            return View(empleado);           
        }

        [HttpPost]
        /// <summary>
        /// Metodo que edita un empleado existente.
        /// </summary>
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        /// <summary>
        /// Metodo que muestra el formulario para editar un empleado
        /// </summary>
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(empleado => empleado.IdEmpleado == id);

            _appDbContext.Empleados.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        


    }
}
