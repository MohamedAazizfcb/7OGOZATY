using Domain.Results;

namespace Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces
{
    public interface IOperationErrorFactory
    {
        OperationResultBase<T> Unauthorized<T>();
        OperationResultBase<T> BadRequest<T>(string message = "Bad Request");
        OperationResultBase<T> BadRequest<T>(List<string> errors);
        OperationResultBase<T> NotFound<T>(string message = "Not Found");
        OperationResultBase<T> Conflict<T>(string message = "Conflict");
        OperationResultBase<T> InternalServerError<T>(string message = "Internal Server Error");s
    }
}
