import getAllUser from "@useCases/userUseCase/getAllUser";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ depends }) => {
  depends("users:getAll");
  return {
    users: getAllUser(),
  }
}

