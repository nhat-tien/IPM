import { sponsorEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteSponsor(id: number) {
  return await deleteApi(sponsorEndPoint, id.toString());
}
