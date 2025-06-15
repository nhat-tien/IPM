<script lang="ts">
  import type { Snippet } from "svelte";
  const { children }: { children?: Snippet } = $props();
</script>

<div>
  {@render children?.()}
</div>

<style lang="scss">
  div {
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: var(--justify-content, flex-start);
    align-items: var(--align-items, center);
    gap: var(--gap, 0.5em);
    margin-top: var(--margin-top, 0.5em);
    margin-bottom: var(--margin-bottom, 0.5em);
    padding: var(--padding, 0 0 0 0);
  }
</style>


