import { projectEndPoint } from "@services/httpService";
import get from "@useCases/common/get";
import type { Project } from "@useCases/useCases.types";

export default function getProject(id: string) {
  return get<Project>(projectEndPoint, id, "/?include=Category,AffiliatedUnit,Sponsor,AidType,ApprovingAgency,Counterparty,CurrencyUnit,Participations");
}

