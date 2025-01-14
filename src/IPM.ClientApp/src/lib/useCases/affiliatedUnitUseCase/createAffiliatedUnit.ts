import { affiliatedEndPoint } from "@services/httpService";
import type { UseCaseResult } from "@useCases/useCases.types";
import { HTTPError } from "ky";
import { z, ZodError } from "zod";

const CreateAffiliatedUnitScheme = z.object({
  affiliatedUnitName: z.string().nonempty({ message: "Tên đơn vị trực thuộc không để trống"})
});
type CreateAffiliatedUnitParam = z.infer<typeof CreateAffiliatedUnitScheme>;

export default async function createAffiliatedUnit(formData: CreateAffiliatedUnitParam): Promise<UseCaseResult> {
  try {
    let result = CreateAffiliatedUnitScheme.parse(formData);
    await affiliatedEndPoint.post("", {
      json: {
        affiliatedUnitName: result.affiliatedUnitName
      },
      credentials: "include",
    }).json();
    return {
      isSuccess: true,
      error: null,
    }
  } catch (e: ZodError | HTTPError | any) {
    if(e instanceof HTTPError) {
      if(e.response.status == 401) {
        return {
          isSuccess: false,
          error: "Unauthorized",
        }
      }
    }
    return {
      isSuccess: false,
      error: e,
    }
  }
}
