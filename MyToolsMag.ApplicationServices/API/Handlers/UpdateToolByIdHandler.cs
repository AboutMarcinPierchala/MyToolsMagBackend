using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.DataAccess.CQRS.Commands;
using MyToolsMag.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToolsMag.DataAccess.CQRS.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class UpdateToolByIdHandler : IRequestHandler<UpdateToolByIdRequest, UpdateToolByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public UpdateToolByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateToolByIdResponse> Handle(UpdateToolByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetToolByNameQuery() 
            {
                Id = request.Id
            };
            var getTool = await this.queryExecutor.Execute(query);

            if (getTool == null) 
            {
                return new UpdateToolByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var toolCategoryNameQuery = new GetToolCategoryByIdQuery()
            {
                Id = request.ToolCategoryId
            };
            //var getToolCategory = await this.queryExecutor.Execute(toolCategoryNameQuery);
            //request.ToolCategoryName = getToolCategory.CategoryName;
            //var placeNameQuery = new GetPlaceByIdQuery()
            //{
            //    Id = request.PlaceId
            //};
            //var getPlaceName = await this.queryExecutor.Execute(placeNameQuery);
            //request.PlaceName = getPlaceName.PlaceName;
            //var personNameQuery = new GetPersonByNameQuery()
            //{
            //    Id = request.PersonId
            //};
            //var getPersonName = await this.queryExecutor.Execute(personNameQuery);
            //request.PersonName = getPersonName.PersonName;



            var tool = this.mapper.Map<DataAccess.Entities.Tool>(request);
            var command = new UpdateToolByIdCommand() { Parameter = tool };
            var toolFromDb = await this.commandExecutor.Execute(command);
            return new UpdateToolByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Tool>(toolFromDb)
            };
        }
    }
}
