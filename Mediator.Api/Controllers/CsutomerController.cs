using Mediator.Application.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Api.Controllers
{
    [ApiController]
    [Route("/v1/Custoemrs")]
    public class CustomerController : ControllerBase
    {
        private IMediator Mediator { get; }

        public CustomerController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerResponse>> GetAllCustomers(CustomerRequest request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);

            return await Task.FromResult(result);
        }
    }
}