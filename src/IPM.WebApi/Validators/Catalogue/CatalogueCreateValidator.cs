using FluentValidation;
using IPM.Application.UseCases.Catalogue.CreateCatalogueUseCase;

namespace IPM.WebApi.Validators.Catalogue;

public class CatalogueCreateValidator : AbstractValidator<CreateCatalogueRequest>
{
    public CatalogueCreateValidator()
    {
        RuleFor(req => req.CatalogueName).NotEmpty();
    }
}
