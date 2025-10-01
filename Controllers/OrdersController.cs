using Microsoft.AspNetCore.Mvc;
using TestMVC.Data;

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
        // var orders = _context.Orders.ToList();
        var viewModel = new ViewModel.OrderC
        {
            Orders = _context.Orders.ToList(),
            Users = _context.Users.ToList()
        };
        return View(viewModel);
    }
}