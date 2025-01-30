using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;

public class UpdateSponsorHandler(ISponsorRepository repo) : IUpdateSponsorUseCase
{

    public async Task Handle(int id, UpdateSponsorRequest req)
    {
        Domain.Sponsor entity = new Domain.Sponsor()
        {
            SponsorId = id,
            SponsorName = req.SponsorName
        };
        await repo.UpdateAsync(entity);
    }
}
