using System.Net;

namespace Application.Dtos.Common
{
    public class Response<T>
    {
        #region Common Properties
        public HttpStatusCode StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }
        #endregion


        #region Pagination Properties
        public int? CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalCount { get; set; }
        public int? PageSize { get; set; }
        public bool? HasPreviousPage => CurrentPage > 1;
        public bool? HasNextPage => CurrentPage < TotalPages;
        #endregion

    }
}
