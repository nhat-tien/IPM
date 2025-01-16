namespace IPM.Application.UseCases.Catalogue.GetAllCatalogueUseCase;

public interface IGetAllCatalogueUseCase
{
    Task<IEnumerable<Domain.Catalogue>> Handle();
}
