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
    public class EpocaAconcelhadasController : Controller
    {
        private readonly Trails4HealthContext _context;

        public EpocaAconcelhadasController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: EpocaAconcelhadas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EpocaAconcelhada.ToListAsync());
        }

        // GET: EpocaAconcelhadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epocaAconcelhada = await _context.EpocaAconcelhada
                .SingleOrDefaultAsync(m => m.EpocaId == id);
            if (epocaAconcelhada == null)
            {
                return NotFound();
            }

            return View(epocaAconcelhada);
        }
        [Authorize(Roles = "Administrador")]
        // GET: EpocaAconcelhadas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EpocaAconcelhadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpocaId,Nomeepoca")] EpocaAconcelhada epocaAconcelhada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(epocaAconcelhada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epocaAconcelhada);
        }
        [Authorize(Roles = "Administrador")]
        // GET: EpocaAconcelhadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epocaAconcelhada = await _context.EpocaAconcelhada.SingleOrDefaultAsync(m => m.EpocaId == id);
            if (epocaAconcelhada == null)
            {
                return NotFound();
            }
            return View(epocaAconcelhada);
        }
        [Authorize(Roles = "Administrador")]
        // POST: EpocaAconcelhadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpocaId,Nomeepoca")] EpocaAconcelhada epocaAconcelhada)
        {
            if (id != epocaAconcelhada.EpocaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epocaAconcelhada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpocaAconcelhadaExists(epocaAconcelhada.EpocaId))
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
            return View(epocaAconcelhada);
        }
        [Authorize(Roles = "Administrador")]
        // GET: EpocaAconcelhadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epocaAconcelhada = await _context.EpocaAconcelhada
                .SingleOrDefaultAsync(m => m.EpocaId == id);
            if (epocaAconcelhada == null)
            {
                return NotFound();
            }

            return View(epocaAconcelhada);
        }

        // POST: EpocaAconcelhadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epocaAconcelhada = await _context.EpocaAconcelhada.SingleOrDefaultAsync(m => m.EpocaId == id);
            _context.EpocaAconcelhada.Remove(epocaAconcelhada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpocaAconcelhadaExists(int id)
        {
            return _context.EpocaAconcelhada.Any(e => e.EpocaId == id);
        }
    }
}
