import { getAccessToken } from "@services/accessTokenService";
import { decodeUserInfoFromJWT } from "@services/userInfoService";

type UserInfo = {
  email: string;
  firstName: string; 
  lastName: string; 
  role: string;
  sub: string;
} | null

let userInfo: UserInfo = $state(null);

function setUserInfo(newUserInfo: UserInfo) {
  userInfo = newUserInfo;
}

function getUserInfo(): UserInfo {
  if(userInfo == null) {
    let accessToken = getAccessToken() ;
    if(accessToken != null) {
      setUserInfo(decodeUserInfoFromJWT(accessToken));
    }
  }
  return userInfo;
}

function deleteUserInfo() {
  userInfo = null
}

function getFullName(): string {
  return userInfo?.lastName + " " + userInfo?.firstName;
}

export { setUserInfo, getUserInfo, deleteUserInfo, getFullName, type UserInfo}
