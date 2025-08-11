import type { PageLoad } from './$types';
import type { Project } from '@useCases/useCases.types';
import { cacheFetch } from '@stores/cache.svelte';
import getOwnProject from '@useCases/projectUseCase/getOwnProject';

export const load: PageLoad = async ({ depends }) => {

  const projects = await cacheFetch<Project[]>(`my-project`,300,() => getOwnProject());

  depends("project:my-project");

  return {
    projects: projects 
  };
};


