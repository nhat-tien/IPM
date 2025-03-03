import { error } from '@sveltejs/kit';
import type { PageLoad } from './$types';
import getProject from '@useCases/projectUseCase/getProject';
import { cacheFetch } from '@stores/cache.svelte';
import type { Project, User } from '@useCases/useCases.types';
import getAllCategory from '@useCases/categoryUseCase/getAllCategory';
import getAllAidType from '@useCases/aidTypeUseCase/getAllAidType';
import getAllApprovingAgency from '@useCases/approvingAgencyUseCase/getAllApprovingAgency';
import getAllSponsor from '@useCases/sponsorUseCase/getAllSponsor';
import getAllCounterparty from '@useCases/counterpartyUseCase/getAllCounterparty';
import getAllAffiliatedUnit from '@useCases/affiliatedUnitUseCase/getAllAffiliatedUnit';
import getAllUser from '@useCases/userUseCase/getAllUser';
import getAllFileType from '@useCases/fileTypeUseCase/getAllFileType';
import getAttachedFiles from '@useCases/projectUseCase/getAttachedFiles';

export const load: PageLoad = async ({ params, depends }) => {

  depends("project:edit");

  const id = params.id;
  const project = await cacheFetch<Project | null>(`project:${id}`,300,() => getProject(id));

  if (!project) {
    error(404, "Not Found");
  }

  console.log(project);

  return {
    project: project,
    affiliatedUnit: getAllAffiliatedUnit(),
    category: getAllCategory(),
    aidType: getAllAidType(),
    approvingAgency: getAllApprovingAgency(),
    sponsor: getAllSponsor(),
    counterparty: getAllCounterparty(),
    fileType: getAllFileType(),
    files: getAttachedFiles(id),
    users: cacheFetch<User[]>("users", 300, getAllUser),
    id: id
  };
};

