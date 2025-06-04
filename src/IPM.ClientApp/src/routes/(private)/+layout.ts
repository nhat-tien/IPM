import type { LayoutLoad } from "./$types";
import { routeGuardByAuth } from "@services/guardService";

export const load: LayoutLoad = async () => {
  await routeGuardByAuth();
}
