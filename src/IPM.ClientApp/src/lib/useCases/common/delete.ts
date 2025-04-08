import type { UseCaseResult } from "@useCases/useCases.types";
import { HTTPError, type KyInstance } from "ky";
import handleServerError from "./handleServerError";


export default async function deleteApi(endpoint: KyInstance, id: string): Promise<UseCaseResult> {
  try {
    await endpoint.delete(id, {
      credentials: "include",
    }).json();

    return {
      isSuccess: true,
      error: null,
    }
  } catch (e: HTTPError | any) {
    if (e instanceof HTTPError) {
      return handleServerError(e);
    }
    return {
      isSuccess: false,
      error: e,
    }
  }
}
