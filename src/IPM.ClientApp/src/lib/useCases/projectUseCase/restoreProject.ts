import { projectEndPoint } from "@services/httpService";
import { HTTPError } from "ky";
import type { ZodError } from "zod";
import type { UpdateProjectRequest } from "./updateProject";

type Params = {
  id: string,
}

export default async function restoreProject({ id }: Params) {
try {
    const request: UpdateProjectRequest = {
      isDeleted: false,
      setValueProperties: [ "IsDelete" ]
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


