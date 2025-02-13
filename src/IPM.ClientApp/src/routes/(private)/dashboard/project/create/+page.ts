import getAllCategory from "@useCases/categoryUseCase/getAllCategory";
import type { PageLoad } from "./$types";
import getAllSponsor from "@useCases/sponsorUseCase/getAllSponsor";
import getAllAidType from "@useCases/aidTypeUseCase/getAllAidType";
import getAllApprovingAgency from "@useCases/approvingAgencyUseCase/getAllApprovingAgency";
import getAllCounterparty from "@useCases/counterpartyUseCase/getAllCounterparty";
import { cacheFetch } from "@stores/cache.svelte";
import type { User } from "@useCases/useCases.types";
import getAllUser from "@useCases/userUseCase/getAllUser";
import getAllFileType from "@useCases/fileTypeUseCase/getAllFileType";

export const load: PageLoad = async ({ depends }) => {
  depends("project:create")
  return {
    category: getAllCategory(),
    sponsor: getAllSponsor(),
    aidType: getAllAidType(),
    approvingAgency: getAllApprovingAgency(),
    counterParty: getAllCounterparty(),
    fileType: getAllFileType(),
    users: cacheFetch<User[]>("users", 300, getAllUser),
  }
}

