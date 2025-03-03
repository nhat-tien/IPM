import { error } from '@sveltejs/kit';
import type { PageLoad } from './$types';
import getProject from '@useCases/projectUseCase/getProject';
import { cacheFetch } from '@stores/cache.svelte';
import type { Project } from '@useCases/useCases.types';
import getAttachedFiles from '@useCases/projectUseCase/getAttachedFiles';

export const load: PageLoad = async ({ params }) => {
  const id = params.id;
  const project = await cacheFetch<Project | null>(`project:${id}`,300,() => getProject(id));

  if (!project) {
    error(404, "Not Found");
  }

  return {
    project: project,
    files: getAttachedFiles(id),
    id: id
  };
};
