using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyToolsMag.ApplicationServices.API.Domain;

namespace MyToolsMag.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class PlacesController : ApiControllerBase
    {

        public PlacesController(IMediator mediator,ILogger<PlacesController> logger) : base(mediator)
        {
            logger.LogInformation("PlacesControllerWasUsed");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPlaces([FromQuery] GetPlacesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetPlaceById([FromRoute] int id)
        {
            var request = new GetPlaceByIdRequest()
            {
                Id = id
            };
            return this.HandleRequest<GetPlaceByIdRequest,  GetPlaceByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]

        public Task<IActionResult> AddPlace([FromBody] AddPlaceRequest request)
        {
            return this.HandleRequest<AddPlaceRequest, AddPlaceResponse>(request);
        }
        
        [HttpPut]
        [Route("{placeId}")]
        public async Task<IActionResult> UpdatePlaceById([FromRoute] int placeId, [FromBody] UpdatePlaceByIdRequest request)
        {
            request.Id = placeId;

            return await this.HandleRequest<UpdatePlaceByIdRequest, UpdatePlaceByIdResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]

        public Task<IActionResult> DelPlaceById([FromRoute] int id)
        {

            var request = new DeletePlaceByIdRequest()
            {
                Id = id
            };
            //var response = await this.mediator.Send(request);

            //return this.Ok(response);
            return this.HandleRequest<DeletePlaceByIdRequest, DeletePlaceByIdResponse>(request);
        }
    }
}
