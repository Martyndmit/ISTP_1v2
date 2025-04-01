using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymInfrastructure.Data;
using GymDomain.Entities;

namespace GymInfrastructure.Controllers
{
    public class GymsController : Controller
    {
        private readonly GymContext _context;

        public GymsController(GymContext context)
        {
            _context = context;
        }

        // GET: Gyms
        public async Task<IActionResult> Index()
        {
            var gyms = await _context.Gyms.ToListAsync();
            return View(gyms);
        }

        // GET: Gyms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var gym = await _context.Gyms
                .Include(g => g.Equipment) // якщо хочете показати обладнання в залі
                .FirstOrDefaultAsync(m => m.GymId == id);
            if (gym == null)
                return NotFound();

            return View(gym);
        }

        // GET: Gyms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gyms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gym gym)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gym);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gym);
        }

        // GET: Gyms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var gym = await _context.Gyms.FindAsync(id);
            if (gym == null)
                return NotFound();

            return View(gym);
        }

        // POST: Gyms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Gym gym)
        {
            if (id != gym.GymId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gym);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GymExists(gym.GymId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gym);
        }

        // GET: Gyms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var gym = await _context.Gyms.FirstOrDefaultAsync(m => m.GymId == id);
            if (gym == null)
                return NotFound();

            return View(gym);
        }

        // POST: Gyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gym = await _context.Gyms.FindAsync(id);
            if (gym != null)
            {
                _context.Gyms.Remove(gym);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GymExists(int id)
        {
            return _context.Gyms.Any(e => e.GymId == id);
        }
    }
}
