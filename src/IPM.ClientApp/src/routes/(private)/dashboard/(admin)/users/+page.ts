import getAllUser from "@useCases/userUseCase/getAllUser";
import type { PageLoad } from "./$types";
import { cacheFetch } from "@stores/cache.svelte";
import type { User } from "@useCases/useCases.types";

export const load: PageLoad = async ({ depends }) => {

  depends("users:getAll");

  return {
    users: cacheFetch<User[]>("users", 300, getAllUser),
    usersInactive: cacheFetch<User[]>("users:inactive", 300, () => getAllUser({ isVerified: false })),
  }
}

