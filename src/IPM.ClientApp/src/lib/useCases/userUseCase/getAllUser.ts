import { userEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type { User } from "@useCases/useCases.types";

export default async function getAllUser(option?: { isVerified: boolean}): Promise<User[]> {

  let isVerified = true;

  if (option?.isVerified === false) {
    isVerified = false;
  }

  return await getAll<User>(userEndPoint, `?include=Role&filter=IsVerified[=]${isVerified}`);
}


