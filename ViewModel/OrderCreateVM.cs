using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using TestMVC.Models;

namespace TestMVC.ViewModel;

public class OrderCreateVM
{
    public Order Order { get; set; }
    [ValidateNever]
    public IEnumerable<User> Users { get; set; }
}