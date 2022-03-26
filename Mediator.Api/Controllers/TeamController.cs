using Mediator.Application.Commands;
using Mediator.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Api.Controllers;
[Route("v1/teams")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeamController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<Player>>> Post(
            [FromBody] ChangePlayerCommand command
        )
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public ActionResult<GenericResult> Get(
            string technicianName
        )
    {
        var technician = new Technician(technicianName);
        var result = new GenericResult(technician.Team);
        result.AddMessage("Getting the default team config.");
        return Ok(result);
    }

}