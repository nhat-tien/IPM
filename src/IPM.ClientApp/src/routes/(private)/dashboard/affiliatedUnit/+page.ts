import getAllAffilatedUnit from "$lib/useCases/affiliatedUnitUseCase/getAllAffiliatedUnit";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("affiliatedUnit:getAll");
  return {
    affiliatedUnit: getAllAffilatedUnit(),
  }
}
