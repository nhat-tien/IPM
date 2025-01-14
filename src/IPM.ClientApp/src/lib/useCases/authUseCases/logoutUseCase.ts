import { goto, invalidateAll } from "$app/navigation";
import { removeAccessToken } from "@services/jwtService";
import { deleteUserInfo } from "@stores/userInfo.svelte";

export default async function logout() {
  removeAccessToken();
  deleteUserInfo();
  await invalidateAll();
  goto("/login");
}
