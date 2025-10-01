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
    
    
}