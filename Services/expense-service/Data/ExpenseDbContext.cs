using expense_service.Models;
using Microsoft.EntityFrameworkCore;

namespace expense_service.Data
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
    : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
