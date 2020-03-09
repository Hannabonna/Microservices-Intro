using System.Collections.Generic;
using product_services.Application.Models.Query;
using product_services.Domain.Entities;

namespace product_services.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsDto : BaseDto
    {
        public IList<ProductEn> Data { get; set; }
    }
}