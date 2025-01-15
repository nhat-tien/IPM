import transformToTable from "@useCases/common/transformToTable";
import type { AffiliatedUnit } from "../useCases.types";


export default function transformAffliatedUnitToTable(affiliatedUnits: AffiliatedUnit[]): string[][] {

  return transformToTable<AffiliatedUnit>(affiliatedUnits, (affiliatedUnit) =>
    [
      affiliatedUnit.affiliatedUnitId + "",
      affiliatedUnit.affiliatedUnitName,
    ]);
}
