using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;

public class CreateSponsorHandler(ISponsorRepository repo): ICreateSponsorUseCase
{
    public async Task Handle(CreateSponsorRequest req)
    {
        Domain.Sponsor entity = new Domain.Sponsor() {
            SponsorName = req.SponsorName
        };
        await repo.Create(entity);
    }
}
