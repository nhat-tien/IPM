import type { PageLoad } from "./$types";
import getRemovedProject from "@useCases/projectUseCase/getRemovedProject";

export const load: PageLoad = async ({ depends }) => {
  depends("project:getAllRemove")
  return {
    project: getRemovedProject(),
  }
}

