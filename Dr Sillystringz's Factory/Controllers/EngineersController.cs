using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dr_Sillystringzs_Factory.Models;


namespace Dr_Sillystringz_s_Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryDbContext _context;

        public EngineersController(FactoryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var engineers = await _context.Engineers.ToListAsync();
            return View(engineers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineerId,Name,Specialty")] Engineer engineer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineers.FindAsync(id);
            if (engineer == null)
            {
                return NotFound();
            }
            return View(engineer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineerId,Name,Specialty")] Engineer engineer)
        {
            if (id != engineer.EngineerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineerExists(engineer.EngineerId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(engineer);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineers.FirstOrDefaultAsync(e => e.EngineerId == id);
            if (engineer == null)
            {
                return NotFound();
            }
            return View(engineer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineer = await _context.Engineers.FirstOrDefaultAsync(e => e.EngineerId == id);
            if (engineer == null)
            {
                return NotFound();
            }

            return View(engineer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engineer = await _context.Engineers.FindAsync(id);
            _context.Engineers.Remove(engineer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineerExists(int id)
        {
            return _context.Engineers.Any(e => e.EngineerId == id);
        }
    }
}
