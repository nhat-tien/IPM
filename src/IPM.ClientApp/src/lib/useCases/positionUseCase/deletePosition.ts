import { positionEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deletePosition(id: number) {
  return await deleteApi(positionEndPoint, id.toString());
}
