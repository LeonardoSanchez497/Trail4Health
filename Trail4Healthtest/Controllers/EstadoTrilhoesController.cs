using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trail4Healthtest.Models;
using Microsoft.AspNetCore.Authorization;

namespace Trail4Healthtest.Controllers
{
    public class EstadoTrilhoesController : Controller
    {
        private readonly Trails4HealthContext _context;

        public EstadoTrilhoesController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: EstadoTrilhoes
        public async Task<IActionResult> Index()
        {
            var trails4HealthContext = _context.EstadoTrilho.Include(e => e.Estado).Include(e => e.Trilho);
            return View(await trails4HealthContext.ToListAsync());
        }

        // GET: EstadoTrilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadoTrilho
                .Include(e => e.Estado)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EstadoTrilhoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }

            return View(estadoTrilho);
        }
        [Authorize(Roles = "Administrador")]
        // GET: EstadoTrilhoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nomeestado");
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho");
            return View();
        }

        // POST: EstadoTrilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoTrilhoId,Causa,Datafim,Datainicio,EstadoId,TrilhoId")] EstadoTrilho estadoTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nomeestado", estadoTrilho.EstadoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", estadoTrilho.TrilhoId);
            return View(estadoTrilho);
        }
        [Authorize(Roles = "Administrador")]
        // GET: EstadoTrilhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadoTrilho.SingleOrDefaultAsync(m => m.EstadoTrilhoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nomeestado", estadoTrilho.EstadoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", estadoTrilho.TrilhoId);
            return View(estadoTrilho);
        }
        [Authorize(Roles = "Administrador")]
        // POST: EstadoTrilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoTrilhoId,Causa,Datafim,Datainicio,EstadoId,TrilhoId")] EstadoTrilho estadoTrilho)
        {
            if (id != estadoTrilho.EstadoTrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTrilhoExists(estadoTrilho.EstadoTrilhoId))
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
            ViewData["EstadoId"] = new SelectList(_context.Estado, "EstadoId", "Nomeestado", estadoTrilho.EstadoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", estadoTrilho.TrilhoId);
            return View(estadoTrilho);
        }

        // GET: EstadoTrilhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTrilho = await _context.EstadoTrilho
                .Include(e => e.Estado)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EstadoTrilhoId == id);
            if (estadoTrilho == null)
            {
                return NotFound();
            }

            return View(estadoTrilho);
        }

        // POST: EstadoTrilhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTrilho = await _context.EstadoTrilho.SingleOrDefaultAsync(m => m.EstadoTrilhoId == id);
            _context.EstadoTrilho.Remove(estadoTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoTrilhoExists(int id)
        {
            return _context.EstadoTrilho.Any(e => e.EstadoTrilhoId == id);
        }
    }
}
