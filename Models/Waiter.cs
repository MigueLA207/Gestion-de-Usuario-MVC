namespace TestMVC.Models;

public class Waiter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public string Turn { get; set; } // mañana, tarde, noche
    public int? ExpYears { get; set; }
}

