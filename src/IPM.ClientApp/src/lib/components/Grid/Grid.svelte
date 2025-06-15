<script lang="ts">
  import type { Snippet } from "svelte";

  interface Props {
    children: Snippet;
  }
  const { children }: Props = $props();
</script>

<div>
  {@render children()}
</div>

<style lang="scss">
  div {
    display: grid;
    grid-template-columns: repeat(var(--grid-col, 1), 1fr);
    width: var(--grid-width, 100%);
    gap: var(--grid-gap, 0);
  }
</style>
