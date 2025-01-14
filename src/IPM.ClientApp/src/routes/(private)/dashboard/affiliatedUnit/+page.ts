import getAllAffilatedUnit from "$lib/useCases/affiliatedUnitUseCase/getAllAffiliatedUnit";
import transformAffliatedUnitToTable from "$lib/useCases/affiliatedUnitUseCase/transformAffliatedUnitToTable";
import type { PageLoad } from "./$types";

export const load: PageLoad = async () => {
  let data = await getAllAffilatedUnit();
  return {
    affiliatedUnit: transformAffliatedUnitToTable(data),
  }
}
