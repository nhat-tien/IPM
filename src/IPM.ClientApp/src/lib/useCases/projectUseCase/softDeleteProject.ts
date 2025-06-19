import { projectEndPoint } from "@services/httpService";
import { HTTPError } from "ky";
import type { ZodError } from "zod";

type Params = {
  id: string,
}

type DeleteProjectRequest = {}

export default async function softDeleteProject({ id }: Params) {
try {
    const request: DeleteProjectRequest = {};

    await projectEndPoint.delete(id, {
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

