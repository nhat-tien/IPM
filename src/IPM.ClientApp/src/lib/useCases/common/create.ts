import type { UseCaseResult } from "@useCases/useCases.types";
import { HTTPError, type KyInstance } from "ky";
import type { ZodError, ZodObject } from "zod";


export default async function create<T>({
  scheme,
  endpoint,
  formData
}: {
  scheme: ZodObject<any>;
  endpoint: KyInstance;
  formData: T
}): Promise<UseCaseResult> {
  try {
    scheme.parse(formData);

    await endpoint.post("", {
      json: formData,
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
