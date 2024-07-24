using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess;
using MyToolsMag.DataAccess.Entities;
using System.Threading.Tasks;

namespace MyToolsMag.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ToolsController : ApiControllerBase
    {

        public ToolsController(IMediator mediator, ILogger<ToolsController> logger) : base(mediator)
        {
            logger.LogInformation("ToolsControllerWasUsed");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllTools([FromQuery] GetToolsRequest request)
        {
            return this.HandleRequest<GetToolsRequest, GetToolsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetToolByName([FromRoute] int id )
        {
            var request = new GetToolByNameRequest()
            {
                Id = id
            };
            return this.HandleRequest<GetToolByNameRequest, GetToolByNameResponse>(request);
        }

        [HttpPost]
        [Route("")]

        public Task<IActionResult> AddTool([FromBody] AddToolRequest request)
        {
            return this.HandleRequest<AddToolRequest, AddToolResponse>(request);
        }

        //[HttpPut]
        //[Route("{toolName}")]
        //public Task<IActionResult> PutToolByName([FromRoute] string toolName, [FromBody] PutToolByNameRequest request)
        //{
        //    //request.ToolName = toolName;
        //    //var response = await this.mediator.Send(request);
        //    //return this.Ok(response);
        //    return this.HandleRequest<PutToolByNameRequest, PutToolByNameResponse>(request);
        //}
        [HttpPut]
        [Route("{toolId}")]
        public async Task<IActionResult> UpdateToolById([FromRoute] int toolId, [FromBody] UpdateToolByIdRequest request)
        {
            request.Id = toolId;
            
            //{
            //    Id = id,
            //    ToolName = toolName,
            //    ToolCategoryId = toolCategoryId,
            //    PlaceId = PlaceId,
            //    PersonId = personId
            //};
            
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
            return await this.HandleRequest<UpdateToolByIdRequest, UpdateToolByIdResponse>(request);
        }
    }
}
