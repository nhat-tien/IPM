import { projectEndPoint } from "@services/httpService";
import create from "@useCases/common/create";
import type { UseCaseResult } from "@useCases/useCases.types";
import { z } from "zod";

const CreateProjectScheme = z.object({
  projectNameVietnamese: z.string().nonempty({ message: `Tên dự án không được để trống` }),
  projectNameEnglish: z.string(),
  affiliatedUnitId: z.number({message: "Hãy chọn đơn vị trực thuộc"}).gt(0)
});

type CreateProjectRequest = z.infer<typeof CreateProjectScheme>;

export default async function createProject(formData: {
  projectNameVietnamese: string
  projectNameEnglish: string
  affiliatedUnitId: string
}): Promise<UseCaseResult> {

  const data: CreateProjectRequest = {
    projectNameVietnamese: formData.projectNameVietnamese.trim(),
    projectNameEnglish: formData.projectNameEnglish.trim(),
    affiliatedUnitId: parseInt(formData.affiliatedUnitId),
  }

  return await create<CreateProjectRequest>({
    scheme: CreateProjectScheme,
    endpoint: projectEndPoint,
    formData: data,
  })
}

