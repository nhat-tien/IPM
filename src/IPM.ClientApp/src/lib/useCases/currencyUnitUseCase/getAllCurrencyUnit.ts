import { currencyUnitEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {   CurrencyUnit } from "@useCases/useCases.types";

export default async function getAllCurrencyUnit() {
  return await getAll<CurrencyUnit>(currencyUnitEndPoint);
}


