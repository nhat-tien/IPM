import { authEndPoint } from "@services/httpService";
import type { HttpError } from "@sveltejs/kit";
import { z, ZodError } from "zod";

const RegisterScheme = z.object({
  roleId: z.enum(["1","2","3"], {message: "Xin hãy chọn vai trò"}),
  email: z.string().email({
    message: "Định dạng email chưa đúng",
  }),
  lastName: z.string().min(1, {
    message: "Họ lót không được trống",
  }).max(50, {
    message: "Họ lót không vượt quá 50 kí tự",
  }),
  firstName: z.string().min(1, {
    message: "Tên không được trống",
  }).max(15, {
    message: "Tên không vượt quá 15 kí tự",
  }),
  password: z.string().min(6, {
    message: "password tối thiểu 6 và tối đa 20 kí tự",
  }).max(
    20,
    {message: "password tối thiểu 6 và tối đa 20 kí tự"}
  ),
  confirmPassword: z.string(),
}).refine(({password, confirmPassword}) => password === confirmPassword, {
  message: "Nhập lại mật khẩu chưa chính xác"
});

type RegisterParam = z.infer<typeof RegisterScheme>;
type RegisterResult = {
  isSuccess: boolean,
  error: ZodError | null 
};

export default async function register(formData: RegisterParam): Promise<RegisterResult> {
  try {
    let result = RegisterScheme.parse(formData);
    const response: any = await authEndPoint.post("register", {
      json: {
        lastName: result.lastName,
        firstName: result.firstName,
        email: result.email,
        password: result.password,
        roleId: result.roleId
      },
      credentials: "include",
    }).json();
    if(response.isSuccess) {
      return {
        isSuccess: true,
        error: null,
      }
    }
      return {
        isSuccess: false,
        error: null,
      }
  } catch (e: ZodError | HttpError | any) {
    return {
      isSuccess: false,
      error: e,
    }
  }
}
