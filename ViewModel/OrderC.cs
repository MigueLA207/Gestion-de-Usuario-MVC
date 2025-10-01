using TestMVC.Models;

namespace TestMVC.ViewModel;

public class OrderC
{
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<User> Users { get; set; }
}