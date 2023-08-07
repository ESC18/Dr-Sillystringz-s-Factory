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

        _context.Machines.Add(machine);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Edit(int? id)
    {

        var machine = _context.Machines.Find(id);

        return View(machine);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Machine machine)
    {


        _context.Update(machine);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Details(int? id)
    {


        var machine = _context.Machines.Find(id);

        return View(machine);
    }

    public IActionResult Delete(int? id)
    {


        var machine = _context.Machines.Find(id);

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
