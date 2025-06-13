import { goto, invalidateAll } from "$app/navigation";
import { authEndPoint } from "@services/httpService";
import { invalidateCacheAll } from "@stores/cache.svelte";
import { deleteUserInfo } from "@stores/userInfo.svelte";
import { AppLog } from "@utils/log";

export default async function logout() {
  authEndPoint.post("refresh/logout",{ json: {}, credentials: "include" });
  deleteUserInfo();
  await invalidateAll();
  invalidateCacheAll();
  goto("/login?no_check_user=true");
  AppLog.info("user logout")
}
