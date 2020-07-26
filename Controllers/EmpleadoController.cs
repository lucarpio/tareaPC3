using System;
using System.Linq;
using La_Pirana_Ejemplo.Data;
using La_Pirana_Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace La_Pirana_Ejemplo.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly PiranaContext _context;

        public EmpleadoController(PiranaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listaEmpleados = _context.Empleados.Include(x => x.Sucursal).Include(y => y.Departamento).OrderByDescending(f => f.FechaIngreso).ToList();
            return View(listaEmpleados);
        }
        public IActionResult Registro()
        {
            var sucur = _context.Sucursales.ToList();
            ViewBag.Sucursal = sucur.Select(s => new SelectListItem(s.Nombre,s.Id.ToString()));
            var depa = _context.Departamentos.ToList();
            ViewBag.Departamento = depa.Select(d => new SelectListItem(d.Nombre,d.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Empleado empleado)
        {
            var sucur = _context.Sucursales.ToList();
            ViewBag.Sucursal = sucur.Select(s => new SelectListItem(s.Nombre,s.Id.ToString()));
            var depa = _context.Departamentos.ToList();
            ViewBag.Departamento = depa.Select(d => new SelectListItem(d.Nombre,d.Id.ToString()));

            if(ModelState.IsValid && empleado.FecNac < System.DateTime.Today && empleado.FecNac.Year < System.DateTime.Today.Year-18)
            {
                
                empleado.FechaIngreso = System.DateTime.Now;
                _context.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("FecNac", "Fecha no valida");
            return View(empleado);
        }
    }
}