using Domain.Results;

namespace Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces
{
    public interface IOpertionSuccessFactory
    {
        OperationResultBase<T> Deleted<T>();
        OperationResultBase<T> EmailVerified<T>();
        OperationResultBase<T> EmailSent<T>();
        OperationResultBase<T> PasswordUpdated<T>();
        OperationResultBase<T> Success<T>(T entity);
        OperationResultBase<T> Uploaded<T>(T entity);
        OperationResultBase<T> Updated<T>(T entity, string message = "Updated Successfully");
        OperationResultBase<T> Created<T>(T entity, object meta = null!);
    }
}
