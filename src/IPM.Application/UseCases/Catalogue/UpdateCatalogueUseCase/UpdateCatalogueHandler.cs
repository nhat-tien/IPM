using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Catalogue.UpdateCatalogueUseCase;

public class UpdateCatalogueHandler(ICatalogueRepository repo) : IUpdateCatalogueUseCase
{
    public async Task Handle(int id, UpdateCatalogueRequest req)
    {
        Domain.Catalogue entity = new Domain.Catalogue() {
            CatalogueId = id,
            CatalogueName = req.CatalogueName
        };
        await repo.Update(entity);
    }
}
