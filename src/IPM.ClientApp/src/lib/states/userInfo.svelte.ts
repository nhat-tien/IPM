import { getUserInfo, type UserInfo } from "@stores/userInfo.svelte";

export default function useUserInfo()  {
  let userInfo  = $state<UserInfo | null>(null);

  $effect(() => {
    const fetchInfo = async () => {
      const info = await getUserInfo();
      userInfo = info;
    }
    fetchInfo();
  })

  return userInfo;
}
