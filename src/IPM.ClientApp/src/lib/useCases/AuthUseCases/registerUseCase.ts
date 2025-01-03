import { authEndPoint } from "@services/httpService";
import { z, ZodError } from "zod";

const RegisterScheme = z.object({
  email: z.string().email({ message: "Định dạng email chưa đúng" }),
  password: z.string()
});

type RegisterParam = z.infer<typeof RegisterScheme>;
type RegisterResult = {
  isSuccess: boolean,
  error: ZodError | null
  accessToken?: string | null
};

export default async function login(formData: RegisterParam): Promise<RegisterResult> {
  try {
    let result = RegisterScheme.parse(formData);
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
