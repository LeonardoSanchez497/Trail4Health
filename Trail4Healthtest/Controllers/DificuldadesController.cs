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
    public class DificuldadesController : Controller
    {
        private readonly Trails4HealthContext _context;

        public DificuldadesController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Dificuldades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dificuldade.ToListAsync());
        }

        // GET: Dificuldades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificuldade = await _context.Dificuldade
                .SingleOrDefaultAsync(m => m.DificuldadeId == id);
            if (dificuldade == null)
            {
                return NotFound();
            }

            return View(dificuldade);
        }

        // GET: Dificuldades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dificuldades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DificuldadeId,Nomedificuldade,Observacoes")] Dificuldade dificuldade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dificuldade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dificuldade);
        }

        // GET: Dificuldades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificuldade = await _context.Dificuldade.SingleOrDefaultAsync(m => m.DificuldadeId == id);
            if (dificuldade == null)
            {
                return NotFound();
            }
            return View(dificuldade);
        }

        // POST: Dificuldades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DificuldadeId,Nomedificuldade,Observacoes")] Dificuldade dificuldade)
        {
            if (id != dificuldade.DificuldadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dificuldade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DificuldadeExists(dificuldade.DificuldadeId))
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
            return View(dificuldade);
        }

        // GET: Dificuldades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dificuldade = await _context.Dificuldade
                .SingleOrDefaultAsync(m => m.DificuldadeId == id);
            if (dificuldade == null)
            {
                return NotFound();
            }

            return View(dificuldade);
        }

        // POST: Dificuldades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dificuldade = await _context.Dificuldade.SingleOrDefaultAsync(m => m.DificuldadeId == id);
            _context.Dificuldade.Remove(dificuldade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DificuldadeExists(int id)
        {
            return _context.Dificuldade.Any(e => e.DificuldadeId == id);
        }
    }
}
