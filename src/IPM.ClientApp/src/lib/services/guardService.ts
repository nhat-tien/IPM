import { goto } from "$app/navigation";
import { getUserInfo } from "@stores/userInfo.svelte";
import toast from "svelte-5-french-toast";
import { getAccessToken } from "./accessTokenService";

export function isCurrentUserHasRole(roles: string[]): boolean {
  let currentUser = getUserInfo();
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

export function routeGuardByAuth() {
  const accessToken = getAccessToken();
  if(accessToken == null) {
    goto("/login");
  }
}
