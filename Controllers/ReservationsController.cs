using Microsoft.AspNetCore.Mvc;
using TestMVC.Data;

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
        var reservations = _context.Reservations.ToList().OrderBy(r => r.Id);
        return View(reservations);
    }
    
    public IActionResult Details(int id)
    {
        var reservation = _context.Reservations.Find(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }
    
}