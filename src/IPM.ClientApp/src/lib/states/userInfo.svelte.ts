import { getUserInfo, type UserInfo } from "@stores/userInfo.svelte";

function delay(ms: number) {
  return new Promise<void>(resolve => {
    setTimeout(() => {
      resolve(); // Resolve the promise after 'ms' milliseconds
    }, ms);
  });
}

export default function useUserInfo()  {
  let userInfo  = $state<UserInfo | null>(null);

  $effect(() => {
    const fetchInfo = async () => {
      const info = await getUserInfo();
      userInfo = info;
    }
    fetchInfo();
  })

  return {
    get info() {
      return userInfo;
    }
  };
}
