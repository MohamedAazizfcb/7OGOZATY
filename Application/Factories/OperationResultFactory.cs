using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Results;
using System.Net;

namespace Application.Factories
{
    public class OperationResultFactory : IOperationResultFactory
    {
        // Implementing Success Responses
        public OperationResultBase<T> Deleted<T>() => new OperationResult<T> { StatusCode = HttpStatusCode.OK, Succeeded = true, Message = "Deleted Successfully" };
        public OperationResultBase<T> EmailVerified<T>() => new OperationResult<T> { StatusCode = HttpStatusCode.OK, Succeeded = true, Message = "Email Verified Successfully" };
        public OperationResultBase<T> EmailSent<T>() => new OperationResult<T> { StatusCode = HttpStatusCode.OK, Succeeded = true, Message = "Email Sent Successfully" };
        public OperationResultBase<T> PasswordUpdated<T>() => new OperationResult<T> { StatusCode = HttpStatusCode.OK, Succeeded = true, Message = "Password Updated Successfully" };
        public OperationResultBase<T> Success<T>(T entity) => new OperationResult<T> { Data = entity, StatusCode = HttpStatusCode.OK, Succeeded = true };
        public OperationResultBase<T> Uploaded<T>(T entity) => new OperationResult<T> { Data = entity, StatusCode = HttpStatusCode.OK, Succeeded = true, Message = "Uploaded Successfully" };
        public OperationResultBase<T> Updated<T>(T entity, string message = "Updated Successfully") => new OperationResult<T> { Data = entity, StatusCode = HttpStatusCode.OK, Succeeded = true, Message = message };
        public OperationResultBase<T> Created<T>(T entity, object meta = null!) => new OperationResult<T> { Data = entity, StatusCode = HttpStatusCode.Created, Succeeded = true };

        // Implementing Error Responses
        public OperationResultBase<T> Unauthorized<T>() => new OperationResult<T> { StatusCode = HttpStatusCode.Unauthorized, Succeeded = false, Message = "Unauthorized" };
        public OperationResultBase<T> BadRequest<T>(string message = "Bad Request") => new OperationResult<T> { StatusCode = HttpStatusCode.BadRequest, Succeeded = false, Message = message };
        public OperationResultBase<T> BadRequest<T>(List<string> errors) => new OperationResult<T> { StatusCode = HttpStatusCode.BadRequest, Succeeded = false, Errors = errors };
        public OperationResultBase<T> NotFound<T>(string message = "Not Found") => new OperationResult<T> { StatusCode = HttpStatusCode.NotFound, Succeeded = false, Message = message };
        public OperationResultBase<T> Conflict<T>(string message = "Conflict") => new OperationResult<T> { StatusCode = HttpStatusCode.Conflict, Succeeded = false, Message = message };
        public OperationResultBase<T> InternalServerError<T>(string message = "Internal Server Error") => new OperationResult<T> { StatusCode = HttpStatusCode.InternalServerError, Succeeded = false, Message = message };

        // Implementing Validation Responses
        public OperationResultBase<T> ValidationError<T>(List<string> errors) => new OperationResult<T> { StatusCode = HttpStatusCode.UnprocessableEntity, Succeeded = false, Errors = errors, Message = "Validation Errors" };
        public OperationResultBase<T> ValidationError<T>(string error) => new OperationResult<T> { StatusCode = HttpStatusCode.UnprocessableEntity, Succeeded = false, Errors = new List<string> { error }, Message = "Validation Error" };

        // Implementing Other Common Responses
        public OperationResultBase<T> Forbidden<T>(string message = "Forbidden") => new OperationResult<T> { StatusCode = HttpStatusCode.Forbidden, Succeeded = false, Message = message };
        public OperationResultBase<T> Accepted<T>(string message = "Request Accepted") => new OperationResult<T> { StatusCode = HttpStatusCode.Accepted, Succeeded = true, Message = message };
        public OperationResultBase<T> ServiceUnavailable<T>(string message = "Service Unavailable") => new OperationResult<T> { StatusCode = HttpStatusCode.ServiceUnavailable, Succeeded = false, Message = message };
        public OperationResultBase<T> UnauthorizedAccess<T>(string message = "Unauthorized Access") => new OperationResult<T> { StatusCode = HttpStatusCode.Unauthorized, Succeeded = false, Message = message };

    }
}
