using expense_service.Data;
using expense_service.Repositories.ExpenseRepository;
using expense_service.Services.ExpenseService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Register DbContext with connection string (replace with your actual connection string)
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Register Repositories
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
//Register services
builder.Services.AddScoped<IExpenseService, ExpenseService>();

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();   
app.Run();
