import { AppLog } from "@/lib/utils/log";
import type { KyInstance } from "ky";

export default async function get<T>(endpont: KyInstance, id: string | number, query: string = ""): Promise<T | null> {
  try {
    let data: T = await endpont.get(id + query, {
      credentials: "include",
    }
    ).json();

    return data;

  } catch (e: any) {
    AppLog.error("Error when fetch API GET");
    console.log(e)
    return null;
  }
}

