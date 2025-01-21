import { aidTypeEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteAidType(id: number) {
  return await deleteApi(aidTypeEndPoint, id.toString());
}
