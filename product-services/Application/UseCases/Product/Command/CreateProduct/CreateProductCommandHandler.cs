using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using product_services.Infrastructure.Presistences;

namespace product_services.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandDto>
    {
        private readonly ProductContext _context;

        public CreateProductCommandHandler(ProductContext context)
        {
            _context = context;
        }

        public async Task<CreateProductCommandDto> Handle(CreateProductCommand request, CancellationToken cancellation)
        {
            var prod = new Domain.Entities.ProductEn
            {
                Merchant_Id = request.DataD.Attributes.Merchant_Id,
                Name = request.DataD.Attributes.Name,
                Price = request.DataD.Attributes.Price
            };

            _context.Products.Add(prod);
            await _context.SaveChangesAsync(cancellation);

            return new CreateProductCommandDto
            {
                Success = true,
                Message = "Product successfully created"
            };

        }
    }
}