import type { LayoutLoad } from "./$types";
import guardHook from "@services/guardService";

export const load: LayoutLoad = async ({ url }) => {
    await guardHook({ url: url });
}
