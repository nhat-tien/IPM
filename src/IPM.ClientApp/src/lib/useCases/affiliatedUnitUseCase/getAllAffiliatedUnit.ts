import { affiliatedUnitEndPoint } from "@services/httpService";
import type { AffiliatedUnit } from "../useCases.types";
import getAll from "@useCases/common/getAll";

export default async function getAllAffiliatedUnit() {
  return await getAll<AffiliatedUnit>(affiliatedUnitEndPoint);
}
