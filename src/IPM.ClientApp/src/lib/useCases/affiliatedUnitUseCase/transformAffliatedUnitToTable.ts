import type { AffiliatedUnit } from "./type";


export default function transformAffliatedUnitToTable(affiliatedUnits: AffiliatedUnit[]): string[][] {
  let table = [];
  for(let affiliatedUnit of affiliatedUnits) {
    table.push([affiliatedUnit.affiliatedUnitId + "", affiliatedUnit.affiliatedUnitName]);
  }
  return table;
}
