import { approvingAgencyEndPoint } from "@services/httpService";
import getAll from "@useCases/common/getAll";
import type {  ApprovingAgency } from "@useCases/useCases.types";

export default async function getAllApprovingAgency() {
  return await getAll<ApprovingAgency>(approvingAgencyEndPoint);
}
