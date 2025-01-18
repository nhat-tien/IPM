<script lang="ts">
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<div>
  {@render children()}
</div>

<style lang="scss">
  div {
    width: 100%;
    display: grid;
    grid-template-columns: 1fr 1fr;
    column-gap: 0.5em;
    margin-top: var(--margin-top, 0.5em);
    margin-bottom: var(--margin-bottom, 0.5em);
  }
</style>
