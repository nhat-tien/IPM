import getAllCurrencyUnit from "@useCases/currencyUnitUseCase/getAllCurrencyUnit";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("currencyUnit:getAll")
  return {
    currencyUnit: getAllCurrencyUnit(),
  }
}

