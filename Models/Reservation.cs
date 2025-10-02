
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TestMVC.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public TimeSpan Hour { get; set; }
    [Range(1,50,ErrorMessage = "Debe de ser mayor a 0 o menor que 10")]
    public int NumberPeople { get; set; }
    public string Observations { get; set; }

    public int? IdClient { get; set; }
    [ValidateNever]
    public User Client { get; set; }
}
