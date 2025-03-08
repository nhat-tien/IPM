import { userEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { User } from "@useCases/useCases.types";

export default async function getAllUser(): Promise<User[]> {
  return await getAll<User>(userEndPoint, "?include=Role");
}


