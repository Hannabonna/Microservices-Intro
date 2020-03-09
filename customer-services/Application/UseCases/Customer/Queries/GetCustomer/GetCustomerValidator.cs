using FluentValidation;

namespace customer_services.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}