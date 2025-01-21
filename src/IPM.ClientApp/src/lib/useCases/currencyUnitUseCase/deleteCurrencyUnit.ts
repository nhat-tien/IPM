import { currencyUnitEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteCurrencyUnit(id: number) {
  return await deleteApi(currencyUnitEndPoint, id.toString());
}
