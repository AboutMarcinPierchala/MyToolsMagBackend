﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Domain.ErrorHandling;
using System.Net;
using System.Security.Claims;

namespace MyToolsMag.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {   
            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors =  x.Value.Errors }));
            }
            //if (User.Claims.FirstOrDefault() != null)
            //{
            //    (request as RequestBase).Username = User.FindFirstValue(ClaimTypes.Name);
            //}
            var response = await this.mediator.Send(request);
            if(response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Forbidden:
                    return HttpStatusCode.Forbidden;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.TooManyRequests:
                    return HttpStatusCode.TooManyRequests;
                case ErrorType.Conflict:
                    return HttpStatusCode.Conflict;
                default:
                    return HttpStatusCode.BadRequest;
                //case ErrorType.ValidationError:
                //      return HttpStatusCode.ValidationError;
                //case ErrorType.NotAuthenticated:
                //    return HttpStatusCode.NotAuthenticated;
            }
        }
    }
}
