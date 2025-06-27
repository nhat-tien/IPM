import { error } from '@sveltejs/kit';
import type { PageLoad } from './$types';
import getProject from '@useCases/projectUseCase/getProject';
import { cacheFetch } from '@stores/cache.svelte';
import type { Project } from '@useCases/useCases.types';
import getAttachedFiles from '@useCases/projectUseCase/getAttachedFiles';

export const load: PageLoad = async ({ params, depends }) => {
  depends(`project:view`);
  const id = params.id;
  const project = await cacheFetch<Project | null>(`project:${id}`,300,() => getProject(id));
  if (!project || project.isDeleted) {
    error(404, "Not Found");
  }
  console.log(project)
  return {
    project: project,
    files: getAttachedFiles(id),
    id: id
  };
};
