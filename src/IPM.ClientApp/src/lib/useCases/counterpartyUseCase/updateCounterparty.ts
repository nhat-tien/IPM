import { counterpartyEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateCounterpartyScheme = z.object({
  counterpartyName: z.string().nonempty({ message: "Tên đối tác không để trống"})
});

type UpdateCounterpartyRequest = z.infer<typeof UpdateCounterpartyScheme>;

export default async function updateCounterparty(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateCounterpartyRequest = {
    counterpartyName: (formData.get("counterpartyName") as string).trim(),
  }

  return await update<UpdateCounterpartyRequest>({
    scheme: UpdateCounterpartyScheme,
    endpoint: counterpartyEndPoint,
    formData: data,
    id: id + ""
  })

}
