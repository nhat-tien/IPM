import { counterpartyEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteCounterparty(id: number) {
  return await deleteApi(counterpartyEndPoint, id.toString());
}
