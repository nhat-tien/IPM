import { sponsorEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const modelName = "Chức vụ";

const CreateSponsorScheme = z.object({
  sponsorName: z.string().nonempty({ message: `Tên ${modelName} không được để trống`})
});

type CreateSponsorRequest = z.infer<typeof CreateSponsorScheme>;

export default async function createSponsor(formData: FormData): Promise<UseCaseResult> {

  const data: CreateSponsorRequest = {
    sponsorName: (formData.get("sponsorName") as string).trim(),
  }

  return await create<CreateSponsorRequest>({
    scheme: CreateSponsorScheme,
    endpoint: sponsorEndPoint,
    formData: data,
  })
}

