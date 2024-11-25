using Microsoft.AspNetCore.Mvc;
using System.Net;
using Domain.Results;
using Domain.Interfaces.CommonInterfaces;

namespace Application.Services
{
    public class ResponseService : IResponseService
    {
        public ObjectResult CreateResponse<T>(Response<T> response)
        {
            ObjectResult result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    result = new OkObjectResult(response);
                    break;
                case HttpStatusCode.Created:
                    result = new CreatedResult(string.Empty, response);
                    break;
                case HttpStatusCode.Unauthorized:
                    result = new UnauthorizedObjectResult(response);
                    break;
                case HttpStatusCode.BadRequest:
                    result = new BadRequestObjectResult(response);
                    break;
                case HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(response);
                    break;
                case HttpStatusCode.Accepted:
                    result = new AcceptedResult(string.Empty, response);
                    break;
                case HttpStatusCode.UnprocessableEntity:
                    result = new UnprocessableEntityObjectResult(response);
                    break;
                default:
                    result = new BadRequestObjectResult(response);
                    break;
            }

            return result;
        }
    }
}
