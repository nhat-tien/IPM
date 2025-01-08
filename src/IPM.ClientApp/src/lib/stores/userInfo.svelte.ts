import { getAccessToken } from "@services/jwtService";
import { decodeUserInfoFromJWT } from "@services/userInfoService";

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
  if(userInfo == null) {
    let accessToken = getAccessToken() ;
    if(accessToken != null) {
      setUserInfo(decodeUserInfoFromJWT(accessToken));
    }
  }
  return userInfo;
}
