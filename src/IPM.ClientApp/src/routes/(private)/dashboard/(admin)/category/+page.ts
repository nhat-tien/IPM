import getAllCategory from "@useCases/categoryUseCase/getAllCategory";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("category:getAll");
  return {
    category: getAllCategory(),
  }
}
