namespace IPM.Application.UseCases.Catalogue.UpdateCatalogueUseCase;

public interface IUpdateCatalogueUseCase
{
    Task Handle(int id, UpdateCatalogueRequest req);
}
