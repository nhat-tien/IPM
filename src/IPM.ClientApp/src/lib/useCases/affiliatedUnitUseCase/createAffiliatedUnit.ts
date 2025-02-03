import { affiliatedUnitEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const CreateAffiliatedUnitScheme = z.object({
  affiliatedUnitName: z.string().nonempty({ message: "Tên đơn vị trực thuộc không để trống"})
});

type CreateAffiliatedUnitRequest = z.infer<typeof CreateAffiliatedUnitScheme>;


export default async function createAffiliatedUnit(formData: FormData): Promise<UseCaseResult> {

  const data: CreateAffiliatedUnitRequest = {
    affiliatedUnitName: (formData.get("affiliatedUnitName") as string).trim(),
  }

  return await create<CreateAffiliatedUnitRequest>({
    scheme: CreateAffiliatedUnitScheme,
    endpoint: affiliatedUnitEndPoint,
    formData: data,
  })
}


