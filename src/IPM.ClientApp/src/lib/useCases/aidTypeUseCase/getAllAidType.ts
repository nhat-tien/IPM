import { aidTypeEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { AidType } from "@useCases/useCases.types";

export default async function getAllAidType() {
  return await getAll<AidType>(aidTypeEndPoint);
}
