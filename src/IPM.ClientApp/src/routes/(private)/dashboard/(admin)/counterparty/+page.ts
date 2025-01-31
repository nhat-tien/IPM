import getAllCounterparty from "@useCases/counterpartyUseCase/getAllCounterparty";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("counterparty:getAll");
  return {
    counterparty: getAllCounterparty(),
  }
}

