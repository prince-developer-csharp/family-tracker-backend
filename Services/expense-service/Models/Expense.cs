namespace expense_service.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
