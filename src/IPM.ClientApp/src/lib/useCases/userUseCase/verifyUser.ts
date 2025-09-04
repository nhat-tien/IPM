import { userEndPoint } from "@services/httpService";


export default async function verifyUser(userId: string) {
  try {

    await userEndPoint.patch(`${userId}/verified`, {
      json: {},
      credentials: "include"
    });

    return {
      isSuccess: true,
      error: null,
    }

  } catch (e: any) {
    return {
      isSuccess: false,
      error: e,
    }
  }
}
