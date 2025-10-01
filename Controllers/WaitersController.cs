using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestMVC.Data;
using TestMVC.Models;

namespace TestMVC.Controllers;

public class WaitersController : Controller
{
    private readonly PgDbContext _context;
    
    public WaitersController(PgDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var waiters = _context.Waiters.ToList().OrderBy(w => w.Id);
        return View(waiters);
    }

    public IActionResult Details(int id)
    {
        var waiter = _context.Waiters.Find(id);
        if (waiter == null)
        {
            return NotFound();
        }

        return View(waiter);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateWaiter([Bind("Name,LastName,Turn,ExpYears")] Waiter waiter)
    {
        if (ModelState.IsValid)
        {
            _context.Waiters.Add(waiter);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View("Create", waiter);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var waiter = _context.Waiters.Find(id);
        if (waiter == null)
        {
            return NotFound();
        }

        return View(waiter);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,LastName,Turn,ExpYears")] Waiter waiter)
    {
        if (id != waiter.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(waiter);
            _context.SaveChanges();
        }
        
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var waiter = _context.Waiters.Find(id);
        if (waiter == null)
        {
            return NotFound();
        }

        return View(waiter);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var waiter = _context.Waiters.Find(id);
        if (waiter != null)
        {
            _context.Waiters.Remove(waiter);
            _context.SaveChanges();
        }
        else
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
}