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

using IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.DeleteCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.GetAllCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.UpdateCurrencyUnitUseCase;

using IPM.Application.UseCases.AidType.CreateAidTypeUseCase;
using IPM.Application.UseCases.AidType.DeleteAidTypeUseCase;
using IPM.Application.UseCases.AidType.GetAllAidTypeUseCase;
using IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;

using IPM.Application.UseCases.Category.CreateCategoryUseCase;
using IPM.Application.UseCases.Category.DeleteCategoryUseCase;
using IPM.Application.UseCases.Category.GetAllCategoryUseCase;
using IPM.Application.UseCases.Category.UpdateCategoryUseCase;

using IPM.Application.UseCases.Counterparty.CreateCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.DeleteCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.GetAllCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.UpdateCounterpartyUseCase;

using IPM.Application.UseCases.Position.CreatePositionUseCase;
using IPM.Application.UseCases.Position.DeletePositionUseCase;
using IPM.Application.UseCases.Position.GetAllPositionUseCase;
using IPM.Application.UseCases.Position.UpdatePositionUseCase;

using IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;
using IPM.Application.UseCases.Sponsor.DeleteSponsorUseCase;
using IPM.Application.UseCases.Sponsor.GetAllSponsorUseCase;
using IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;

using IPM.Application.UseCases.Project.CreateProjectUseCase;
using IPM.Application.UseCases.Project.DeleteProjectUseCase;
using IPM.Application.UseCases.Project.GetAllProjectUseCase;
using IPM.Application.UseCases.Project.UpdateProjectUseCase;
using IPM.Application.UseCases.Project.AssignUserToProjectUseCase;
using IPM.Application.UseCases.Project.RemoveUserInProjectUseCase;


using IPM.Application.UseCases.FileType.CreateFileTypeUseCase;
using IPM.Application.UseCases.FileType.DeleteFileTypeUseCase;
using IPM.Application.UseCases.FileType.GetAllFileTypeUseCase;
using IPM.Application.UseCases.FileType.UpdateFileTypeUseCase;

using IPM.Application.UseCases.File.UploadFileUseCase;
using IPM.Application.UseCases.File.GetFileInProject;
using IPM.Application.UseCases.File.DeleteFileUseCase;

using IPM.Application.UseCases.Role;

using IPM.Application.UseCases.User.GetAllUserUseCase;
using IPM.Application.UseCases.User.GetCurrentUserUseCase;
using IPM.Application.UseCases.User.UploadAvatarUseCase;
using IPM.Application.UseCases.User.UpdateUserInfoUseCase;

using IPM.Application.UseCases.Project.GetProjectUseCase;

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

        services.AddScoped<ICreateCurrencyUnitUseCase, CreateCurrencyUnitHandler>();
        services.AddScoped<IGetAllCurrencyUnitUseCase, GetAllCurrencyUnitHandler>();
        services.AddScoped<IUpdateCurrencyUnitUseCase, UpdateCurrencyUnitHandler>();
        services.AddScoped<IDeleteCurrencyUnitUseCase, DeleteCurrencyUnitHandler>();

        services.AddScoped<ICreateAidTypeUseCase, CreateAidTypeHandler>();
        services.AddScoped<IDeleteAidTypeUseCase, DeleteAidTypeHandler>();
        services.AddScoped<IUpdateAidTypeUseCase, UpdateAidTypeHandler>();
        services.AddScoped<IGetAllAidTypeUseCase, GetAllAidTypeHandler>();

        services.AddScoped<ICreateCategoryUseCase, CreateCategoryHandler>();
        services.AddScoped<IGetAllCategoryUseCase, GetAllCategoryHandler>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryHandler>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryHandler>();

        services.AddScoped<ICreateCounterpartyUseCase, CreateCounterpartyHandler>();
        services.AddScoped<IGetAllCounterpartyUseCase, GetAllCounterpartyHandler>();
        services.AddScoped<IDeleteCounterpartyUseCase, DeleteCounterpartyHandler>();
        services.AddScoped<IUpdateCounterpartyUseCase, UpdateCounterpartyHandler>();

        services.AddScoped<ICreatePositionUseCase, CreatePositionHandler>();
        services.AddScoped<IGetAllPositionUseCase, GetAllPositionHandler>();
        services.AddScoped<IDeletePositionUseCase, DeletePositionHandler>();
        services.AddScoped<IUpdatePositionUseCase, UpdatePositionHandler>();

        services.AddScoped<ICreateSponsorUseCase, CreateSponsorHandler>();
        services.AddScoped<IGetAllSponsorUseCase, GetAllSponsorHandler>();
        services.AddScoped<IDeleteSponsorUseCase, DeleteSponsorHandler>();
        services.AddScoped<IUpdateSponsorUseCase, UpdateSponsorHandler>();

        services.AddScoped<ICreateProjectUseCase, CreateProjectHandler>();
        services.AddScoped<IGetAllProjectUseCase, GetAllProjectHandler>();
        services.AddScoped<IGetProjectUseCase, GetProjectHandler>();
        services.AddScoped<IDeleteProjectUseCase, DeleteProjectHandler>();
        services.AddScoped<IUpdateProjectUseCase, UpdateProjectHandler>();
        services.AddScoped<IAssignUserToProjectUseCase, AssignUserToProjectHandler>();
        services.AddScoped<IRemoveUserInProjectUseCase, RemoveUserInProjectHandler>();

        services.AddScoped<ICreateFileTypeUseCase, CreateFileTypeHandler>();
        services.AddScoped<IGetAllFileTypeUseCase, GetAllFileTypeHandler>();
        services.AddScoped<IDeleteFileTypeUseCase, DeleteFileTypeHandler>();
        services.AddScoped<IUpdateFileTypeUseCase, UpdateFileTypeHandler>();

        services.AddScoped<IUploadFileUseCase, UploadFileHandler>();
        services.AddScoped<IGetFileInProject, GetFileInProjectHandler>();
        services.AddScoped<IDeleteFileUseCase, DeleteFileHandler>();

        services.AddScoped<IGetAllUserUseCase, GetAllUserHandler>();
        services.AddScoped<IGetCurrentUserUseCase, GetCurrentUserHandler>();
        services.AddScoped<IUploadAvatarUseCase, UploadAvatarHandler>();
        services.AddScoped<IUpdateUserInfoUseCase, UpdateUserInfoHandler>();
        return services;
    }

}
