namespace IPM.Application.UseCases.Counterparty.GetAllCounterpartyUseCase;

public interface IGetAllCounterpartyUseCase
{
    Task<IEnumerable<Domain.Counterparty>> Handle();
}
