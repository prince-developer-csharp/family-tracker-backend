using expense_service.Models;
using expense_service.Services.ExpenseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace expense_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/expenses
        [HttpGet]
        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return expenses;
        }
    }
}
