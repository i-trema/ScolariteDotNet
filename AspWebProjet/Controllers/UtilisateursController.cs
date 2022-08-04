using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspWebProjet.Data;
using AspWebProjet.Models;
using Microsoft.AspNetCore.Identity;





namespace AspWebProjet.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilisateursController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: Utilisateurs
        public async Task<IActionResult> Index()
        {
              return _context.Utilisateurs != null ? 
                          View(await _context.Utilisateurs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Utilisateurs'  is null.");
        }

        // GET: Utilisateurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.Email == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }
        
        //public async Task<IActionResult> InscriptionSession(int sessionId, Utilisateur utilisateur)
        //{
        //    var u = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
        //    var s = await _context.Sessions.FirstOrDefaultAsync(s => s.Id == sessionId);

        //    ViewBag.SessionsList = _context.Sessions.Include(s => s.Etudiants).ToList();
        //    ViewBag.NewSession = s;
        //    //ViewBag.NewSession = session;
        //    return View(u);
        //}

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> InscriptionSession(Utilisateur utilisateur, Session session)
        //{

        //    utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            


           
        //    if (/*ModelState.IsValid*/ 1 == 1)
        //    {
        //        try
        //        {

        //            session.Etudiants.Add(utilisateur);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UtilisateurExists(utilisateur.Email))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(utilisateur);
        //}

        // GET: Utilisateurs/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Utilisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Nom,Prenom,Adresse,DateDeNaissance,CV,Role")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Nom,Prenom,Adresse,DateDeNaissance,CV,Role")] Utilisateur utilisateur)
        {
            if (id != utilisateur.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.Email))
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
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Utilisateurs == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs
                .FirstOrDefaultAsync(m => m.Email == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Utilisateurs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Utilisateurs'  is null.");
            }
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(string id)
        {
          return (_context.Utilisateurs?.Any(e => e.Email == id)).GetValueOrDefault();
        }


    }
}
