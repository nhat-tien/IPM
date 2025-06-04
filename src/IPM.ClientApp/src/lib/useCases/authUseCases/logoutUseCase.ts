import { goto, invalidateAll } from "$app/navigation";
import { invalidateCacheAll } from "@stores/cache.svelte";
import { deleteUserInfo } from "@stores/userInfo.svelte";
import { AppLog } from "@utils/log";

export default async function logout() {
  deleteUserInfo();
  await invalidateAll();
  invalidateCacheAll();
  goto("/login");
  AppLog.info("user logout")
}
