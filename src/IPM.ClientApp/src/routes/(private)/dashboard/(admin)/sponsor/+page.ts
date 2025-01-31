import getAllSponsor from "@useCases/sponsorUseCase/getAllSponsor";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("sponsor:getAll");
  return {
    sponsor: getAllSponsor(),
  }
}
