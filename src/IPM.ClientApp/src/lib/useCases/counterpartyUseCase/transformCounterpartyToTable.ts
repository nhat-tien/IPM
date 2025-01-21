import transformToTable from "@useCases/common/transformToTable";
import type {  Counterparty } from "@useCases/useCases.types";

export default function transformCounterpartyToTable(counterparty: Counterparty[]): any[][] {

  return transformToTable<Counterparty>(counterparty, (model) =>
    [
      model.counterpartyId,
      model.counterpartyName
    ]);
}
