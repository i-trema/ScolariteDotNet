using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspWebProjet.Data;
using AspWebProjet.Models;

namespace AspWebProjet.Controllers
{
    public class PaniersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaniersController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddById([Bind("UtilisateurEmail")] Panier panier, int moduleId)
        {
            if (ModelState.IsValid)
            {
                var mod = await _context.Modules.FirstOrDefaultAsync(mod => mod.Id == moduleId);
                panier.Modules.Add(mod);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));


            //if (ModelState.IsValid)
            //{
            //    _context.Add(panier);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(panier);
        }


        // GET: Paniers
        public async Task<IActionResult> Index()
        {
              return _context.Paniers != null ? 
                          View(await _context.Paniers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Paniers'  is null.");
        }

        // GET: Paniers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Paniers == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers
                .FirstOrDefaultAsync(m => m.UtilisateurEmail == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // GET: Paniers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UtilisateurEmail")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(panier);
        }

        // GET: Paniers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Paniers == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UtilisateurEmail")] Panier panier)
        {
            if (id != panier.UtilisateurEmail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanierExists(panier.UtilisateurEmail))
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
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Paniers == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers
                .FirstOrDefaultAsync(m => m.UtilisateurEmail == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Paniers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Paniers'  is null.");
            }
            var panier = await _context.Paniers.FindAsync(id);
            if (panier != null)
            {
                _context.Paniers.Remove(panier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanierExists(string id)
        {
          return (_context.Paniers?.Any(e => e.UtilisateurEmail == id)).GetValueOrDefault();
        }
    }
}
