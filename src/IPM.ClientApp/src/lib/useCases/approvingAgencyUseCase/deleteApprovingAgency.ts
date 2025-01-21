import { approvingAgencyEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteApprovingAgency(id: number) {
  return await deleteApi(approvingAgencyEndPoint, id.toString());
}
