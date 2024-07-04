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
      
        public async Task <IActionResult> Lista()
        {
            List<Empleado> listaEmpleados = await _appDbContext.Empleados.ToListAsync();
            return View(listaEmpleados);
        }
    }
}
