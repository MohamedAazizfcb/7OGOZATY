using Domain.Entities.User;

namespace Application.Contracts.Authentication
{
    public interface IJwtTokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
    }
}
