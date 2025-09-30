
namespace TestMVC.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime Date { get; set; } // fecha completa
    public TimeSpan Hour { get; set; }
    public int NumberPeople { get; set; }
    public string Observations { get; set; }

    // FK → User
    public int? IdClient { get; set; }
    public User Client { get; set; }
}
