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
    [Authorize(Roles = "Administrador")]
    public class EtapasController : Controller
    {
        private readonly Trails4HealthContext _context;

        public EtapasController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Etapas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etapa.ToListAsync());
        }

        // GET: Etapas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapa = await _context.Etapa
                .SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapa == null)
            {
                return NotFound();
            }

            return View(etapa);
        }

        // GET: Etapas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etapas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtapaId,Distancia,Duracao,Geolocalizacao,Nomeetapa")] Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etapa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etapa);
        }

        // GET: Etapas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapa = await _context.Etapa.SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapa == null)
            {
                return NotFound();
            }
            return View(etapa);
        }

        // POST: Etapas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtapaId,Distancia,Duracao,Geolocalizacao,Nomeetapa")] Etapa etapa)
        {
            if (id != etapa.EtapaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etapa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtapaExists(etapa.EtapaId))
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
            return View(etapa);
        }

        // GET: Etapas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etapa = await _context.Etapa
                .SingleOrDefaultAsync(m => m.EtapaId == id);
            if (etapa == null)
            {
                return NotFound();
            }

            return View(etapa);
        }

        // POST: Etapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etapa = await _context.Etapa.SingleOrDefaultAsync(m => m.EtapaId == id);
            _context.Etapa.Remove(etapa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtapaExists(int id)
        {
            return _context.Etapa.Any(e => e.EtapaId == id);
        }
    }
}
