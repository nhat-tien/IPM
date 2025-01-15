import type { KyInstance } from "ky";


export  default async function getAll<T>(endpont: KyInstance): Promise<T[]> {
  try {
    let data: T[] = await endpont.get("", {
      credentials: "include",
    }).json();
    return data;
  } catch(e: any) {
    console.error(e);
    return [];
  }
}
