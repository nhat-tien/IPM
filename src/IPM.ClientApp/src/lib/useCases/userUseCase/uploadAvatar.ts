import { userEndPoint } from "@services/httpService";
import { getUserInfo } from "@stores/userInfo.svelte";
import type { UseCaseResult } from "@useCases/useCases.types";


export default async function uploadAvatar({ avatar }: { avatar: File }): Promise<UseCaseResult> {
  try {
  const info = await getUserInfo();

  const formData = new FormData();
  formData.append("image", avatar);

  await userEndPoint.post(`${info?.sub}/avatar`, {
    body: formData,
    credentials: "include",
  });

    return {
      isSuccess: true,
      error: null
    }

  } catch(e: any) {
    return {
      isSuccess: false,
      error: e
    }
  }
}
