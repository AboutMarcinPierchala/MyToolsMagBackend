using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.Authentication;
using System.Threading.Tasks;

namespace MyToolsMag.Controllers
{
    [Authorize]

    public class AdminsController : ApiControllerBase
    {

        public AdminsController(IMediator mediator, ILogger<AdminsController> logger) : base(mediator)
        {
            logger.LogInformation("AdminsControllerWasUsed");
        }

        [HttpGet]
        [Route("")]

        public Task<IActionResult> GetAll([FromQuery] GetAdminsRequest request)
        {
            return this.HandleRequest<GetAdminsRequest, GetAdminsResponse>(request);
        }

        [HttpGet]
        [Route("{me}")]
        public async Task<IActionResult> GetMe([FromRoute] string me)
        {
            var request = new GetMeRequest()
            {
                Me = me
            };
            return await this.HandleRequest<GetMeRequest, GetMeResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]

        public Task<IActionResult> CreateAdmin([FromBody] CreateAdminRequest request)
        {
            return this.HandleRequest<CreateAdminRequest, CreateAdminResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public Task<IActionResult> Post([FromBody] ValidateAdminRequest request)
        {
            return this.HandleRequest<ValidateAdminRequest, ValidateAdminResponse>(request);
        }


    }
}
