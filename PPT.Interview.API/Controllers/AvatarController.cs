using MediatR;
using Microsoft.AspNetCore.Mvc;
using PPT.Interview.API.Dto;
using PPT.Interview.Application.Avatar.Queries.AvatarDetails;

namespace PPT.Interview.API.Controllers;

[ApiController]
public class AvatarController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ILogger<AvatarController> logger;

    public AvatarController(IMediator mediator, ILogger<AvatarController> logger)
    {
        this.mediator = mediator;
        this.logger = logger;
    }

    /// <summary>
    /// Retrieves the user's avatar based on the specified user identifier.
    /// </summary>
    /// <param name="userIdentifier"></param>
    /// <returns>Avatar url address</returns>
    [HttpGet("avatar")]
    public  async Task<IActionResult> Get([FromQuery]string? userIdentifier)
    {
        return Ok(new AvatarOutputDto() { Url =  await mediator.Send(new AvatarQuery(userIdentifier)) });
    }
}
