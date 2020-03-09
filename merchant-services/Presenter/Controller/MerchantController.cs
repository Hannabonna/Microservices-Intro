using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using System.Threading.Tasks;
using merchant_services.Application.UseCases.Merchant.Queries.GetMerchant;
using merchant_services.Application.UseCases.Merchant.Queries.GetMerchants;
using merchant_services.Application.UseCases.Merchant.Command.CreateMerchant;
using merchant_services.Application.UseCases.Merchant.Command.UpdateMerchant;
using merchant_services.Application.UseCases.Merchant.Command.DeleteMerchant;

namespace merchant_services.Presenter.Controller
{
    [ApiController]
    [Route("merchant")]
    public class MerchantController : ControllerBase
    {
        private IMediator _mediatr;
        //protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public MerchantController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetMerchantsDto>> GetMerchants()
        {
            return Ok(await _mediatr.Send(new GetMerchantsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<CreateMerchantCommandDto>> PostMerchant([FromBody] CreateMerchantCommand payload)
        {
            return Ok(await _mediatr.Send(payload));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMerchantDto>> GetById(int id)
        {
            return Ok(await _mediatr.Send(new GetMerchantQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMerchant(int id, UpdateMerchantCommand data)
        {
            data.DataD.Attributes.Id = id;

            return Ok(await _mediatr.Send(data));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            var command = new DeleteMerchantCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });
        }
    }
}