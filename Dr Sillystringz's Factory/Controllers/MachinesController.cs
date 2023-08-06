using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Dr_Sillystringz_s_Factory.Models;
using Dr_Sillystringzs_Factory.Models;

namespace Dr_Sillystringz_s_Factory.Controllers
{
    public class MachinesController : Controller
    {
        private readonly FactoryDbContext _context;

        public MachinesController(FactoryDbContext context)
        {
            _context = context;
        }

        // GET: Machines
        public async Task<IActionResult> Index()
        {
            var machines = await _context.Machines.ToListAsync();
            return View(machines);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,Name,Manufacturer,InstallationDate")] Machine machine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machine);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return
