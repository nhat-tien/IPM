export type UserInfo = {
  userName: string,
  role: string
} | null

let userInfo: UserInfo = $state(null);

export function setUserInfo(newUserInfo: UserInfo) {
  userInfo = newUserInfo;
}

export function getUserInfo(): UserInfo {
  return userInfo
}
