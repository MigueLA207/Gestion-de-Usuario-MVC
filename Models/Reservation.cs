
namespace TestMVC.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public TimeSpan Hour { get; set; }
    public int NumberPeople { get; set; }
    public string Observations { get; set; }

    public int? IdClient { get; set; }
    public User Client { get; set; }
}
