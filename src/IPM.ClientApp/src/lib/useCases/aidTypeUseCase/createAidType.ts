import { aidTypeEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const CreateAidTypeScheme = z.object({
  aidTypeName: z.string().nonempty({ message: "Tên loại viện trợ không để trống"})
});

type CreateAidTypeRequest = z.infer<typeof CreateAidTypeScheme>;


export default async function createAidType(formData: FormData): Promise<UseCaseResult> {

  const data: CreateAidTypeRequest = {
    aidTypeName: (formData.get("aidTypeName") as string).trim(),
  }

  return await create<CreateAidTypeRequest>({
    scheme: CreateAidTypeScheme,
    endpoint: aidTypeEndPoint,
    formData: data,
  })
}
