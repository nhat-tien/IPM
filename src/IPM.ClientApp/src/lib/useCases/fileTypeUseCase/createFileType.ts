import { fileTypeEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const CreateFileTypeScheme = z.object({
  fileTypeName: z.string().nonempty({ message: "Tên loại file không để trống"})
});

type CreateFileTypeRequest = z.infer<typeof CreateFileTypeScheme>;


export default async function createFileType(formData: FormData): Promise<UseCaseResult> {

  const data: CreateFileTypeRequest = {
    fileTypeName: (formData.get("fileTypeName") as string).trim(),
  }

  return await create<CreateFileTypeRequest>({
    scheme: CreateFileTypeScheme,
    endpoint: fileTypeEndPoint,
    formData: data,
  })
}

