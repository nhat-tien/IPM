using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Catalogue.CreateCatalogueUseCase;

public class CreateCatalogueHandler(ICatalogueRepository repo): ICreateCatalogueUseCase
{
    public async Task Handle(CreateCatalogueRequest req)
    {
        Domain.Catalogue entity = new Domain.Catalogue() {
            CatalogueName = req.CatalogueName
        };
        await repo.Create(entity);
    }
}
