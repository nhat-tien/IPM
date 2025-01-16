namespace IPM.Application.UseCases.Catalogue.CreateCatalogueUseCase;

public interface ICreateCatalogueUseCase
{
    Task Handle(CreateCatalogueRequest req);
}
