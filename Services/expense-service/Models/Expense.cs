using System.ComponentModel.DataAnnotations;

namespace expense_service.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
