using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMVC.Data;
using TestMVC.Models;

namespace TestMVC.Controllers;

public class UsersController : Controller
{
    private readonly PgDbContext _context;
    
    public UsersController(PgDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var users = _context.Users.ToList().OrderBy(u => u.Id);
        return View(users);
    }
    
    public IActionResult Details(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    public IActionResult Create()
    {   
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateUser([Bind("Name,LastName,Mail,Phone")] User user)
    {
        bool RepeatedMail = _context.Users.Any(u => u.Mail == user.Mail);
            
        if (RepeatedMail)
        {
            ModelState.AddModelError("Mail", "Este correo ya está en uso.");
        }
        
        if (ModelState.IsValid)
        {
            
            
            _context.Users.Add(user);   
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View("Create", user);
        
    }
    
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Name,LastName,Mail,Phone")] User user)
    {
        
        if (id != user.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == user.Id))
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
        return View(user);
    }
    
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        
        
}