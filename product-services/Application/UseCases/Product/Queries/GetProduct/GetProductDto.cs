using product_services.Application.Models.Query;
using product_services.Domain.Entities;

namespace product_services.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductDto : BaseDto
    {
        public ProductEn Data { get; set; }
    }
}