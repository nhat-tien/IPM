import { getAccessToken } from "@services/jwtService";
import { goto } from "$app/navigation";
import type { LayoutLoad } from "./$types";

export const load: LayoutLoad = async () => {
  const accessToken = getAccessToken();
  if(accessToken != null) {
    goto("/dashboard");
  }
}
