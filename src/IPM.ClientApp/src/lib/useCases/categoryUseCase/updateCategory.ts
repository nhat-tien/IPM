import { categoryEndPoint } from "@services/httpService";
import update from "@useCases/common/update";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const UpdateCategoryScheme = z.object({
  categoryName: z.string().nonempty({ message: "Tên danh mục không để trống"})
});

type UpdateCategoryRequest = z.infer<typeof UpdateCategoryScheme>;

export default async function updateCategory(formData: FormData, id: number): Promise<UseCaseResult> {
  const data: UpdateCategoryRequest = {
    categoryName: (formData.get("categoryName") as string).trim(),
  }

  return await update<UpdateCategoryRequest>({
    scheme: UpdateCategoryScheme,
    endpoint: categoryEndPoint,
    formData: data,
    id: id + ""
  })

}
