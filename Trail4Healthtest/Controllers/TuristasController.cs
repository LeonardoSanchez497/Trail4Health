﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trail4Healthtest.Models;

namespace Trail4Healthtest.Controllers
{
    public class TuristasController : Controller
    {
        private readonly Trails4HealthContext _context;

        public TuristasController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Turistas
        public async Task<IActionResult> Index()
        {

            return View(await _context.Turista.ToListAsync());
        }

        // GET: Turistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .SingleOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // GET: Turistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristaId,Contatoemergencia,Email,Nif,Nome,NumeroTelefone,EstadoTurista")] Turista turista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turista);
        }

        // GET: Turistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista.SingleOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }
            return View(turista);
        }

        // POST: Turistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaId,Contatoemergencia,Email,Nif,Nome,NumeroTelefone,EstadoTurista")] Turista turista)
        {
            if (id != turista.TuristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristaExists(turista.TuristaId))
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
            return View(turista);
        }

        // GET: Turistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .SingleOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // POST: Turistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turista = await _context.Turista.SingleOrDefaultAsync(m => m.TuristaId == id);
            _context.Turista.Remove(turista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristaExists(int id)
        {
            return _context.Turista.Any(e => e.TuristaId == id);
        }
    }
}
