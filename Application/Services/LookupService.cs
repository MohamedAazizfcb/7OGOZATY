using Application.Contracts;
using Domain.Entities.Lookups;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Results;

namespace Application.Services
{
    public class LookupService<T> : ILookupService<T> where T : Lookup
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;

        public LookupService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory)
        {
            _unitOfWork = unitOfWork;
            _operationResultFactory = operationResultFactory;
        }

        public async Task<OperationResultSingle<IEnumerable<T>>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<T>();
            var result = await repository.GetAllAsync();
            return _operationResultFactory.Success(result)!;
        }

        public async Task<OperationResultSingle<T>> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<T>();
            var result = await repository.GetByIdAsync(id);
            if (result == null)
            {
                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");
            }
            return _operationResultFactory.Success(result)!;
        }

        public async Task<OperationResultSingle<T>> AddAsync(T entity)
        {
            var repository = _unitOfWork.GetRepository<T>();
            await repository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            var result = entity;
            return _operationResultFactory.Success<T>(result)!;
        }

        public async Task<OperationResultSingle<T>> UpdateAsync(int id, T newEntity)
        {
            var repository = _unitOfWork.GetRepository<T>();
            var oldEntity = await repository.GetByIdAsync(id);
            if (oldEntity != null)
            {
                await repository.UpdateAsync(id, newEntity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success<T>(newEntity);
            }
            else
            {
                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");
            }

        }

        public async Task<OperationResultSingle<T>> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<T>();
            var entity = await repository.GetByIdAsync(id);
            if (entity != null)
            {
                await repository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success(entity);
            }
            else
            {
                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");
            }
        }
    }
}