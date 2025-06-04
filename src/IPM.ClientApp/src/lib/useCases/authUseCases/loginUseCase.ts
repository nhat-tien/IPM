import { authEndPoint } from "@services/httpService";
import { saveAccessToken } from "@services/accessTokenService";
import { decodeUserInfoFromJWT } from "@services/userInfoService";
import { setUserInfo } from "@stores/userInfo.svelte";
import type { HttpError } from "@sveltejs/kit";
import { HTTPError } from "ky";
import { z, ZodError } from "zod";

const LoginScheme = z.object({
  email: z.string().email({ message: "Định dạng email chưa đúng" }),
  password: z.string()
});

type LoginParam = z.infer<typeof LoginScheme>;
type LoginResult = {
  isSuccess: boolean,
  error: ZodError | string | null
};

export default async function login(formData: LoginParam): Promise<LoginResult> {
  try {
    let result = LoginScheme.parse(formData);
    const response: any = await authEndPoint.post("login", {
      json: {
        email: result.email,
        password: result.password
      },
      credentials: "include",
    }).json();
    // setUserInfo(decodeUserInfoFromJWT(response.accessToken));
    // saveAccessToken(response.accessToken);
    return {
      isSuccess: true,
      error: null,
    }
  } catch (e: ZodError | HttpError | any) {
    if(e instanceof HTTPError) {
      if(e.response.status == 401) {
        return {
          isSuccess: false,
          error: "Unauthorized",
        }
      }
    }
    return {
      isSuccess: false,
      error: e,
    }
  }
}
