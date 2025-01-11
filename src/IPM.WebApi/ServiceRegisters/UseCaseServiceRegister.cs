using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.DeleteApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.GetAllApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;
using IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.DeleteAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.GetAllAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;
using IPM.Application.UseCases.Role;

namespace IPM.WebApi.ServiceRegisters;

public static class UseCaseServiceRegister
{
    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginHandler>();
        services.AddScoped<IRegisterUseCase, RegisterHandler>();
        services.AddScoped<IRefreshTokenUseCase, RefreshTokenHandler>();
        services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();

        services.AddScoped<IGetAllApprovingAgencyUseCase, GetAllApprovingAgencyHandler>();
        services.AddScoped<IUpdateApprovingAgencyUseCase, UpdateApprovingAgencyHandler>();
        services.AddScoped<IDeleteApprovingAgencyUseCase, DeleteApprovingAgencyHandler>();
        services.AddScoped<ICreateApprovingAgencyUseCase, CreateApprovingAgencyHandler>();

        services.AddScoped<ICreateAffiliatedUnitUseCase, CreateAffiliatedUnitHandler>();
        services.AddScoped<IDeleteAffiliatedUnitUseCase, DeleteAffiliatedUnitHandler>();
        services.AddScoped<IGetAllAffiliatedUnitUseCase, GetAllAffiliatedUnitHandler>();
        services.AddScoped<IUpdateAffiliatedUnitUseCase, UpdateAffiliatedUnitHandler>();
        return services;
    }

}
