using Application.Contracts;
using Application.Dtos.AppointmentDTO.Response;
using Application.Dtos.SpecializationServices.Request;
using Application.Dtos.SpecializationServices.Response;
using AutoMapper;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.ClinicEntity;
using Domain.Entities.SpecializationServicesEntity;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Application.Services
{
    public class SpecializationServicesService : ISpecializationServicesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IMapper _mapper;

        public SpecializationServicesService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _operationResultFactory = operationResultFactory;
            _mapper = mapper;
        }

        public async Task<OperationResultSingle<string>> CreateAsync(SpecializationServiceRequest request)
        {
            var repository = _unitOfWork.GetRepository<SpecializationService>();
            var service = _mapper.Map<SpecializationService>(request);

            await repository.AddAsync(service);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Service " + service.ServiceName + " is created successfully!");                    
        }

        public async Task<OperationResultSingle<string>> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<SpecializationService>();
            var entity = await repository.GetByIdAsync(id);
            if (entity != null)
            {
                await repository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success("Done")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }

        public async Task<OperationResultSingle<ICollection<SpecializationServiceResponse>>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<SpecializationService>();
            var result = await repository.GetAllAsync();

            var mappedResult = _mapper.Map<ICollection<SpecializationServiceResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<SpecializationServiceResponse>> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<SpecializationService>();
            var result = await repository.GetByIdAsync(id);
            if (result == null)
            {
                return _operationResultFactory.NotFound<SpecializationServiceResponse>("The provided ID doesn't match any record!");
            }
            var mappedResult = _mapper.Map<SpecializationServiceResponse>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ICollection<SpecializationServiceResponse>>> GetServiceBySpecializationId(int specializationid)
        {
            var repository = _unitOfWork.GetRepository<SpecializationService>();
            var result = await repository.GetAllAsync(
                filter:
                    s => s.SpecializationId == specializationid
            );

            var mappedResult = _mapper.Map<ICollection<SpecializationServiceResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<string>> UpdateAsync(int id, SpecializationServiceRequest request)
        {
            var repository = _unitOfWork.GetRepository<SpecializationService>();
            var oldEntity = await repository.GetByIdAsync(id);
            if (oldEntity != null)
            {
                _mapper.Map(request, oldEntity); // Maps properties from newEntity to oldEntity
                await repository.UpdateAsync(id, oldEntity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success("Done!")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }
    }
}
