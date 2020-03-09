using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using customer_services.Infrastructure.Presistences;

namespace customer_services.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandDto>
    {
        private readonly CustomerContext _context;

        public CreatePaymentCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<CreatePaymentCommandDto> Handle(CreatePaymentCommand request, CancellationToken cancellation)
        {
            var payment = new Domain.Entities.PaymentEn
            {
                Customer_Id = request.DataD.Attributes.Customer_Id,
                NameOnCard = request.DataD.Attributes.NameOnCard,
                ExpMonth = request.DataD.Attributes.ExpMonth,
                ExpYear = request.DataD.Attributes.ExpYear,
                CreditCardNum = request.DataD.Attributes.CreditCardNum
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync(cancellation);

            return new CreatePaymentCommandDto
            {
                Success = true,
                Message = "Merchant successfully created"
            };

        }
    }
}