import { userInfoEndPoint } from "@services/httpService";
import type { UserInfo } from "@stores/userInfo.svelte";
import get from "@useCases/common/get";

export default async function getUserInfoFromApi() {
  return await get<UserInfo>(userInfoEndPoint,"info");
}
