using System.ComponentModel.DataAnnotations;

namespace expense_service.DTOs.Expense
{
    public class ExpenseDto
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
