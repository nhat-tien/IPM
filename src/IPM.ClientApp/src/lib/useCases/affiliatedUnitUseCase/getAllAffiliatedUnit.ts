import { affiliatedEndPoint } from "@services/httpService";
import type { AffiliatedUnit } from "./type";

export default async function getAllAffilatedUnit(): Promise<AffiliatedUnit[]> {
  try {
    let data: AffiliatedUnit[] = await affiliatedEndPoint.get("", {
      credentials: "include"
    }).json();
    return data;
  } catch(e: any) {
    console.error(e);
    return [];
  }
}
