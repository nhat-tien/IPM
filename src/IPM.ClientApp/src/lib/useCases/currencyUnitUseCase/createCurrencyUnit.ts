import { currencyUnitEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const CreateCurrencyUnitScheme = z.object({
  currencyUnitName: z.string().nonempty({ message: "Tên đơn vị tiền tệ không để trống"})
});

type CreateCurrencyUnitRequest = z.infer<typeof CreateCurrencyUnitScheme>;


export default async function createCurrencyUnit(formData: FormData): Promise<UseCaseResult> {

  const data: CreateCurrencyUnitRequest = {
    currencyUnitName: formData.get("currencyUnitName") as string,
  }

  return await create<CreateCurrencyUnitRequest>({
    scheme: CreateCurrencyUnitScheme,
    endpoint: currencyUnitEndPoint,
    formData: data,
  })
}

