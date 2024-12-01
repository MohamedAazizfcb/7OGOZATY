using Domain.Interfaces;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Results;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class LookupService<T> : ILookupService<T> where T : class
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
            var results = await repository.GetAllAsync();
            return _operationResultFactory.Success(results);
        }

        public async Task<OperationResultSingle<T>> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<T>();
            var result = await repository.GetByIdAsync(id);
            if(result == null)
            {
                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");
            }
            return _operationResultFactory.Success(result)!;
        }

        public async Task<OperationResultSingle<T>> CreateAsync(T entity)
        {
            var repository = _unitOfWork.GetRepository<T>();
            await repository.AddAsync(entity);
            await _unitOfWork.SaveAsync(); 
            var result = entity;
            return _operationResultFactory.Success(result)!;

        }

        public async Task<OperationResultSingle<T>> UpdateAsync(int id, T entity)
        {
            var repository = _unitOfWork.GetRepository<T>();
            var oldEntity = await repository.GetByIdAsync(id);
            if (oldEntity != null)
            {
                await repository.UpdateAsync(id, entity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success<T>(entity);
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
                return _operationResultFactory.Success<T>(entity);
            }
            else
            {
                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");

            }
        }
    }
}
