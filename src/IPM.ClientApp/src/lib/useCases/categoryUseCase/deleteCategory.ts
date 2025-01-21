import { categoryEndPoint } from "@services/httpService";
import deleteApi from "@useCases/common/delete";

export default async function deleteCategory(id: number) {
  return await deleteApi(categoryEndPoint, id.toString());
}
