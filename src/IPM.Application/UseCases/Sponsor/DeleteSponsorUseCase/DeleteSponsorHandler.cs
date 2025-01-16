using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Sponsor.DeleteSponsorUseCase;

public class DeleteSponsorHandler(ISponsorRepository repo): IDeleteSponsorUseCase
{
    public async Task Handle(int id)
    {
        await repo.Delete(id);
    }
}
