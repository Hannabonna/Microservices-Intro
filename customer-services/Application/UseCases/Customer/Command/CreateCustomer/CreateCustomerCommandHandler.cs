using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using customer_services.Domain.Entities;
using customer_services.Infrastructure.Presistences;

namespace customer_services.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly CustomerContext _context;

        public CreateCustomerCommandHandler(CustomerContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellation)
        {
            var cu = new Domain.Entities.CustomerEn
            {
                Fullname = request.DataD.Attributes.Fullname,
                Username = request.DataD.Attributes.Username,
                Birthdate = request.DataD.Attributes.Birthdate,
                Gender = request.DataD.Attributes.Gender,
                Email = request.DataD.Attributes.Email
            };

            if (request.DataD.Attributes.Gender == "male")
            {
                cu.Sex = Gender.Male;
            }
            else if (request.DataD.Attributes.Gender == "female")
            {
                cu.Sex = Gender.Female;
            }

             _context.Customers.Add(cu);
            await _context.SaveChangesAsync(cancellation);

            return new CreateCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully created"
            };

        }
    }
}