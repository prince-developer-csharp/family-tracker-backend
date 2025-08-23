using expense_service.Data;
using expense_service.Models;
using expense_service.Repositories.Generic;

namespace expense_service.Repositories.ExpenseRepository
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly ExpenseDbContext _context;

        public ExpenseRepository(ExpenseDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
