import { fileTypeEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateFileTypeScheme = z.object({
  fileTypeName: z.string().nonempty({ message: "Tên loại file không để trống"})
});

type UpdateFileTypeRequest = z.infer<typeof UpdateFileTypeScheme>;

export default async function updateFileType(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateFileTypeRequest = {
    fileTypeName: (formData.get("fileTypeName") as string).trim(),
  }

  return await update<UpdateFileTypeRequest>({
    scheme: UpdateFileTypeScheme,
    endpoint: fileTypeEndPoint,
    formData: data,
    id: id + ""
  })

}

