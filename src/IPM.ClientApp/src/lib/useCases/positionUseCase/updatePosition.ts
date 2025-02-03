import { positionEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdatePositionScheme = z.object({
  positionName: z.string().nonempty({ message: "Tên chức vụ không để trống"})
});

type UpdatePositionRequest = z.infer<typeof UpdatePositionScheme>;

export default async function updatePosition(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdatePositionRequest = {
    positionName: (formData.get("positionName") as string).trim(),
  }

  return await update<UpdatePositionRequest>({
    scheme: UpdatePositionScheme,
    endpoint: positionEndPoint,
    formData: data,
    id: id + ""
  })

}
