using expense_service.Data;
using expense_service.Mapping;
using expense_service.Repositories.ExpenseRepository;
using expense_service.Services.ExpenseService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Register DbContext with connection string (replace with your actual connection string)
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//Register Repositories
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
//Register services
builder.Services.AddScoped<IExpenseService, ExpenseService>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular dev server
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAngularApp");
app.MapControllers();   
app.Run();
