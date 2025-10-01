using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace TestMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Debe ser mayor a 0") ]
        public int OrderNumber { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public int IdClient { get; set; } 
        [ValidateNever]
        public User Client { get; set; }
    }
}