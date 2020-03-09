using System;
using System.Threading;
using System.Threading.Tasks;
using product_services.Infrastructure.Presistences;
using MediatR;


namespace product_services.Application.UseCases.Product.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandDto>
    {
        private readonly ProductContext _context;
        
        public UpdateProductCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductCommandDto> Handle(UpdateProductCommand request, CancellationToken cancellation)
        {
            var product = _context.Products.Find(request.DataD.Attributes.Id);
            
            product.Merchant_Id = request.DataD.Attributes.Merchant_Id;
            product.Name = request.DataD.Attributes.Name;
            product.Price = request.DataD.Attributes.Price;

            await _context.SaveChangesAsync(cancellation);

            return new UpdateProductCommandDto
            {
                Success = true,
                Message = "Payment successfully updated"
            };
        }
    }
}