//using Application.Contracts;
//using Application.Dtos.Lookup.Response;
//using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
//using Domain.Interfaces.UnitOfWorkInterfaces;
//using Domain.Results;

//namespace Application.Services
//{
//    public class LookupService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IOperationResultFactory _operationResultFactory;

//        public LookupService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory)
//        {
//            _unitOfWork = unitOfWork;
//            _operationResultFactory = operationResultFactory;
//        }

//        s
//        public async Task<OperationResultSingle<CreateUpdateLookupResponse>> GetByIdAsync(int id)
//        {
//            var repository = _unitOfWork.GetRepository<T>();
//            var result = await repository.GetByIdAsync(id);
//            if (result == null)
//            {
//                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");
//            }
//            return _operationResultFactory.Success(result)!;
//        }

//        public async Task<OperationResultSingle<CreateUpdateLookupResponse>> CreateAsync(T entity)
//        {
//            var repository = _unitOfWork.GetRepository<T>();
//            await repository.AddAsync(entity);
//            await _unitOfWork.SaveAsync();
//            var result = entity;
//            return _operationResultFactory.Success(result)!;

//        }

//        public async Task<OperationResultSingle<CreateUpdateLookupResponse>> UpdateAsync(int id, T entity)
//        {
//            var repository = _unitOfWork.GetRepository<T>();
//            var oldEntity = await repository.GetByIdAsync(id);
//            if (oldEntity != null)
//            {
//                await repository.UpdateAsync(id, entity);
//                await _unitOfWork.SaveAsync();
//                return _operationResultFactory.Success<T>(entity);
//            }
//            else
//            {
//                return _operationResultFactory.NotFound<T>("The provided ID doesn't match any record!");
//            }

//        }

//        public async Task<OperationResultSingle<CreateUpdateLookupResponse>> DeleteAsync(int id)
//        {
//            var repository = _unitOfWork.GetRepository<T>();
//            var entity = await repository.GetByIdAsync(id);
//            if (entity != null)
//            {
//                await repository.DeleteAsync(entity);
//                await _unitOfWork.SaveAsync();
//                return _operationResultFactory.Success<CreateUpdateLookupResponse>(entity);
//            }
//            else
//            {
//                return _operationResultFactory.NotFound<CreateUpdateLookupResponse>("The provided ID doesn't match any record!");

//            }
//        }
//    }
//}
