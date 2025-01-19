import { positionEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const modelName = "Chức vụ";

const CreatePositionScheme = z.object({
  positionName: z.string().nonempty({ message: `Tên ${modelName} không được để trống`})
});

type CreatePositionRequest = z.infer<typeof CreatePositionScheme>;

export default async function createPosition(formData: FormData): Promise<UseCaseResult> {

  const data: CreatePositionRequest = {
    positionName: formData.get("positionName") as string,
  }

  return await create<CreatePositionRequest>({
    scheme: CreatePositionScheme,
    endpoint: positionEndPoint,
    formData: data,
  })
}
