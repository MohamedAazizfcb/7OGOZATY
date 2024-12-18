using Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Strategies.UserStrategies.CreateNewUserStrategy
{
    public class CreateNewUserStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<UserRolesEnum, Func<ICreateNewUserStrategy>> _strategyMap;

        public CreateNewUserStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            // Initialize dictionary with role to strategy mappings
            _strategyMap = new Dictionary<UserRolesEnum, Func<ICreateNewUserStrategy>>
            {
                { UserRolesEnum.Admin, () => _serviceProvider.GetRequiredService<CreateNewAdminStrategy>() },
                { UserRolesEnum.Doctor, () => _serviceProvider.GetRequiredService<CreateNewDoctorStrategy>() },
                { UserRolesEnum.Patient, () => _serviceProvider.GetRequiredService<CreateNewPatientStrategy>() },
                { UserRolesEnum.Secretary, () => _serviceProvider.GetRequiredService<CreateNewSecretaryStrategy>() }
            };
        }

        public ICreateNewUserStrategy GetStrategy(UserRolesEnum role)
        {
            if (_strategyMap.TryGetValue(role, out var strategyFactory))
            {
                return strategyFactory();
            }

            throw new InvalidOperationException($"No strategy found for role: {role}");
        }
    }
}
