using ConfeccionInformesMVC.Models;
using ConfeccionInformesMVC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConfeccionInformesMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ConfeccionInformesContext _context;

        public AlumnoController(ConfeccionInformesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var alumnos = await _context.Alumnos.ToListAsync();

            return View(alumnos);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return NotFound();

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return NotFound();

            var model = new UpdateAlumnoDTO
            {
                Id = alumno.Id,
                Matricula = alumno.Matricula,
                Nombre = alumno.Nombre,
                Sexo = alumno.Sexo,
                Repetidor = alumno.Repetidor,
                Activo = alumno.Activo,
            };

            ViewData["Sexos"] = new SelectList(new List<string> { Sexo.Hombre, Sexo.Mujer});

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAlumnoDTO model)
        {
            var sexos = new List<string>
            {
                Sexo.Hombre, Sexo.Mujer
            };

            if (!sexos.Contains(model.Sexo)) model.Sexo = Sexo.Hombre;

            if (!ModelState.IsValid)
            {
                ViewData["Sexos"] = new SelectList(new List<string> { Sexo.Hombre, Sexo.Mujer }, model.Sexo);
                return View(model);
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null) return NotFound();

            alumno.Matricula = model.Matricula;
            alumno.Nombre = model.Nombre;
            alumno.Email = model.Email;
            alumno.Sexo = model.Sexo;
            alumno.Repetidor = model.Repetidor;
            alumno.Activo = model.Activo;

            _context.Entry(alumno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
