import { goto } from "$app/navigation";
import { getUserInfo } from "@stores/userInfo.svelte";
import toast from "svelte-5-french-toast";

export async function isCurrentUserHasRole(roles: string[]): Promise<boolean> {
  let currentUser = await getUserInfo();
  for (let role of roles) {
    if (currentUser?.role === role) return true;
  }
  return false;
}

export function routeGuardByRole(roles: string[], fallbackUrl?: string, isNotify: boolean = true) {

  if (!isCurrentUserHasRole(roles)) {

    if(fallbackUrl) {
      goto((fallbackUrl));
    } else {
      goto("/dashboard");
    }

    if(isNotify) {
      toast.error("Bạn không được đủ thẩm quyền")
    }
  }
}

export async function routeGuardByAuth() {
  let currentUser = await getUserInfo();
  if(currentUser == null) {
    goto("/login");
  }
}
