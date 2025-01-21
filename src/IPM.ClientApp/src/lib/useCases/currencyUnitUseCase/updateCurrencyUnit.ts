import { currencyUnitEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateCurrencyUnitScheme = z.object({
  currencyUnitName: z.string().nonempty({ message: "Tên đơn vị tiền tệ không để trống"})
});

type UpdateCurrencyUnitRequest = z.infer<typeof UpdateCurrencyUnitScheme>;

export default async function updateCurrencyUnit(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateCurrencyUnitRequest = {
    currencyUnitName: formData.get("currencyUnitName") as string,
  }

  return await update<UpdateCurrencyUnitRequest>({
    scheme: UpdateCurrencyUnitScheme,
    endpoint: currencyUnitEndPoint,
    formData: data,
    id: id + ""
  })

}
