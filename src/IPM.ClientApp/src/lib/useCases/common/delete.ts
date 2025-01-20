import type { UseCaseResult } from "@useCases/useCases.types";
import { HTTPError, type KyInstance } from "ky";


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
