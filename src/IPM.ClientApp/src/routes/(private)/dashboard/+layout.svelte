<script lang="ts">
  import Header from "@components/UniqueComponents/Header.svelte";
  import SideMenu from "@components/UniqueComponents/SideMenu.svelte";
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<Header />
<main>
  <SideMenu />
  <section class="main-center">
    {@render children()}
  </section>
</main>

<style lang="scss">
  main {
    margin: 4rem 0 0 0;
    width: 100%;
    display: flex;
    flex-direction: row;
  }
  .main-center {
    flex: 1;
    padding: 1em;
    overflow-y: auto;
  }
</style>
