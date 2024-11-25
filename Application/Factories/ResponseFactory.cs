using Application.Dtos.Common;
using System.Net;

namespace Application.Factories
{
    public static class ResponseFactory
    {
        public static Response<T> Success<T>(T data, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new Response<T>
            {
                Data = data,
                Message = message,
                Succeeded = true,
                StatusCode = statusCode
            };
        }

        public static Response<List<T>> SuccessPaginated<T>(IEnumerable<T> data, int totalCount, int currentPage, int pageSize, string message = "")
        {
            var dataList = data.ToList();
            return new Response<List<T>>
            {
                Data = dataList,
                CurrentPage = currentPage,
                TotalCount = totalCount,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                Succeeded = true,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static Response<T> Failure<T>(List<string> errors, string message = "", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new Response<T>
            {
                Errors = errors,
                Message = message,
                Succeeded = false,
                StatusCode = statusCode
            };
        }
    }
}
