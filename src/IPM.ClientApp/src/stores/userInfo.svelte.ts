type UserInfo = {
  userName: string,
  role: string
}
export default function userInfoStore(): UserInfo {

  let userName: string = $state("");
  let role: string = $state("");

  return {
    userName,
    role
  }
}
