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
    public class EtapaTrilhoesController : Controller
    {
        private readonly Trails4HealthContext _context;

        public EtapaTrilhoesController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: EtapaTrilhoes
        public async Task<IActionResult> Index()
        {
            var trails4HealthContext = _context.EtapaTrilho.Include(e => e.Etapa).Include(e => e.Trilho);
            return View(await trails4HealthContext.ToListAsync());
        }

        // GET: EtapaTrilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapaTrilho = await _context.EtapaTrilho
                .Include(e => e.Etapa)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EtapatrilhoId == id);
            if (etapaTrilho == null)
            {
                return NotFound();
            }

            return View(etapaTrilho);
        }

        // GET: EtapaTrilhoes/Create
        public IActionResult Create()
        {
            ViewData["Etapaid"] = new SelectList(_context.Etapa, "EtapaId", "Nomeetapa");
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho");
            return View();
        }

        // POST: EtapaTrilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtapatrilhoId,Ativo,Etapaid,OrdemEtapa,TrilhoId")] EtapaTrilho etapaTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapaTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Etapaid"] = new SelectList(_context.Etapa, "EtapaId", "Nomeetapa", etapaTrilho.Etapaid);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", etapaTrilho.TrilhoId);
            return View(etapaTrilho);
        }

        // GET: EtapaTrilhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapaTrilho = await _context.EtapaTrilho.SingleOrDefaultAsync(m => m.EtapatrilhoId == id);
            if (etapaTrilho == null)
            {
                return NotFound();
            }
            ViewData["Etapaid"] = new SelectList(_context.Etapa, "EtapaId", "Nomeetapa", etapaTrilho.Etapaid);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", etapaTrilho.TrilhoId);
            return View(etapaTrilho);
        }

        // POST: EtapaTrilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtapatrilhoId,Ativo,Etapaid,OrdemEtapa,TrilhoId")] EtapaTrilho etapaTrilho)
        {
            if (id != etapaTrilho.EtapatrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapaTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapaTrilhoExists(etapaTrilho.EtapatrilhoId))
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
            ViewData["Etapaid"] = new SelectList(_context.Etapa, "EtapaId", "Nomeetapa", etapaTrilho.Etapaid);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", etapaTrilho.TrilhoId);
            return View(etapaTrilho);
        }

        // GET: EtapaTrilhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapaTrilho = await _context.EtapaTrilho
                .Include(e => e.Etapa)
                .Include(e => e.Trilho)
                .SingleOrDefaultAsync(m => m.EtapatrilhoId == id);
            if (etapaTrilho == null)
            {
                return NotFound();
            }

            return View(etapaTrilho);
        }

        // POST: EtapaTrilhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etapaTrilho = await _context.EtapaTrilho.SingleOrDefaultAsync(m => m.EtapatrilhoId == id);
            _context.EtapaTrilho.Remove(etapaTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtapaTrilhoExists(int id)
        {
            return _context.EtapaTrilho.Any(e => e.EtapatrilhoId == id);
        }
    }
}
