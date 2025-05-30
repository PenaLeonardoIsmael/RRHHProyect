using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Models.Models;
using Data.Repositories.Interfaces;

namespace RRHHProyect.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IUnitOfWork _UnitOfWork;

        public CandidatosController(ApplicationDBContext context, IUnitOfWork UnitOfWork)
        {
            _context = context;
            _UnitOfWork = UnitOfWork;
        }

        // GET: Candidatos
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Candidatos.Include(c => c.Competencia).Include(c => c.PuestoAspira);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .Include(c => c.Competencia)
                .Include(c => c.PuestoAspira)
                .FirstOrDefaultAsync(m => m.IDCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "ID_Competencia", "Descripcion");
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "ID_Puesto", "Nombre");
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCandidato,Cedula,PuestoId,Departamento,Salario,CompetenciaId,Capacitacion")] Candidato candidato)
        {
            //if (ModelState.IsValid)
            //{
                _UnitOfWork.CandidatosRepository.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "ID_Competencia", "Descripcion", candidato.CompetenciaId);
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "ID_Puesto", "Nombre", candidato.PuestoId);
            return View(candidato);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "ID_Competencia", "Descripcion", candidato.CompetenciaId);
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "ID_Puesto", "Nombre", candidato.PuestoId);
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCandidato,Cedula,PuestoId,Departamento,Salario,CompetenciaId,Capacitacion")] Candidato candidato)
        {
            if (id != candidato.IDCandidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.IDCandidato))
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
            ViewData["CompetenciaId"] = new SelectList(_context.Competencias, "ID_Competencia", "Descripcion", candidato.CompetenciaId);
            ViewData["PuestoId"] = new SelectList(_context.Puestos, "ID_Puesto", "Nombre", candidato.PuestoId);
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidatos
                .Include(c => c.Competencia)
                .Include(c => c.PuestoAspira)
                .FirstOrDefaultAsync(m => m.IDCandidato == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato != null)
            {
                _context.Candidatos.Remove(candidato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.IDCandidato == id);
        }
    }
}
