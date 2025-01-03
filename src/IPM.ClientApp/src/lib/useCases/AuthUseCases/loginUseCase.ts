import { authEndPoint } from "@services/httpService";
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

export async function testrefresh() {
  try {
    const res = await authEndPoint.post("refresh-token", {
      json: {},
      credentials: "include"
    }).json();
    console.log(res);
  } catch(e) {
    console.log(e)
  }
}
