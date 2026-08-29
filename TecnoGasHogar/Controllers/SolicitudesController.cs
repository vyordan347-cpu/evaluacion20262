using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Solicitudes/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Solicitudes/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.SolicitudesServicio.Add(solicitud);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Solicitud registrada correctamente.";
                return RedirectToAction(nameof(Crear));
            }

            return View(solicitud);
        }
    }
}