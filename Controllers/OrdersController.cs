using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMVC.Data;
using TestMVC.Models;
using TestMVC.ViewModel;

namespace TestMVC.Controllers;

public class OrdersController : Controller
{
    private readonly PgDbContext _context;
    
    public OrdersController(PgDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var viewModel = new ViewModel.OrderC
        {
            Orders = _context.Orders.ToList(),
            Users = _context.Users.ToList()
        };
        return View(viewModel);
    }

    public IActionResult Details(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }
    
    public IActionResult Create()
    {
        var vm = new OrderCreateVM()
        {
            Order = new Order { Date = DateTime.Today }, 
            Users = _context.Users.ToList()
        };
        return View(vm);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(OrderCreateVM vm)
    {
        if (ModelState.IsValid)
        {
            
            if (vm.Order.Date.HasValue)
            {
                vm.Order.Date = DateTime.SpecifyKind(vm.Order.Date.Value, DateTimeKind.Utc);
            }
            _context.Orders.Add(vm.Order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        vm.Users = _context.Users.ToList();
        return View(vm);
    }
    
    // GET: Orders/Edit/5
    public IActionResult Edit(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }

        var vm = new OrderCreateVM()
        {
            Order = order,
            Users = _context.Users.ToList()
        };

        return View(vm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, OrderCreateVM vm)
    {
        if (id != vm.Order.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                if (vm.Order.Date.HasValue)
                {
                    vm.Order.Date = DateTime.SpecifyKind(vm.Order.Date.Value, DateTimeKind.Utc);
                }

                _context.Update(vm.Order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }
        
        //vm.Users = _context.Users.ToList();
        return View(vm);
    }
    
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var order = _context.Orders.Find();
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}