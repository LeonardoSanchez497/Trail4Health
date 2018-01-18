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
    public class NewslettersController : Controller
    {
        private readonly Trails4HealthContext _context;

        public NewslettersController(Trails4HealthContext context)
        {
            _context = context;
        }

        // GET: Newsletters
        public async Task<IActionResult> Index()
        {
            var trails4HealthContext = _context.Newsletter.Include(n => n.Trilho);
            return View(await trails4HealthContext.ToListAsync());
        }

        // GET: Newsletters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter
                .Include(n => n.Trilho)
                .SingleOrDefaultAsync(m => m.NewletterId == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Newsletters/Create
        public IActionResult Create()
        {
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho");
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewletterId,Data,Descricao,Foto,TrilhoId")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", newsletter.TrilhoId);
            return View(newsletter);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Newsletters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter.SingleOrDefaultAsync(m => m.NewletterId == id);
            if (newsletter == null)
            {
                return NotFound();
            }
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", newsletter.TrilhoId);
            return View(newsletter);
        }

        // POST: Newsletters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewletterId,Data,Descricao,Foto,TrilhoId")] Newsletter newsletter)
        {
            if (id != newsletter.NewletterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsletterExists(newsletter.NewletterId))
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
            ViewData["TrilhoId"] = new SelectList(_context.Trilho, "TrilhoId", "Nometrilho", newsletter.TrilhoId);
            return View(newsletter);
        }
        [Authorize(Roles = "Administrador")]
        // GET: Newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.Newsletter
                .Include(n => n.Trilho)
                .SingleOrDefaultAsync(m => m.NewletterId == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletter = await _context.Newsletter.SingleOrDefaultAsync(m => m.NewletterId == id);
            _context.Newsletter.Remove(newsletter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsletterExists(int id)
        {
            return _context.Newsletter.Any(e => e.NewletterId == id);
        }
    }
}
