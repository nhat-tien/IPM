import { sponsorEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateSponsorScheme = z.object({
  sponsorName: z.string().nonempty({ message: "Tên nhà tài trợ không để trống"})
});

type UpdateSponsorRequest = z.infer<typeof UpdateSponsorScheme>;

export default async function updateSponsor(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateSponsorRequest = {
    sponsorName: (formData.get("sponsorName") as string).trim(),
  }

  return await update<UpdateSponsorRequest>({
    scheme: UpdateSponsorScheme,
    endpoint: sponsorEndPoint,
    formData: data,
    id: id + ""
  })

}
