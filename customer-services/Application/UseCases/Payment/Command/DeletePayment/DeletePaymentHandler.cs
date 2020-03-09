
using System.Threading;
using System.Threading.Tasks;
using customer_services.Infrastructure.Presistences;
using MediatR;

namespace customer_services.Application.UseCases.Payment.Command.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentCommandDto>
    {
        private readonly CustomerContext _context;

        public DeletePaymentCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<DeletePaymentCommandDto> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Payments.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Payments.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeletePaymentCommandDto { Message = "Successfull", Success = true };
        }
    }
}