namespace IPM.Application.UseCases.Catalogue.DeleteCatalogueUseCase;

public interface IDeleteCatalogueUseCase
{
    Task Handle(int id);
}
