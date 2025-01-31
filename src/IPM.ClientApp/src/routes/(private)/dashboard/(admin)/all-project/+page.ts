import getAllProject from "@useCases/projectUseCase/getAllProject";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("project:getAll")
  return {
    project: getAllProject(),
  }
}
