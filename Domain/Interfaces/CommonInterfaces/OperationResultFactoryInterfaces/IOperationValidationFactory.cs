using Domain.Results;

namespace Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces
{
    public interface IOperationValidationFactory
    {
        OperationResultBase<T> ValidationError<T>(List<string> errors);
        OperationResultBase<T> ValidationError<T>(string error);
    }
}
