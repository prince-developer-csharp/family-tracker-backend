using expense_service.Models;
using expense_service.Repositories.Generic;

namespace expense_service.Repositories.ExpenseRepository
{
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
    }
}
