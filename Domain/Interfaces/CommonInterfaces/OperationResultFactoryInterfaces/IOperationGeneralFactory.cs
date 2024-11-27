using Domain.Results;

namespace Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces
{
    public interface IOperationGeneralFactory
    {
        OperationResultBase<T> Forbidden<T>(string message = "Forbidden");
        OperationResultBase<T> Accepted<T>(string message = "Request Accepted");
        OperationResultBase<T> ServiceUnavailable<T>(string message = "Service Unavailable");
        OperationResultBase<T> UnauthorizedAccess<T>(string message = "Unauthorized Access");
    }
}
