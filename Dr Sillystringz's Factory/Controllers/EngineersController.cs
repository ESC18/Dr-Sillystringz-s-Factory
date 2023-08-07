using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dr_Sillystringz_s_Factory.Models;
using System.Linq;

public class EngineersController : Controller
{
    private readonly FactoryDbContext _context;

    public EngineersController(FactoryDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var engineers = _context.Engineers.ToList();
        return View(engineers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Engineer engineer)
    {
        if (ModelState.IsValid)
        {
            _context.Engineers.Add(engineer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(engineer);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var engineer = _context.Engineers.Find(id);
        if (engineer == null)
        {
            return NotFound();
        }
        return View(engineer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Engineer engineer)
    {
        if (id != engineer.EngineerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(engineer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(engineer);
    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var engineer = _context.Engineers.Find(id);
        if (engineer == null)
        {
            return NotFound();
        }
        return View(engineer);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var engineer = _context.Engineers.Find(id);
        if (engineer == null)
        {
            return NotFound();
        }
        return View(engineer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var engineer = _context.Engineers.Find(id);
        _context.Engineers.Remove(engineer);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
