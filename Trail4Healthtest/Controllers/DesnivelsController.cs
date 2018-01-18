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
    
    public class DesnivelsController : Controller
    {
        private readonly Trails4HealthContext _context;

        public DesnivelsController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Desnivels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Desnivel.ToListAsync());
        }

        // GET: Desnivels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desnivel = await _context.Desnivel
                .SingleOrDefaultAsync(m => m.DesnivelId == id);
            if (desnivel == null)
            {
                return NotFound();
            }

            return View(desnivel);
        }

        // GET: Desnivels/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desnivels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesnivelId,Nomedesnivel,Observacoes")] Desnivel desnivel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desnivel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desnivel);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Desnivels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desnivel = await _context.Desnivel.SingleOrDefaultAsync(m => m.DesnivelId == id);
            if (desnivel == null)
            {
                return NotFound();
            }
            return View(desnivel);
        }

        // POST: Desnivels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DesnivelId,Nomedesnivel,Observacoes")] Desnivel desnivel)
        {
            if (id != desnivel.DesnivelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desnivel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesnivelExists(desnivel.DesnivelId))
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
            return View(desnivel);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Desnivels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desnivel = await _context.Desnivel
                .SingleOrDefaultAsync(m => m.DesnivelId == id);
            if (desnivel == null)
            {
                return NotFound();
            }

            return View(desnivel);
        }
        [Authorize(Roles = "Administrador")]
        // POST: Desnivels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desnivel = await _context.Desnivel.SingleOrDefaultAsync(m => m.DesnivelId == id);
            _context.Desnivel.Remove(desnivel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesnivelExists(int id)
        {
            return _context.Desnivel.Any(e => e.DesnivelId == id);
        }
    }
}
