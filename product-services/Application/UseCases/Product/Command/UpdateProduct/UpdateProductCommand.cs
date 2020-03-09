
using product_services.Application.Models.Query;
using product_services.Domain.Entities;
using MediatR;

namespace product_services.Application.UseCases.Product.Command.UpdateProduct
{
    public class UpdateProductCommand : RequestData<ProductEn>,IRequest<UpdateProductCommandDto>
    {
        
    }
}