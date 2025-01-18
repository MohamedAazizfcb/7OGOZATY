using Application.Contracts;
using Application.Dtos.Clinic;
using AutoMapper;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.ClinicEntity;
using Domain.Entities.User;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationResultFactory _operationResultFactory;
        private readonly IMapper _mapper;
        private readonly IFileHandler _fileHandler;
        private readonly string CLINIC_GALLERY_PATH = Path.Combine("wwwroot", "uploads", "Clinics");
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

            var clinic = _mapper.Map<Clinic>(request);

            clinic.ClinicGallery = new Collection<ClinicGallery>();
            var galleryFolder = GetClinicGalleryFolder(clinic.Email);

            foreach (var img in request.Gallery)
            {
                var galleryImg = new ClinicGallery()
                {
                    imgUrl = await _fileHandler.UploadAsync(img, galleryFolder)
                };
                clinic.ClinicGallery.Add(galleryImg);
            }

            await repository.AddAsync(clinic);
            await _unitOfWork.SaveAsync();

            return _operationResultFactory.Success("Done")!;
        }

        public async Task<OperationResultSingle<string>> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            var entity = await repository.GetByIdAsync(id);
            if (entity != null)
            {
                var galleryFolder = GetClinicGalleryFolder(entity.Email);

                if (Directory.Exists(galleryFolder))
                {
                    Directory.Delete(galleryFolder, true);
                }
                await repository.DeleteAsync(entity);
                await _unitOfWork.SaveAsync();
                return _operationResultFactory.Success("Done")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }

        public async Task<OperationResultSingle<ICollection<ClinicResponse>>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<Clinic>();

            var result = await repository.GetAllAsync(include:
               q => q
                .Include(c => c.Country)
                .Include(c => c.Governorate)
                .Include(c => c.District)
                .Include(c => c.ClinicGallery)!
            );

            var mappedResult = _mapper.Map<ICollection<ClinicResponse>>(result);
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ClinicResponse>> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Country,
                c => c.Governorate,
                c => c.District,
                c => c.ClinicGallery,
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
                var galleryFolder = GetClinicGalleryFolder(oldEntity.Email);
                if (Directory.Exists(galleryFolder))
                {
                    Directory.Delete(galleryFolder, true);
                }

                _mapper.Map(request, oldEntity); // Maps properties from newEntity to oldEntity


                galleryFolder = GetClinicGalleryFolder(oldEntity.Email);

           
                oldEntity.ClinicGallery = new Collection<ClinicGallery>();
                foreach (var img in request.Gallery)
                {
                    var galleryImg = new ClinicGallery()
                    {
                        imgUrl = await _fileHandler.UploadAsync(img, galleryFolder)
                    };
                    oldEntity.ClinicGallery.Add(galleryImg);

                }


                await repository.UpdateAsync(id, oldEntity); 
                await _unitOfWork.SaveAsync();

                return _operationResultFactory.Success("Done!")!;
            }
            else
            {
                return _operationResultFactory.NotFound<string>("The provided ID doesn't match any record!");
            }
        }

        public async Task<OperationResultSingle<ICollection<Doctor>>> GetClinicDoctors(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Doctors,
            ];

            var result = await repository.GetByIdAsync(id, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<ICollection<Doctor>>("The provided ID doesn't match any record!");
            }
            var mappedResult = result.Doctors;
            return _operationResultFactory.Success(mappedResult)!;
        }

        public async Task<OperationResultSingle<ICollection<Appointment>>> GetClinicAppointments(int id)
        {
            var repository = _unitOfWork.GetRepository<Clinic>();
            Expression<Func<Clinic, object>>[] includes = [
                c => c.Appointments,
            ];

            var result = await repository.GetByIdAsync(id, includes);
            if (result == null)
            {
                return _operationResultFactory.NotFound<ICollection<Appointment>>("The provided ID doesn't match any record!");
            }
            var mappedResult = result.Appointments;
            return _operationResultFactory.Success(mappedResult)!;
        }


        private string GetClinicGalleryFolder(string clinicEmail)
        {
            return Path.Combine(CLINIC_GALLERY_PATH, clinicEmail);
        }

    }
}
