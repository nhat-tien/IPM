import getAllAffilatedUnit from "$lib/useCases/affiliatedUnitUseCase/getAllAffiliatedUnit";
import type { PageLoad } from "./$types";

export const load: PageLoad = async () => {
  return {
    affiliatedUnit: getAllAffilatedUnit(),
  }
}
