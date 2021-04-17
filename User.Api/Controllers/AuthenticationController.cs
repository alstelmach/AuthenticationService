using System.Threading;
using System.Threading.Tasks;
using AsCore.Application.Abstractions.Messaging.Commands;
using AsCore.Application.Abstractions.Messaging.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Contracts.Authentication;
using User.Application.Dto;
using Controller = AsCore.Infrastructure.Mvc.Controller;

namespace User.Api.Controllers
{
    [ApiController]
    [Route(RoutePattern)]
    [ApiVersion(DefaultApiVersion)]
    public sealed class AuthenticationController : Controller
    {
        public AuthenticationController(ICommandBus commandBus,
            IQueryBus queryBus)
                : base(commandBus,
                    queryBus)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResultDto>> AuthenticateAsync([FromBody] AuthenticationQuery query,
            CancellationToken cancellationToken)
        {
            var authenticationResult = await QueryBus.QueryAsync(query, cancellationToken);
            
            return authenticationResult.IsAuthenticated
                ? Ok(authenticationResult)
                : Unauthorized(authenticationResult);
        }
    }
}
