using AutoMapper;
using expense_service.DTOs.Expense;
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
        private readonly IMapper _mapper;

        public ExpensesController(IExpenseService expenseService, IMapper mapper    )
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();

            // Map List<Expense> to List<ExpenseDto>
            var expenseDtos = _mapper.Map<IEnumerable<ExpenseDto>>(expenses);

            return Ok(expenseDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDto>> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
                return NotFound();

            var dto = _mapper.Map<ExpenseDto>(expense);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> CreateExpense(ExpenseDto dto)
        {
            var expense = _mapper.Map<Expense>(dto);
            expense.Date = DateTime.Now;
            await _expenseService.AddExpenseAsync(expense);

            var createdDto = _mapper.Map<ExpenseDto>(expense);
            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, createdDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, ExpenseDto dto)
        {
            var existingExpense = await _expenseService.GetExpenseByIdAsync(id);
            if (existingExpense == null)
                return NotFound();

            _mapper.Map(dto, existingExpense);
            await _expenseService.UpdateExpenseAsync(existingExpense);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var existingExpense = await _expenseService.GetExpenseByIdAsync(id);
            if (existingExpense == null)
                return NotFound();

            await _expenseService.DeleteExpenseAsync(id);
            return NoContent();
        }
    }
}
