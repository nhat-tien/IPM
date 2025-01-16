namespace IPM.Application.UseCases.Counterparty.DeleteCounterpartyUseCase;

public interface IDeleteCounterpartyUseCase
{
    Task Handle(int id);
}
