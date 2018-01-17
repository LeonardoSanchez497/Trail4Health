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
    public class TrilhoesController : Controller
    {
        private readonly Trails4HealthContext _context;

        public TrilhoesController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Trilhoes
        public async Task<IActionResult> Index()
        {
            var trails4HealthContext = _context.Trilho.Include(t => t.CoddesnivelNavigation).Include(t => t.CoddificuldadeNavigation).Include(t => t.CodepocaaconselhdaNavigation);
            return View(await trails4HealthContext.ToListAsync());
        }

        // GET: Trilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho
                .Include(t => t.CoddesnivelNavigation)
                .Include(t => t.CoddificuldadeNavigation)
                .Include(t => t.CodepocaaconselhdaNavigation)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhoes/Create
        public IActionResult Create()
        {
            ViewData["Coddesnivel"] = new SelectList(_context.Desnivel, "DesnivelId", "Nomedesnivel");
            ViewData["Coddificuldade"] = new SelectList(_context.Dificuldade, "DificuldadeId", "Nomedificuldade");
            ViewData["Codepocaaconselhda"] = new SelectList(_context.EpocaAconcelhada, "EpocaId", "Nomeepoca");
            return View();
        }

        // POST: Trilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhoId,Ativo,Coddesnivel,Coddificuldade,Codepocaaconselhda,Distanciaapercorrer,Duracaomedia,Locfim,Locinicio,NewsletterAtiva,Nometrilho")] Trilho trilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Coddesnivel"] = new SelectList(_context.Desnivel, "DesnivelId", "Nomedesnivel", trilho.Coddesnivel);
            ViewData["Coddificuldade"] = new SelectList(_context.Dificuldade, "DificuldadeId", "Nomedificuldade", trilho.Coddificuldade);
            ViewData["Codepocaaconselhda"] = new SelectList(_context.EpocaAconcelhada, "EpocaId", "Nomeepoca", trilho.Codepocaaconselhda);
            return View(trilho);
        }

        // GET: Trilhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }
            ViewData["Coddesnivel"] = new SelectList(_context.Desnivel, "DesnivelId", "Nomedesnivel", trilho.Coddesnivel);
            ViewData["Coddificuldade"] = new SelectList(_context.Dificuldade, "DificuldadeId", "Nomedificuldade", trilho.Coddificuldade);
            ViewData["Codepocaaconselhda"] = new SelectList(_context.EpocaAconcelhada, "EpocaId", "Nomeepoca", trilho.Codepocaaconselhda);
            return View(trilho);
        }

        // POST: Trilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhoId,Ativo,Coddesnivel,Coddificuldade,Codepocaaconselhda,Distanciaapercorrer,Duracaomedia,Locfim,Locinicio,NewsletterAtiva,Nometrilho")] Trilho trilho)
        {
            if (id != trilho.TrilhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhoExists(trilho.TrilhoId))
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
            ViewData["Coddesnivel"] = new SelectList(_context.Desnivel, "DesnivelId", "Nomedesnivel", trilho.Coddesnivel);
            ViewData["Coddificuldade"] = new SelectList(_context.Dificuldade, "DificuldadeId", "Nomedificuldade", trilho.Coddificuldade);
            ViewData["Codepocaaconselhda"] = new SelectList(_context.EpocaAconcelhada, "EpocaId", "Nomeepoca", trilho.Codepocaaconselhda);
            return View(trilho);
        }

        // GET: Trilhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho
                .Include(t => t.CoddesnivelNavigation)
                .Include(t => t.CoddificuldadeNavigation)
                .Include(t => t.CodepocaaconselhdaNavigation)
                .SingleOrDefaultAsync(m => m.TrilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // POST: Trilhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilho = await _context.Trilho.SingleOrDefaultAsync(m => m.TrilhoId == id);
            _context.Trilho.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilho.Any(e => e.TrilhoId == id);
        }
    }
}
