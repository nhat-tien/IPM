import { affiliatedUnitEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteAffiliatedUnit(id: string) {
  return await deleteApi(affiliatedUnitEndPoint, id);
}
