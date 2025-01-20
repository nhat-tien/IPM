import { affiliatedUnitEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateAffiliatedUnitScheme = z.object({
  affiliatedUnitName: z.string().nonempty({ message: "Tên đơn vị trực thuộc không để trống"})
});

type UpdateAffiliatedUnitRequest = z.infer<typeof UpdateAffiliatedUnitScheme>;

export default async function updateAffiliatedUnit(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateAffiliatedUnitRequest = {
    affiliatedUnitName: formData.get("affiliatedUnitName") as string,
  }

  return await update<UpdateAffiliatedUnitRequest>({
    scheme: UpdateAffiliatedUnitScheme,
    endpoint: affiliatedUnitEndPoint,
    formData: data,
    id: id + ""
  })

}
