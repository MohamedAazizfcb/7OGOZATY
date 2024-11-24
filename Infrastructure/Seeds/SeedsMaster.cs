using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seeds
{
    public static class SeedsMaster
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> _roleManager,
                                           UserManager<ApplicationUser> _userManager)
        {
            await RoleSeeds.SeedAsync(_roleManager);
            await UserSeeds.SeedAsync(_userManager);
        }
    }
}
