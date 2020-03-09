using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using System.Threading.Tasks;
using customer_services.Application.UseCases.Payment.Queries.GetPayment;
using customer_services.Application.UseCases.Payment.Queries.GetPayments;
using customer_services.Application.UseCases.Payment.Command.CreatePayment;
using customer_services.Application.UseCases.Payment.Command.UpdatePayment;
using customer_services.Application.UseCases.Payment.Command.DeletePayment;

namespace customer_services.Presenter.Controller
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;
        // protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public PaymentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetPaymentsDto>> GetPayments()
        {
            return Ok(await _mediatr.Send(new GetPaymentsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreatePaymentCommandDto>> PostPayment([FromBody] CreatePaymentCommand payload)
        {
            return Ok(await _mediatr.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new GetPaymentQuery(id)));
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> UpdatePayment(int id, UpdatePaymentCommand data)
        {
            data.DataD.Attributes.Id = id;

            return Ok(await _mediatr.Send(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var command = new DeletePaymentCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
    }
}