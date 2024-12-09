using Application.Contracts;
using Application.Dtos;
using Application.Dtos.Clinic;
using AutoMapper;
using Azure.Core;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.ClinicEntity;
using Domain.Entities.User;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Results;
using Infrastructure.Utility.FileHandler;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IMapper _mapper;
        private readonly IFileHandler _fileHandler;

        public ClinicService(IUnitOfWork unitOfWork, IOperationResultFactory operationResultFactory, IMapper mapper, IFileHandler fileHandler)
        {
            _unitOfWork = unitOfWork;
            _operationResultFactory = operationResultFactory;
            _mapper = mapper;
            _fileHandler = fileHandler;
        }

        public async Task<OperationResultSingle<string>> CreateAsync(ClinicRequest request)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            await repository.AddAsync(_mapper.Map<Clinic>(request));

            await _unitOfWork.SaveAsync();


            Expression<Func<Clinic, bool>> filter = c => c.Email == request.Email;
            var clinic = await repository.GetAsync(null!, filter);

            return _operationResultFactory.Success("Done")!;
        }

        public async Task<OperationResultSingle<string>> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
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

        public async Task<OperationResultSingle<IEnumerable<ClinicResponse>>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Country,
                c => c.Governorate,
                c => c.District,
                c => c.Gallery,
            ];

            var result = await repository.GetAllAsync(includes);

            var mappedResult = _mapper.Map<IEnumerable<ClinicResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ClinicResponse>> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Country,
                c => c.Governorate,
                c => c.District,
                c => c.Gallery,
            ];

            var result = await repository.GetByIdAsync(id, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<ClinicResponse>("The provided ID doesn't match any record!");
            }
            var mappedResult = _mapper.Map<ClinicResponse>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<string>> UpdateAsync(int id, ClinicRequest request)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            var oldEntity = await repository.GetByIdAsync(id);
            if (oldEntity != null)
            {
                await repository.UpdateAsync(id, _mapper.Map(request, oldEntity)); // Maps properties from newEntity to oldEntity
                await _unitOfWork.SaveAsync();

                await UpdateClinicGallery(request.Gallery, id);

                return _operationResultFactory.Success("Done!")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }


        public async Task<OperationResultSingle<IEnumerable<Doctor>>> GetClinicDoctors(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Doctors,
            ];

            var result = await repository.GetByIdAsync(id, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<IEnumerable<Doctor>>("The provided ID doesn't match any record!");
            }
            var mappedResult = result.Doctors;
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<IEnumerable<Appointment>>> GetClinicAppointments(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Appointments,
            ];

            var result = await repository.GetByIdAsync(id, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<IEnumerable<Appointment>>("The provided ID doesn't match any record!");
            }
            var mappedResult = result.Appointments;
            return _operationResultFactory.Success(mappedResult)!;
        }



        private async Task CreateClinicGallery(List<IFormFile> gal, int clinicId)
        {
            var repository = _unitOfWork.GetRepository<ClinicGallery>();
            foreach(var req in gal)
            {
                var img = new ClinicGallery();
                img.ClinicId = clinicId;
                img.ImageDescription = "Desc";
                img.ImageUrl = await _fileHandler.UploadAsync(req, Path.Combine("wwwroot", "uploads", "Clinics", clinicId.ToString()));
                await repository.AddAsync(img);
                await _unitOfWork.SaveAsync();

            }
        }
        private async Task UpdateClinicGallery(List<IFormFile> gal, int clinicId)
        {
            var folder = Path.Combine("wwwroot", "uploads", "Clinics", clinicId.ToString());
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            
            var repository = _unitOfWork.GetRepository<ClinicGallery>();
            foreach (var req in gal)
            {
                var img = new ClinicGallery();
                img.ClinicId = clinicId;
                img.ImageDescription = "Desc";
                img.ImageUrl = await _fileHandler.UploadAsync(req, folder);
                await repository.AddAsync(img);
                await _unitOfWork.SaveAsync();

            }
        }

    }
}
