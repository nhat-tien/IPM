using FluentValidation;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;

using IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;

using IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;

using IPM.WebApi.Validators.Auth;
using IPM.WebApi.Validators.ApprovingAgency;
using IPM.WebApi.Validators.AffiliatedUnit;

namespace IPM.WebApi.ServiceRegisters;

public static class ValidatorServiceRegister
{
    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        /*
         * ======= Authentication =======
         */
        services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        services.AddScoped<IValidator<SignInRequest>, SignInRequestValidator>();
        services.AddScoped<IValidator<RefreshTokenRequest>, RefreshTokenRequestValidator>();

        /*
         * ======= Approving Agency =======
         */
        services.AddScoped<IValidator<CreateApprovingAgencyRequest>, ApprovingAgencyCreateValidator>();
        services.AddScoped<IValidator<UpdateApprovingAgencyRequest>, ApprovingAgencyUpdateValidator>();

        /*
         * ======= Affiliated Unit =======
         */
        services.AddScoped<IValidator<CreateAffiliatedUnitRequest>, AffiliatedUnitCreateValidator>();
        services.AddScoped<IValidator<UpdateAffiliatedUnitRequest>, AffiliatedUnitUpdateValidator>();
        return services;
    }

}
