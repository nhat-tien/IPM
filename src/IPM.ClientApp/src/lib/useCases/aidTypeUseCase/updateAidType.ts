import { aidTypeEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateAidTypeScheme = z.object({
  aidTypeName: z.string().nonempty({ message: "Tên loại viện trợ không để trống"})
});

type UpdateAidTypeRequest = z.infer<typeof UpdateAidTypeScheme>;

export default async function updateAidType(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateAidTypeRequest = {
    aidTypeName: (formData.get("aidTypeName") as string).trim(),
  }

  return await update<UpdateAidTypeRequest>({
    scheme: UpdateAidTypeScheme,
    endpoint: aidTypeEndPoint,
    formData: data,
    id: id + ""
  })

}
