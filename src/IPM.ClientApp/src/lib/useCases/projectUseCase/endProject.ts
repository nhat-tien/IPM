import { projectEndPoint } from "@services/httpService";
import { dateToString } from "@utils/datetime";
import { HTTPError } from "ky";
import type { ZodError } from "zod";
import type { UpdateProjectRequest } from "./updateProject";

type Params = {
  id: string,
}

export default async function endProject({ id }: Params) {
try {
    const request: UpdateProjectRequest = {
      endDate: dateToString(new Date),
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
