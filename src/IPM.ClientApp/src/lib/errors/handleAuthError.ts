import type { HTTPError } from "ky";
import toast from "svelte-5-french-toast";

enum AuthErrorEnum {
  DuplicateUserName = "DuplicateUserName"
};

export default async function handleAuthError(error: HTTPError) {
  const errorBody: any = await error.response.json();

  switch(errorBody.errors) {
    case AuthErrorEnum.DuplicateUserName:
      toast.error("Thao tác thất bại\nEmail đã được sử dụng");
    break;
    default:
      toast.error("Thao tác thất bại");
      break;
  }
}
