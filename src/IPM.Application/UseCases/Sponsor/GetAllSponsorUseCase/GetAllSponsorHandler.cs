using IPM.Application.IRepositories;
namespace IPM.Application.UseCases.Sponsor.GetAllSponsorUseCase;

public class GetAllSponsorHandler(ISponsorRepository repo): IGetAllSponsorUseCase
{
    public async Task<IEnumerable<Domain.Sponsor>> Handle()
    {
        return await repo.GetAll();
    }

}


