using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using customer_services.Application.UseCases.Customer.Queries.GetCustomer;
using customer_services.Application.UseCases.Customer.Queries.GetCustomers;
using customer_services.Application.UseCases.Customer.Command.CreateCustomer;
using customer_services.Application.UseCases.Customer.Command.UpdateCustomer;
using customer_services.Application.UseCases.Customer.Command.DeleteCustomer;
using customer_services.Application.UseCases.Customer.Command;

namespace customer_services.Presenter.Controller
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;
        // protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public CustomerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersDto>> GetCustomers()
        {
            return Ok(await _mediatr.Send(new GetCustomersQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreateCustomerCommandDto>> PostCustomer([FromBody] CreateCustomerCommand payload)
        {
            return Ok(await _mediatr.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new GetCustomerQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerCommand data)
        {
            data.DataD.Attributes.Id = id;

            return Ok(await _mediatr.Send(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
    }
}