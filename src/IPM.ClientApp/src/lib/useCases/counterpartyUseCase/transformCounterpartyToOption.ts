import transformToOption, { type OptionType } from "@useCases/common/transformToOption";
import type {  Counterparty } from "@useCases/useCases.types";

export default function transformCounterpartyToOption(counterparty: Counterparty[]): OptionType {

  return transformToOption<Counterparty>(counterparty, (model) =>
    [
      model.counterpartyId,
      model.counterpartyName
    ]);
}

