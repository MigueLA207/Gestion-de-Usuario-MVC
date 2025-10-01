using  System.ComponentModel.DataAnnotations;

namespace TestMVC.Models;

public class Waiter
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Turn { get; set; } 
    
    [Range(0, 50, ErrorMessage = "Debe estar entre 0 y 50")]
    public int? ExpYears { get; set; }
}

