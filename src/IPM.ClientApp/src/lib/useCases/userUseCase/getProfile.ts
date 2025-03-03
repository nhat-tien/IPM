import { profileEndPoint } from "@services/httpService";
import type { User } from "@useCases/useCases.types";
import { AppLog } from "@utils/log";


export default async function getProfile(): Promise<User | null> {
  try {
    let data: User = await profileEndPoint.get("", {
      credentials: "include",
    }).json();

    return data;

  } catch(e: any) {

    AppLog.error("Error when fetch API GET");

    return null;
  }
}
