import type { KyInstance } from "ky";


export  default async function getAll<T>(endpont: KyInstance): Promise<T[]> {
  try {
    let data: T[] = await endpont.get("", {
      credentials: "include",
    }).json();
    console.log(data);
    return data;
  } catch(e: any) {
    return [];
  }
}
