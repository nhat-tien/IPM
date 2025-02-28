import { HTTPError } from "ky";
import { projectEndPoint } from "@services/httpService";
import { z } from "zod";
import type { UseCaseResult } from "@useCases/useCases.types";
import { AppLog } from "@/lib/utils/log";

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

    if(req.assignments.length == 0) {
      return {
        isSuccess: true,
        error: null,
      };
    }

    await projectEndPoint.post("assignment", {
      json: req,
      credentials: "include",
    }).json();

    return {
      isSuccess: true,
      error: null,
    }

  } catch (e: any) {
    AppLog.error(e);

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
