import { categoryEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const modelName = "Danh mục";

const CreateCategoryScheme = z.object({
  categoryName: z.string().nonempty({ message: `Tên ${modelName} không được để trống`})
});

type CreateCategoryRequest = z.infer<typeof CreateCategoryScheme>;

export default async function createCategory(formData: FormData): Promise<UseCaseResult> {

  const data: CreateCategoryRequest = {
    categoryName: formData.get("categoryName") as string,
  }

  return await create<CreateCategoryRequest>({
    scheme: CreateCategoryScheme,
    endpoint: categoryEndPoint,
    formData: data,
  })
}
