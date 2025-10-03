import getUserInfoFromApi from "@useCases/userUseCase/getUserInfoFromApi";
import { AppLog } from "@utils/log";

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

async function getUserInfo(): Promise<UserInfo> {
  if(userInfo == null) {
    AppLog.cache("miss cache info user")
    const user = await getUserInfoFromApi();
    if(user != null) {
      setUserInfo(user);
      AppLog.info("update info user successfully")
    } else {
      AppLog.info("update info user fail")
    }
  } else {
      AppLog.cache("hit cache info user")
  }
  return userInfo;
}

function deleteUserInfo() {
  userInfo = null
  AppLog.info("remove session")
}

function getFullName(): string {
  return userInfo?.lastName + " " + userInfo?.firstName;
}

export { setUserInfo, getUserInfo, deleteUserInfo, getFullName, type UserInfo}
