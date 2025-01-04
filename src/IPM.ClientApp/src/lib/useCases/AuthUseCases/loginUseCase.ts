import { authEndPoint } from "@services/httpService";
import { saveAccessToken } from "@services/jwtService";
import { decodeUserInfoFromJWT } from "@services/userInfoService";
import { setUserInfo } from "@stores/userInfo.svelte";
import { z, ZodError } from "zod";

const LoginScheme = z.object({
  email: z.string().email({ message: "Định dạng email chưa đúng" }),
  password: z.string()
});

type LoginParam = z.infer<typeof LoginScheme>;
type LoginResult = {
  isSuccess: boolean,
  error: ZodError | null
  accessToken?: string | null
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
      accessToken: response.accessToken
    }
  } catch (e: ZodError | any) {
    return {
      isSuccess: false,
      error: e,
    }
  }
}
