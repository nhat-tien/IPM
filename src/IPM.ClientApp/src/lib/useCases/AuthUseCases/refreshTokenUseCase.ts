import { authEndPoint } from "@services/httpService";

type RefreshTokenResult = {
  isSuccess: boolean,
  accessToken?: string | null
};

export default async function refreshToken(): Promise<RefreshTokenResult> {
  try {
    const response: any = await authEndPoint.post("/refresh", {
      json: {},
      credentials: "include",
    }).json();

    return {
      isSuccess: true,
      accessToken: response.accessToken
    }
  } catch (e: any) {
    return {
      isSuccess: false,
    }
  }
}
