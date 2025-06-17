import { projectEndPoint } from "@services/httpService";
import { HTTPError } from "ky";
import type { ZodError } from "zod";
import type { UpdateProjectRequest } from "./updateProject";

type Params = {
  id: string,
  isReport: boolean
}

export default async function reportProject({ id, isReport}: Params) {
try {
    const request: UpdateProjectRequest = {
      isReported: isReport,
      setValueProperties: []
    }

    await projectEndPoint.patch(id, {
      json: request,
      credentials: "include",
    }).json();

    return {
      isSuccess: true,
      error: null,
    }

  } catch (e: ZodError | HTTPError | any) {
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

