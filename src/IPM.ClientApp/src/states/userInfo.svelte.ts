type UserInfo = {
  userName: string,
  role: string
}
export default function userInfo() {

  let userName: string = $state("");
  let role: string = $state("");

  return {
    get user() {
      return {userName, role};
    },
    set user(user: UserInfo) {
        userName = user.userName;
        role = user.role;
    }
  }
}
