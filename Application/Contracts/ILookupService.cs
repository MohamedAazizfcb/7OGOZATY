using Application.Dtos.Lookup.Response;
using Azure.Core;
using Azure;
using Domain.Results;
using Application.Dtos.Lookup.Request;

namespace Application.Contracts
{
    public interface ILookupService
    {
        Task<OperationResultSingle<CreateUpdateLookupResponse>> CreateAsync(CreateUpdateLookupRequest entity);
        Task<OperationResultSingle<IEnumerable<CreateUpdateLookupResponse>>> GetAllAsync();
        Task<OperationResultSingle<CreateUpdateLookupResponse>> GetByIdAsync(int id);
        Task<OperationResultSingle<CreateUpdateLookupResponse>> UpdateAsync(int id, CreateUpdateLookupRequest entity);
        Task<OperationResultSingle<CreateUpdateLookupResponse>> DeleteAsync(int id);
    }
}
