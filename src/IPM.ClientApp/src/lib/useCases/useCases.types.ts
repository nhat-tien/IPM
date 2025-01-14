import type { ZodError } from "zod";

export type UseCaseResult = {
  isSuccess: boolean;
  error: ZodError | string | null
}  

export type UseCaseResultWithData<T> = UseCaseResult & {
  data: T
}
