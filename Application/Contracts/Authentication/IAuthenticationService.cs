using Application.Dtos.Authentication;
using Domain.Results;

namespace Application.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        Task<OperationResultSingle<AuthenticationResponse>> LoginAsync(LoginRequest request);
        Task<OperationResultSingle<string>> CreateDoctorAsync(CreateDoctorRequest request);
        Task<OperationResultSingle<string>> CreatePatientAsync(CreatePatientRequest request);
        Task<OperationResultSingle<string>> CreateSecretaryAsync(CreateSecretaryRequest request);

        //Task<Response<GetUserResponse>> RefreshTokenAsync(string token);
        //Task<Response<bool>> RevokeTokenAsync(string token);
        //Task<Response<bool>> SendConfirmationEmailAsync(string email);
        //Task<Response<bool>> ConfirmEmailAsync(ConfirmEmailRequest request);
        //Task<Response<string>> ForgetPassword(string email);
        //Task<Response<string>> ResetPassword(ResetPasswordRequest request);
    }
}
