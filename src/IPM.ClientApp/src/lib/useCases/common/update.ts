import type { UseCaseResult } from "@useCases/useCases.types";
import { HTTPError, type KyInstance } from "ky";
import type { ZodError, ZodObject } from "zod";


export default async function update<T>({
  scheme,
  endpoint,
  formData,
  id
}: {
  scheme: ZodObject<any>;
  endpoint: KyInstance;
  formData: T,
  id: string,
}): Promise<UseCaseResult> {
  try {
    scheme.parse(formData);

    await endpoint.patch(id, {
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
