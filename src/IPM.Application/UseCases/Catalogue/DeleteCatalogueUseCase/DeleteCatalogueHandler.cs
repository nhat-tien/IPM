using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Catalogue.DeleteCatalogueUseCase;

public class DeleteCatalogueHandler(ICatalogueRepository repo): IDeleteCatalogueUseCase
{
    public async Task Handle(int id)
    {
        await repo.Delete(id);
    }
}
