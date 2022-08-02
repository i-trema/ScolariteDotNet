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
    public class UnitePedagogiquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitePedagogiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitePedagogiques
        public async Task<IActionResult> Index()
        {
              return _context.UnitesPedagogiques != null ? 
                          View(await _context.UnitesPedagogiques.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UnitesPedagogiques'  is null.");
        }

        // GET: UnitePedagogiques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnitesPedagogiques == null)
            {
                return NotFound();
            }

            var unitePedagogique = await _context.UnitesPedagogiques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitePedagogique == null)
            {
                return NotFound();
            }

            return View(unitePedagogique);
        }

        // GET: UnitePedagogiques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitePedagogiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Intitule")] UnitePedagogique unitePedagogique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitePedagogique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitePedagogique);
        }

        // GET: UnitePedagogiques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnitesPedagogiques == null)
            {
                return NotFound();
            }

            var unitePedagogique = await _context.UnitesPedagogiques.FindAsync(id);
            if (unitePedagogique == null)
            {
                return NotFound();
            }
            return View(unitePedagogique);
        }

        // POST: UnitePedagogiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Intitule")] UnitePedagogique unitePedagogique)
        {
            if (id != unitePedagogique.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitePedagogique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitePedagogiqueExists(unitePedagogique.Id))
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
            return View(unitePedagogique);
        }

        // GET: UnitePedagogiques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnitesPedagogiques == null)
            {
                return NotFound();
            }

            var unitePedagogique = await _context.UnitesPedagogiques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitePedagogique == null)
            {
                return NotFound();
            }

            return View(unitePedagogique);
        }

        // POST: UnitePedagogiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnitesPedagogiques == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UnitesPedagogiques'  is null.");
            }
            var unitePedagogique = await _context.UnitesPedagogiques.FindAsync(id);
            if (unitePedagogique != null)
            {
                _context.UnitesPedagogiques.Remove(unitePedagogique);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitePedagogiqueExists(int id)
        {
          return (_context.UnitesPedagogiques?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
