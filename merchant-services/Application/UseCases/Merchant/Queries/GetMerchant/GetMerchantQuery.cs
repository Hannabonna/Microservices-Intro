using MediatR;

namespace merchant_services.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<GetMerchantDto>
    {
        public int Id { get; set; }

        public GetMerchantQuery(int id)
        {
            Id = id;
        }
    }
}