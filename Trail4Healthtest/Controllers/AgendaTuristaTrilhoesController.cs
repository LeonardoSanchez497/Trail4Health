using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trail4Healthtest.Models;

namespace Trail4Healthtest.Controllers
{
    public class AgendaTuristaTrilhoesController : Controller
    {
        private readonly Trails4HealthContext _context;

        public AgendaTuristaTrilhoesController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: AgendaTuristaTrilhoes
        public async Task<IActionResult> Index()
        {
            var trails4HealthContext = _context.AgendaTuristaTrilho.Include(a => a.Trilho).Include(a => a.Turista);
            return View(await trails4HealthContext.ToListAsync());
        }

        // GET: AgendaTuristaTrilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaTuristaTrilho = await _context.AgendaTuristaTrilho
                .Include(a => a.Trilho)
                .Include(a => a.Turista)
                .SingleOrDefaultAsync(m => m.AgendaId == id);
            if (agendaTuristaTrilho == null)
            {
                return NotFound();
            }

            return View(agendaTuristaTrilho);
        }

        // GET: AgendaTuristaTrilhoes/Create
        public IActionResult Create()
        {
            ViewData["Trilhoid"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho");
            ViewData["Turistaid"] = new SelectList(_context.Turista, "TuristaId", "Nome");
            return View();
        }

        // POST: AgendaTuristaTrilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendaId,Datafim,Datainicio,Tempogasto,Trilhoid,Turistaid")] AgendaTuristaTrilho agendaTuristaTrilho, string passagemdetexto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendaTuristaTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Trilhoid"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", agendaTuristaTrilho.Trilhoid);
            ViewData["Turistaid"] = new SelectList(_context.Turista, "TuristaId", "Nome", passagemdetexto);
            return View(agendaTuristaTrilho);
        }

        // GET: AgendaTuristaTrilhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaTuristaTrilho = await _context.AgendaTuristaTrilho.SingleOrDefaultAsync(m => m.AgendaId == id);
            if (agendaTuristaTrilho == null)
            {
                return NotFound();
            }
            ViewData["Trilhoid"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", agendaTuristaTrilho.Trilhoid);
            ViewData["Turistaid"] = new SelectList(_context.Turista, "TuristaId", "Nome", agendaTuristaTrilho.Turistaid);
            return View(agendaTuristaTrilho);
        }

        // POST: AgendaTuristaTrilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaId,Datafim,Datainicio,Tempogasto,Trilhoid,Turistaid")] AgendaTuristaTrilho agendaTuristaTrilho)
        {
            if (id != agendaTuristaTrilho.AgendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendaTuristaTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaTuristaTrilhoExists(agendaTuristaTrilho.AgendaId))
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
            ViewData["Trilhoid"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", agendaTuristaTrilho.Trilhoid);
            ViewData["Turistaid"] = new SelectList(_context.Turista, "TuristaId", "Nome", agendaTuristaTrilho.Turistaid);
            return View(agendaTuristaTrilho);
        }

        // GET: AgendaTuristaTrilhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendaTuristaTrilho = await _context.AgendaTuristaTrilho
                .Include(a => a.Trilho)
                .Include(a => a.Turista)
                .SingleOrDefaultAsync(m => m.AgendaId == id);
            if (agendaTuristaTrilho == null)
            {
                return NotFound();
            }

            return View(agendaTuristaTrilho);
        }

        // POST: AgendaTuristaTrilhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendaTuristaTrilho = await _context.AgendaTuristaTrilho.SingleOrDefaultAsync(m => m.AgendaId == id);
            _context.AgendaTuristaTrilho.Remove(agendaTuristaTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaTuristaTrilhoExists(int id)
        {
            return _context.AgendaTuristaTrilho.Any(e => e.AgendaId == id);
        }
    }
}
