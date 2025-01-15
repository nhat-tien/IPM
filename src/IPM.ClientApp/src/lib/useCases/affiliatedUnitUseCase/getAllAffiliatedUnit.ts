import { affiliatedUnitEndPoint } from "@services/httpService";
import type { AffiliatedUnit } from "../useCases.types";
import getAll from "@useCases/common/getAll";

export default async function getAllAffilatedUnit() {
  return await getAll<AffiliatedUnit>(affiliatedUnitEndPoint);
}
