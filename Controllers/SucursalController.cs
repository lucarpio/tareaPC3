using System.Linq;
using La_Pirana_Ejemplo.Data;
using La_Pirana_Ejemplo.Models;
using Microsoft.AspNetCore.Mvc;

namespace La_Pirana_Ejemplo.Controllers
{
    public class SucursalController : Controller
    {
        private readonly PiranaContext _context;
        public SucursalController(PiranaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sucursales = _context.Sucursales.ToList();
            return View(sucursales);
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Sucursal sucursal)
        {
            if(ModelState.IsValid){
                _context.Add(sucursal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sucursal);
        }
    }
}