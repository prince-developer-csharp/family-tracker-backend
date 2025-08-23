using expense_service.Models;

namespace expense_service.Services.ExpenseService
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();

        Task<Expense> GetExpenseByIdAsync(int id);

        Task AddExpenseAsync(Expense expense);

        Task UpdateExpenseAsync(Expense expense);

        Task DeleteExpenseAsync(int id);
    }
}
