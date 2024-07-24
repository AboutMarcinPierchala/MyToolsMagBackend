using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyToolsMag.ApplicationServices.API.Domain;

namespace MyToolsMag.Controllers
{
    //[Authorize]
    //[ApiController]
    //[Route("[controller]")]
    public class PersonsController : ApiControllerBase
    {

        public PersonsController(IMediator mediator, ILogger<PersonsController> logger) : base(mediator)
        {
            logger.LogInformation("PersonsControllerWasUsed");
        }

        //[AllowAnonymous]
        [HttpGet]
        [Route("")]

        public Task<IActionResult> GetAllPersons([FromQuery] GetPersonsRequest request)
        {
            return this.HandleRequest<GetPersonsRequest, GetPersonsResponse>(request);
        }


        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            var request = new GetPersonByNameRequest()
            {
                Id = id
            };
            return this.HandleRequest<GetPersonByNameRequest, GetPersonByNameResponse>(request);
        }

        [HttpPost]
        [Route("")]

        public Task<IActionResult> AddPerson([FromBody] AddPersonRequest request)
        {
            return this.HandleRequest<AddPersonRequest, AddPersonResponse>(request);
        }

        [HttpPut]
        [Route("{personId}")]
        public async Task<IActionResult> UpdatePersonById([FromRoute] int personId, [FromBody] UpdatePersonByIdRequest request)
        {
            request.Id = personId;

            return await this.HandleRequest<UpdatePersonByIdRequest, UpdatePersonByIdResponse>(request);
        }


    [HttpDelete]
        [Route("{id}")]

        public Task<IActionResult> DelPersonById([FromRoute] int id)
        {

            var request = new DeletePersonByIdRequest()
            {
                Id = id
            };
            
            return this.HandleRequest<DeletePersonByIdRequest, DeletePersonByIdResponse>(request);
        }
    }
}
