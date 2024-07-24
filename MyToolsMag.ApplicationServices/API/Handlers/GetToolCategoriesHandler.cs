using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.Models;
using MyToolsMag.DataAccess;
using MyToolsMag.DataAccess.Entities;

namespace MyToolsMag.ApplicationServices.API.Handlers
{
    public class GetToolCategoriesHandler : IRequestHandler<GetToolCategoriesRequest, GetToolCategoriesResponse>
    {
        private readonly IRepository<DataAccess.Entities.ToolCategory> toolCategoryRepository;
        private readonly IMapper mapper;

        public GetToolCategoriesHandler(IRepository<MyToolsMag.DataAccess.Entities.ToolCategory> toolCategoryRepository, IMapper mapper)
        {
            this.toolCategoryRepository = toolCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<GetToolCategoriesResponse> Handle(GetToolCategoriesRequest request, CancellationToken cancellationToken)
        {
            var toolCategories = await this.toolCategoryRepository.GetAll();
            var mappedToolCategories = this.mapper.Map<List<Domain.Models.ToolCategory>>(toolCategories);

            var response = new GetToolCategoriesResponse()
            {
                Data = mappedToolCategories
            };

            return response;

        }
    }
}
