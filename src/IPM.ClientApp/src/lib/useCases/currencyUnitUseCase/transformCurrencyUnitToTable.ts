import transformToTable from "@useCases/common/transformToTable";
import type {  CurrencyUnit } from "@useCases/useCases.types";


export default function transformCurrencyUnitToTable(currencyUnit: CurrencyUnit[]): any[][] {

  return transformToTable<CurrencyUnit>(currencyUnit, (model) =>
    [
      model.currencyUnitId,
      model.currencyUnitName
    ]);
}
