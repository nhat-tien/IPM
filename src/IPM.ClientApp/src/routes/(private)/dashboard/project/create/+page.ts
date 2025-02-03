import getAllCategory from "@useCases/categoryUseCase/getAllCategory";
import type { PageLoad } from "./$types";
import getAllSponsor from "@useCases/sponsorUseCase/getAllSponsor";
import getAllAidType from "@useCases/aidTypeUseCase/getAllAidType";
import getAllApprovingAgency from "@useCases/approvingAgencyUseCase/getAllApprovingAgency";
import getAllCounterparty from "@useCases/counterpartyUseCase/getAllCounterparty";

export const load: PageLoad = async () => {
  return {
    category: getAllCategory(),
    sponsor: getAllSponsor(),
    aidType: getAllAidType(),
    approvingAgency: getAllApprovingAgency(),
    counterParty: getAllCounterparty(),
  }
}

