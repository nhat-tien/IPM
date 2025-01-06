export type UserInfo = {
  email: string;
  firstName: string; 
  lastName: string; 
  role: string;
} | null

let userInfo: UserInfo = $state(null);

export function setUserInfo(newUserInfo: UserInfo) {
  userInfo = newUserInfo;
}

export function getUserInfo(): UserInfo {
  return userInfo;
}
