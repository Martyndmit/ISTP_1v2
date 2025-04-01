using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymInfrastructure.Data;
using GymDomain.Entities;

namespace GymInfrastructure.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly GymContext _context;

        public EquipmentController(GymContext context)
        {
            _context = context;
        }

        // GET: Equipment
        public async Task<IActionResult> Index()
        {
            var equipments = await _context.Equipment
                .Include(e => e.Gym)
                .ToListAsync();
            return View(equipments); // список
        }


        // GET: Equipment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var equipment = await _context.Equipment
                .Include(e => e.Gym)
                .FirstOrDefaultAsync(e => e.EquipmentId == id);

            if (equipment == null) return NotFound();

            return View(equipment); // Повертаємо один об’єкт
        }



        // GET: Equipment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
                return NotFound();

            return View(equipment);
        }

        // POST: Equipment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.EquipmentId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Equipment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var equipment = await _context.Equipment
                .Include(e => e.Gym)
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (equipment == null)
                return NotFound();

            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipment.Any(e => e.EquipmentId == id);
        }
    }
}
