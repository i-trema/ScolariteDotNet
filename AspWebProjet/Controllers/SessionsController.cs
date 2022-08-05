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
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
            
        }


        public async Task<IActionResult> InscriptionSession(int? id)
        {
            var u = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var session = await _context.Sessions
                 .Include(s => s.Parcours)
                 .Include(s => s.Responsable)
                 .FirstOrDefaultAsync(m => m.Id == id);

            //ViewBag.SessionsList = _context.Sessions.Include(s => s.Etudiants).ToList();
            //ViewBag.NewSession = s;
            ViewBag.Util = u;
            

            return View(session);
        }


        public async Task<IActionResult> ValidationInscriptionSession(int? id)
        {
            var u = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var session = await _context.Sessions
                 .Include(s => s.Parcours)
                 .Include(s => s.Responsable)
                 .FirstOrDefaultAsync(m => m.Id == id);

            if (session.Etudiants == null)
            {
                session.Etudiants = new List<Utilisateur>();
            }            

            try
            {

                session.Etudiants.Add(u);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(session.Id))
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


        
        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sessions.Include(s => s.Parcours).Include(s => s.Responsable);

            var u = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

            ViewBag.ParcList = _context.Parcours.Include(p => p.Modules).ToList();
            ViewBag.Util = u;
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Parcours)
                .Include(s => s.Responsable)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["ParcoursId"] = new SelectList(_context.Parcours, "Id", "Id");

            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Intitule,DateDebut,DateFin,ParcoursId,ResponsableEmail")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParcoursId"] = new SelectList(_context.Parcours, "Id", "Id", session.ParcoursId);
            ViewData["ResponsableEmail"] = new SelectList(_context.Utilisateurs.Where(u => u.Role == 1), "Email", "Email", session.ResponsableEmail);

            return View(session);
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["ParcoursId"] = new SelectList(_context.Parcours, "Id", "Id", session.ParcoursId);
            ViewData["ResponsableEmail"] = new SelectList(_context.Utilisateurs.Where(u => u.Role == 1), "Email", "Email", session.ResponsableEmail);

            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Intitule,DateDebut,DateFin,ParcoursId,ResponsableEmail")] Session session)
        {
            if (id != session.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.Id))
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
            ViewData["ParcoursId"] = new SelectList(_context.Parcours, "Id", "Id", session.ParcoursId);
            ViewData["ResponsableEmail"] = new SelectList(_context.Utilisateurs.Where(u => u.Role == 1), "Email", "Email", session.ResponsableEmail);

            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions
                .Include(s => s.Parcours)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sessions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sessions'  is null.");
            }
            var session = await _context.Sessions.FindAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
          return (_context.Sessions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
