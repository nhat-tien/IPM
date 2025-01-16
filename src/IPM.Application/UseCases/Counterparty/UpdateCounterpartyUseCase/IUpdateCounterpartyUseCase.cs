namespace IPM.Application.UseCases.Counterparty.UpdateCounterpartyUseCase;

public interface IUpdateCounterpartyUseCase
{
    Task Handle(int id, UpdateCounterpartyRequest req);
}
