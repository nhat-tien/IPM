import { HTTPError } from "ky";
import { projectEndPoint } from "@services/httpService";
import { z } from "zod";
import type { UseCaseResult } from "@useCases/useCases.types";

const AssignMemberScheme = z.object({
  assignments: z.array(z.object({
    userId: z.string().nonempty(),
    projectId: z.number().gt(0),
    owner: z.boolean()
  }))
});

type AssignMemberRequest = z.infer<typeof AssignMemberScheme>;

export default async function assignMember(req: AssignMemberRequest): Promise<UseCaseResult> {
  try {
    AssignMemberScheme.parse(req);

    await projectEndPoint.post("assignment", {
      json: req,
      credentials: "include",
    }).json();

    return {
      isSuccess: true,
      error: null,
    }

  } catch (e: any) {
    if (e instanceof HTTPError && e.response.status == 401) {
      return {
        isSuccess: false,
        error: "Unauthorized",
      }
    }
    return {
      isSuccess: false,
      error: e,
    }
  }
}
