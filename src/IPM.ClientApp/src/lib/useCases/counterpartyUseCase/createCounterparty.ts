import { categoryEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const modelName = "Đối tác";

const CreateCounterpartyScheme = z.object({
  counterpartyName: z.string().nonempty({ message: `Tên ${modelName} không được để trống`})
});

type CreateCounterpartyRequest = z.infer<typeof CreateCounterpartyScheme>;

export default async function createCounterparty(formData: FormData): Promise<UseCaseResult> {

  const data: CreateCounterpartyRequest = {
    counterpartyName: formData.get("counterpartyName") as string,
  }

  return await create<CreateCounterpartyRequest>({
    scheme: CreateCounterpartyScheme,
    endpoint: categoryEndPoint,
    formData: data,
  })
}
