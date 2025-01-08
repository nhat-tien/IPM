import { goto } from "$app/navigation";
import { removeAccessToken } from "@services/jwtService";

export default function logout() {
  removeAccessToken();
  goto("/login");
}
