import { AppLog } from "@/lib/utils/log";
import type { KyInstance } from "ky";

export  default async function getAll<T>(endpont: KyInstance, query: string = ""): Promise<T[]> {
  try {
    let data: T[] = await endpont.get("" + query, {
      credentials: "include",
    }).json();

    return data;

  } catch(e: any) {

    AppLog.error("Error when fetch API GET");

    return [];
  }
}
