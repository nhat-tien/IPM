import { approvingAgencyEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateApprovingAgencyScheme = z.object({
  approvingAgencyName: z.string().nonempty({ message: "Tên cơ quan phê duyệt không để trống"})
});

type UpdateApprovingAgencyRequest = z.infer<typeof UpdateApprovingAgencyScheme>;

export default async function updateApprovingAgency(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateApprovingAgencyRequest = {
    approvingAgencyName: (formData.get("approvingAgencyName") as string).trim(),
  }

  return await update<UpdateApprovingAgencyRequest>({
    scheme: UpdateApprovingAgencyScheme,
    endpoint: approvingAgencyEndPoint,
    formData: data,
    id: id + ""
  })

}
