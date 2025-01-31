import getAllAidType from "@useCases/aidTypeUseCase/getAllAidType";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("aidType:getAll")
  return {
    aidType: getAllAidType(),
  }
}
