import transformToOption from "@useCases/common/transformToOption";
import type { AffiliatedUnit, OptionType } from "@useCases/useCases.types";


export default function transformAffiliatedUnitToOption(affiliatedUnits: AffiliatedUnit[]): OptionType[] {

  return transformToOption<AffiliatedUnit>(affiliatedUnits, (affiliatedUnit) =>
    [
      affiliatedUnit.affiliatedUnitId,
      affiliatedUnit.affiliatedUnitName
    ]);
}


