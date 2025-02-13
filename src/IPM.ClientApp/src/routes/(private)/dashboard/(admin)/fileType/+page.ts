import getAllFileType from "@useCases/fileTypeUseCase/getAllFileType";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("fileType:getAll")
  return {
    fileType: getAllFileType(),
  }
}

