using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Catalogue.GetAllCatalogueUseCase;

public class GetAllCatalogueHandler(ICatalogueRepository repo) : IGetAllCatalogueUseCase
{
    public async Task<IEnumerable<Domain.Catalogue>> Handle()
    {
        return await repo.GetAll();
    }
}
