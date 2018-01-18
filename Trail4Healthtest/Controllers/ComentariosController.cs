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
    public class ComentariosController : Controller
    {
        private readonly Trails4HealthContext _context;

        public ComentariosController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            var trails4HealthContext = _context.Comentarios.Include(c => c.Avaliacao).Include(c => c.Trilho).Include(c => c.Turista);
            return View(await trails4HealthContext.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios = await _context.Comentarios
                .Include(c => c.Avaliacao)
                .Include(c => c.Trilho)
                .Include(c => c.Turista)
                .SingleOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarios == null)
            {
                return NotFound();
            }

            return View(comentarios);
        }
        [Authorize(Roles = "Turista")]
        // GET: Comentarios/Create
        public IActionResult Create()
        {
            ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "AvaliacaoId", "Classificacao");
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho");
            ViewData["TuristaId"] = new SelectList(_context.Turista, "TuristaId", "Nome" );
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioId,AvaliacaoId,Comentar,Completou,DuracaoTrilho,TrilhoId,TuristaId")] Comentarios comentarios, string passagemdetexto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "AvaliacaoId", "Classificacao", comentarios.AvaliacaoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", comentarios.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Turista, "TuristaId", "Nome", passagemdetexto);
            return View(comentarios);
        }


        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios = await _context.Comentarios.SingleOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarios == null)
            {
                return NotFound();
            }
            ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "AvaliacaoId", "Classificacao", comentarios.AvaliacaoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", comentarios.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Turista, "TuristaId", "Nome", comentarios.TuristaId);
            return View(comentarios);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioId,AvaliacaoId,Comentar,Completou,DuracaoTrilho,TrilhoId,TuristaId")] Comentarios comentarios)
        {
            if (id != comentarios.ComentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentariosExists(comentarios.ComentarioId))
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
            ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "AvaliacaoId", "Classificacao", comentarios.AvaliacaoId);
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", comentarios.TrilhoId);
            ViewData["TuristaId"] = new SelectList(_context.Turista, "TuristaId", "Nome", comentarios.TuristaId);
            return View(comentarios);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios = await _context.Comentarios
                .Include(c => c.Avaliacao)
                .Include(c => c.Trilho)
                .Include(c => c.Turista)
                .SingleOrDefaultAsync(m => m.ComentarioId == id);
            if (comentarios == null)
            {
                return NotFound();
            }

            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarios = await _context.Comentarios.SingleOrDefaultAsync(m => m.ComentarioId == id);
            _context.Comentarios.Remove(comentarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentariosExists(int id)
        {
            return _context.Comentarios.Any(e => e.ComentarioId == id);
        }
    }
}
