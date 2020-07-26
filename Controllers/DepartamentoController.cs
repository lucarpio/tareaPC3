using System.Linq;
using La_Pirana_Ejemplo.Data;
using La_Pirana_Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;

namespace La_Pirana_Ejemplo.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly PiranaContext _context;

        public DepartamentoController(PiranaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var departamentos = _context.Departamentos.ToList();
            return View(departamentos);
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Departamento departamento)
        {
            if(ModelState.IsValid)
            {
                _context.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }
    }
}