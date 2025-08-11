import type { PageLoad } from "./$types";
import getAllAffiliatedUnit from "@useCases/affiliatedUnitUseCase/getAllAffiliatedUnit";

export const load: PageLoad = async ({ depends }) => {
  depends("project:create")
  return {
    affliatedUnit: getAllAffiliatedUnit(),
  }
}

