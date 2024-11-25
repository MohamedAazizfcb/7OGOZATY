using Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces.CommonInterfaces
{
    public interface IResponseService
    {
        ObjectResult CreateResponse<T>(Response<T> response);
    }
}
