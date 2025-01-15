import { approvingAgencyEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const CreateApprovingAgencyScheme = z.object({
  approvingAgencyName: z.string().nonempty({ message: "Tên cơ quan phê duyệt không để trống"})
});

type CreateApprovingAgencyRequest = z.infer<typeof CreateApprovingAgencyScheme>;


export default async function createApprovingAgency(formData: FormData): Promise<UseCaseResult> {

  const data: CreateApprovingAgencyRequest = {
    approvingAgencyName: formData.get("approvingAgencyName") as string,
  }

  return await create<CreateApprovingAgencyRequest>({
    scheme: CreateApprovingAgencyScheme,
    endpoint: approvingAgencyEndPoint,
    formData: data,
  })
}
