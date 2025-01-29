using Application.Dtos.SpecializationServices.Request;
using Application.Dtos.SpecializationServices.Response;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.Lookups;
using Domain.Entities.User;
using Domain.Results;

namespace Application.Contracts
{
    public interface ISpecializationServicesService
    {
        Task<OperationResultSingle<string>> CreateAsync(SpecializationServiceRequest request);
        Task<OperationResultSingle<ICollection<SpecializationServiceResponse>>> GetAllAsync();
        Task<OperationResultSingle<SpecializationServiceResponse>> GetByIdAsync(int id);
        Task<OperationResultSingle<string>> UpdateAsync(int id, SpecializationServiceRequest request);
        Task<OperationResultSingle<string>> DeleteAsync(int id);
        Task<OperationResultSingle<ICollection<SpecializationServiceResponse>>> GetServiceBySpecializationId(int specializationid);
    }
}
