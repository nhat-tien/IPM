import getProfile from '@useCases/userUseCase/getProfile';
import type { PageLoad } from './$types';
import { cacheFetch } from '@stores/cache.svelte';
import type { User } from '@useCases/useCases.types';
import { error } from '@sveltejs/kit';

export const load: PageLoad = async ({ depends }) => {

  const user = await cacheFetch<User | null>(`profile`,300,() => getProfile());

  depends("user:profile");

  if (!user) {
    error(404, "Not Found");
  }

  return {
    user: user
  };
};


