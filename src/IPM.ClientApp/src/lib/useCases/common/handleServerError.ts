import type { ServerError } from "@useCases/useCases.types";
import type { HTTPError } from "ky";

export default async function handleServerError(error: HTTPError) {
  if (error.response.status == 500) {
    const res = await error.response.json();
    return {
      isSuccess: false,
      error: res as ServerError,
    }
  }
  if (error.response.status == 401) {
    return {
      isSuccess: false,
      error: "Unauthorized",
    }
  }
    return {
      isSuccess: false,
      error: "Unidentify",
    }
}
