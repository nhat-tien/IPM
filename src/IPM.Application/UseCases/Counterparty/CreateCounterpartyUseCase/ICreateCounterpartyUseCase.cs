namespace IPM.Application.UseCases.Counterparty.CreateCounterpartyUseCase;

public interface ICreateCounterpartyUseCase
{
    Task Handle(CreateCounterpartyRequest req);
}
