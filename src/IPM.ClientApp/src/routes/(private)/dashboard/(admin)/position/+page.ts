import getAllPosition from "@useCases/positionUseCase/getAllPosition";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("position:getAll");
  return {
    position: getAllPosition(),
  }
}

