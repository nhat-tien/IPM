using FluentValidation;
using IPM.Application.UseCases.Catalogue.UpdateCatalogueUseCase;

namespace IPM.WebApi.Validators.Catalogue;

public class CatalogueUpdateValidator : AbstractValidator<UpdateCatalogueRequest>
{
    public CatalogueUpdateValidator()
    {
        RuleFor(req => req.CatalogueName).NotEmpty();
    }
}
