using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dr_Sillystringz_s_Factory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
        ViewBag.MachineItems = _context.Machines.Select(m => new SelectListItem
        {
            Text = m.Name,
            Value = m.MachineId.ToString()
        }).ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Engineer engineer)
    {
            engineer.EngineerMachines = engineer.SelectedMachineIds
                .Select(machineId => new EngineerMachine
                {
                    MachineId = machineId
                }).ToList();

            _context.Engineers.Add(engineer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int? id)
    {

        var engineer = _context.Engineers
            .Include(e => e.EngineerMachines)
            .ThenInclude(em => em.Machine)
            .FirstOrDefault(e => e.EngineerId == id);

        return View(engineer);
    }


    private bool EngineerExists(int id)
    {
        return _context.Engineers.Any(e => e.EngineerId == id);
    }
}
