using CuraFlow.Application.Common.Models;
using CuraFlow.Application.Features.Identity;
using CuraFlow.Application.Features.Identity.Commands.GenerateToken;
using CuraFlow.Application.Features.Identity.Commands.RefreshToken;
using CuraFlow.Application.Features.Identity.Dtos;
using CuraFlow.Application.Features.Identity.Queries.GetUserById;
using CuraFlow.Application.Features.Identity.Queries.GetUsers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CuraFlow.Api.Controllers.V1;

[Route("/identity")]
public class IdentityController(ISender sender) : ApiController
{
    [HttpPost("token/generate")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Generates an access token.")]
    [EndpointDescription("Authenticates with the supplied email and password and returns an access token and refresh token.")]
    [EndpointName("GenerateToken")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Generate(GenerateTokenCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpPost("token/refresh")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Refreshes an access token.")]
    [EndpointDescription("Exchanges the supplied expired access token and refresh token for a new token pair.")]
    [EndpointName("RefreshToken")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> Refresh(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Gets a user by ID.")]
    [EndpointDescription("Returns the user associated with the specified user ID.")]
    [EndpointName("GetUserById")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetById(string userId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetUserByIdQuery(userId), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagenatedList<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Lists users.")]
    [EndpointDescription("Returns the paginated list of user accounts.")]
    [EndpointName("GetUsers")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetUsersQuery(), cancellationToken);

        return result.Match(_ => Ok(_), Problem);
    }
}