using Application.Dtos.Authentication.Request;
using AutoMapper;
using Domain.Entities.MedicalRecordEntities;
using Domain.Entities.User;
using Domain.Enums;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Domain.Interfaces.UtilityInterfaces.FileHandlerInterfaces;
using Domain.Results;
using Microsoft.AspNetCore.Identity;

namespace Application.Strategies.UserStrategies.CreateNewUserStrategy
{
    public class CreateNewPatientStrategy : BaseCreateUserStrategy, ICreateNewUserStrategy
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateNewPatientStrategy(IOperationResultFactory operationResultFactory, IFileHandler fileHandler, UserManager<ApplicationUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
            : base(operationResultFactory, fileHandler, userManager, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResultSingle<string>> CreateNewUser(BaseCreateUserRequest req)
        {
            var request = req as CreatePatientRequest;

            var user = _mapper.Map<Patient>(request);
            user.ProfilePicture = await SaveUserPicture(request.ProfilePicture);

            SetUserBasicProfile(user, UserRolesEnum.Patient);

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    DeleteUserPicture(user.ProfilePicture);
                }

                user.MedicalRecord = new MedicalRecord();
                user.MedicalRecord.PatientId = user.Id;
                var medicalRepo = _unitOfWork.GetRepository<MedicalRecord>();
                await medicalRepo.AddAsync(user.MedicalRecord);
                await _unitOfWork.SaveAsync();
                return await GetOperationResult(result);
            }
            catch (Exception ex)
            {
                DeleteUserPicture(user.ProfilePicture);
                return await GetOperationResult(null, ex.Message);
            }
        }
    }
}
