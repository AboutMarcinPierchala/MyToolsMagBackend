using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess;
using MyToolsMag.DataAccess.Entities;
using System.Diagnostics.Eventing.Reader;

namespace MyToolsMag.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ToolCategoriesController : ApiControllerBase
    {
        public ToolCategoriesController(IMediator mediator, ILogger<ToolCategoriesController> logger) : base(mediator)
        {
            logger.LogInformation("ToolCategoriesControllerWasUsed");
        }   
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllToolCategories([FromQuery] GetToolCategoriesRequest request)
        {
            var response = await this.mediator.Send(request);

            return this.Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetToolCategoryById([FromRoute] int id)
        {
            var request = new GetToolCategoryByIdRequest()
            {
                Id = id
            };
            return this.HandleRequest<GetToolCategoryByIdRequest, GetToolCategoryByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]

        public Task<IActionResult> AddToolCategory([FromBody] AddToolCategoryRequest request)
        {
            return this.HandleRequest<AddToolCategoryRequest, AddToolCategoryResponse>(request);
        }

        [HttpPut]
        [Route("{toolCategoryId}")]
        public async Task<IActionResult> UpdateToolCategoryById([FromRoute] int toolCategoryId, [FromBody] UpdateToolCategoryByIdRequest request)
        {
            request.Id = toolCategoryId;

            return await this.HandleRequest<UpdateToolCategoryByIdRequest, UpdateToolCategoryByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]

        public  async Task<IActionResult> DelToolCategoryById([FromRoute] int id)
        {

            var request = new DeleteToolCategoryByIdRequest()
            {
                Id = id
            };
            //var response = await this.mediator.Send(request);
            ;
            //return this.Ok(response);
            return await this.HandleRequest<DeleteToolCategoryByIdRequest, DeleteToolCategoryByIdResponse>(request);

            //return this.Ok(request.Id);
        }
    }
}
