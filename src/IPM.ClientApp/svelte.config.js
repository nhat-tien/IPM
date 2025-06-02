import adapter from "@sveltejs/adapter-static";
import { vitePreprocess } from "@sveltejs/vite-plugin-svelte";

/** @type {import('@sveltejs/kit').Config} */
const config = {
  // Consult https://svelte.dev/docs/kit/integrations
  // for more information about preprocessors
  preprocess: vitePreprocess(),

  kit: {
    alias: {
      "@stores": "./src/lib/stores",
      "@components": "./src/lib/components",
      "@services": "./src/lib/services",
      "@useCases": "./src/lib/useCases",
      "@utils": "./src/lib/utils",
      "@": "./src",
    },
    // adapter-auto only supports some environments, see https://svelte.dev/docs/kit/adapter-auto for a list.
    // If your environment is not supported, or you settled on a specific environment, switch out the adapter.
    // See https://svelte.dev/docs/kit/adapters for more information about adapters.
    adapter: adapter({
      pages: "../IPM.WebApi/wwwroot",
      fallback: "Index.cshtml",
    }),
  },
};

export default config;
