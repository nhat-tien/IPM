using FluentValidation;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;

using IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;

using IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;

using IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.UpdateCurrencyUnitUseCase;

using IPM.Application.UseCases.AidType.CreateAidTypeUseCase;
using IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;

using IPM.Application.UseCases.Category.CreateCategoryUseCase;
using IPM.Application.UseCases.Category.UpdateCategoryUseCase;

using IPM.Application.UseCases.FileType.CreateFileTypeUseCase;
using IPM.Application.UseCases.FileType.UpdateFileTypeUseCase;

using IPM.Application.UseCases.Counterparty.CreateCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.UpdateCounterpartyUseCase;

using IPM.Application.UseCases.Position.CreatePositionUseCase;
using IPM.Application.UseCases.Position.UpdatePositionUseCase;

using IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;
using IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;

using IPM.Application.UseCases.Project.CreateProjectUseCase;
using IPM.Application.UseCases.Project.UpdateProjectUseCase;

using IPM.WebApi.Validators.Auth;
using IPM.WebApi.Validators.ApprovingAgency;
using IPM.WebApi.Validators.AffiliatedUnit;
using IPM.WebApi.Validators.CurrencyUnit;
using IPM.WebApi.Validators.AidType;
using IPM.WebApi.Validators.Category;
using IPM.WebApi.Validators.FileType;
using IPM.WebApi.Validators.Counterparty;
using IPM.WebApi.Validators.Position;
using IPM.WebApi.Validators.Sponsor;
using IPM.WebApi.Validators.Project;

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

        /*
         * ======= Currency Unit =======
         */
        services.AddScoped<IValidator<CreateCurrencyUnitRequest>, CurrencyUnitCreateValidator>();
        services.AddScoped<IValidator<UpdateCurrencyUnitRequest>, CurrencyUnitUpdateValidator>();

        /*
         * ======= Aid Type =======
         */
        services.AddScoped<IValidator<CreateAidTypeRequest>, AidTypeCreateValidator>();
        services.AddScoped<IValidator<UpdateAidTypeRequest>, AidTypeUpdateValidator>();

        services.AddScoped<IValidator<CreateCategoryRequest>, CategoryCreateValidator>();
        services.AddScoped<IValidator<UpdateCategoryRequest>, CategoryUpdateValidator>();

        services.AddScoped<IValidator<CreateCounterpartyRequest>, CounterpartyCreateValidator>();
        services.AddScoped<IValidator<UpdateCounterpartyRequest>, CounterpartyUpdateValidator>();

        services.AddScoped<IValidator<CreatePositionRequest>, PositionCreateValidator>();
        services.AddScoped<IValidator<UpdatePositionRequest>, PositionUpdateValidator>();

        services.AddScoped<IValidator<CreateSponsorRequest>, SponsorCreateValidator>();
        services.AddScoped<IValidator<UpdateSponsorRequest>, SponsorUpdateValidator>();

        services.AddScoped<IValidator<CreateProjectRequest>, ProjectCreateValidator>();
        services.AddScoped<IValidator<UpdateProjectRequest>, ProjectUpdateValidator>();

        services.AddScoped<IValidator<CreateFileTypeRequest>, FileTypeCreateValidator>();
        services.AddScoped<IValidator<UpdateFileTypeRequest>, FileTypeUpdateValidator>();
        return services;
    }

}
