using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trail4Healthtest.Data;
using Trail4Healthtest.Models;

namespace Trail4Healthtest.Controllers
{
    public class TrilhoesController : Controller
    {
        private readonly TrailsDbContext _context;

        public TrilhoesController(TrailsDbContext context)
        {
            _context = context;
        }

        // GET: Trilhoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trilho.ToListAsync());
        }

        // GET: Trilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho
                .SingleOrDefaultAsync(m => m.trilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("trilhoId,distancia_a_percorrer,duracao_media,loc_inicio,loc_fim,cod_dificuldade,cod_desnivel,cod_etapa_aconselhada,ativo")] Trilho trilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trilho);
        }

        // GET: Trilhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilho.SingleOrDefaultAsync(m => m.trilhoId == id);
            if (trilho == null)
            {
                return NotFound();
            }
            return View(trilho);
        }

        // POST: Trilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("trilhoId,distancia_a_percorrer,duracao_media,loc_inicio,loc_fim,cod_dificuldade,cod_desnivel,cod_etapa_aconselhada,ativo")] Trilho trilho)
        {
            if (id != trilho.trilhoId)
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
                    if (!TrilhoExists(trilho.trilhoId))
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
                .SingleOrDefaultAsync(m => m.trilhoId == id);
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
            var trilho = await _context.Trilho.SingleOrDefaultAsync(m => m.trilhoId == id);
            _context.Trilho.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilho.Any(e => e.trilhoId == id);
        }
    }
}
