using expense_service.Models;
using expense_service.Repositories.ExpenseRepository;

namespace expense_service.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {

        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetByIdAsync(id);
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));

            // You can add business validations here if needed

            await _expenseRepository.AddAsync(expense);
            await _expenseRepository.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));

            // More validation or business logic here if needed

            _expenseRepository.Update(expense);
            await _expenseRepository.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null)
                throw new KeyNotFoundException($"Expense with id {id} not found.");

            _expenseRepository.Delete(expense);
            await _expenseRepository.SaveChangesAsync();
        }
    }
}
