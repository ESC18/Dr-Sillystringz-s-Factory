using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dr_Sillystringz_s_Factory.Models;
using System.Linq;


public class MachinesController : Controller
{
    private readonly FactoryDbContext _context;

    public MachinesController(FactoryDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var machines = _context.Machines.ToList();
        return View(machines);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Machine machine)
    {
        if (ModelState.IsValid)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(machine);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var machine = _context.Machines.Find(id);
        if (machine == null)
        {
            return NotFound();
        }
        return View(machine);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Machine machine)
    {
        if (id != machine.MachineId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(machine);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(machine);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var machine = _context.Machines.Find(id);
        if (machine == null)
        {
            return NotFound();
        }
        return View(machine);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var machine = _context.Machines.Find(id);
        if (machine == null)
        {
            return NotFound();
        }
        return View(machine);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var machine = _context.Machines.Find(id);
        _context.Machines.Remove(machine);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
