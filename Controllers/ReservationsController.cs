using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMVC.Data;
using TestMVC.Models;

namespace TestMVC.Controllers;

public class ReservationsController : Controller
{
    private readonly PgDbContext _context;
    
    public ReservationsController(PgDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var reservations = _context.Reservations.Include(r => r.Client).ToList().OrderBy(r => r.Id);
        return View(reservations);
    }
    
    public IActionResult Details(int id)
    {
        var reservation = _context.Reservations
            .Include(r => r.Client)
            .FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }
    
    public IActionResult Create()
    {
        ViewBag.Clients = _context.Users.ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Date","Hour","NumberPeople","Observations","IdClient")] Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        // foreach (var entry in ModelState)
        // {
        //     var key = entry.Key;
        //     var errors = entry.Value.Errors;
        //
        //     foreach (var error in errors)
        //     {
        //         Console.WriteLine($" Error en '{key}': {error.ErrorMessage}");
        //     }
        // }
        
        ViewBag.Clients = _context.Users.ToList();
        Console.WriteLine("Manito no sirve");
        return View("Create", reservation);
    }

    public IActionResult Edit(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reservation = _context.Reservations.Find(id);
        if (reservation == null)
        {
            return NotFound();
        }
        ViewBag.Clients = _context.Users.ToList();
        return View(reservation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id","Date", "Hour", "NumberPeople", "Observations", "IdClient")] Reservation reservation)
    {

        if (id != reservation.Id)
        {
            return NotFound();
        }
        

        if (ModelState.IsValid)
        {
            try
            {
                _context.Reservations.Update(reservation);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reservations.Any(e => e.Id == reservation.Id))
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

        return View(reservation);
    }

    public IActionResult Delete(int id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var reservation = _context.Reservations
            .Include(r => r.Client)
            .FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }

        return View(reservation);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var reservation = _context.Reservations
            .Include(r => r.Client)
            .FirstOrDefault(r => r.Id == id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}