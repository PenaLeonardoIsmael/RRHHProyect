using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Models.Models;

namespace RRHHProyect.Controllers
{
    public class CapacitacionsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CapacitacionsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Capacitacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Capacitaciones.ToListAsync());
        }

        // GET: Capacitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitacion = await _context.Capacitaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacitacion == null)
            {
                return NotFound();
            }

            return View(capacitacion);
        }

        // GET: Capacitacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capacitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Nivel,FechaDesde,FechaHasta,Institucion")] Capacitacion capacitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacitacion);
        }

        // GET: Capacitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }
            return View(capacitacion);
        }

        // POST: Capacitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Nivel,FechaDesde,FechaHasta,Institucion")] Capacitacion capacitacion)
        {
            if (id != capacitacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacitacionExists(capacitacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(capacitacion);
        }

        // GET: Capacitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitacion = await _context.Capacitaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacitacion == null)
            {
                return NotFound();
            }

            return View(capacitacion);
        }

        // POST: Capacitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion != null)
            {
                _context.Capacitaciones.Remove(capacitacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapacitacionExists(int id)
        {
            return _context.Capacitaciones.Any(e => e.Id == id);
        }
    }
}
