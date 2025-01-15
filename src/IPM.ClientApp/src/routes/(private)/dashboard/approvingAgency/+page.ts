import getAllApprovingAgency from "@useCases/approvingAgencyUseCase/getAllApprovingAgency";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("approvingAgency:getAll")
  return {
    approvingAgency: getAllApprovingAgency(),
  }
}
