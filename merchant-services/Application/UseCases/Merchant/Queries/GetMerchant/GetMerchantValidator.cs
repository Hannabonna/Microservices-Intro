using FluentValidation;

namespace merchant_services.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantValidator : AbstractValidator<GetMerchantQuery>
    {
        public GetMerchantValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
        }
    }
}