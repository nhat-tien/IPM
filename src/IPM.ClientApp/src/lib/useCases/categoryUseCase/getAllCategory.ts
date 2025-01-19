import { categoryEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { Category } from "@useCases/useCases.types";

export default async function getAllCategory() {
  return await getAll<Category>(categoryEndPoint);
}
