using AutoMapper;
using expense_service.DTOs.Expense;
using expense_service.Models;

namespace expense_service.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Expense, ExpenseDto>().ReverseMap();
        }
    }
}
