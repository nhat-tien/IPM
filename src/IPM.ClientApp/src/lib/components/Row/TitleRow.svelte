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
    flex-direction: row;
    border-bottom: 1px solid $gray-clr;
    justify-content: var(--justify-content, flex-start);
    align-items: var(--align-items, center);
    gap: var(--gap, 0.5em);
    margin-top: var(--margin-top, 0.5em);
    margin-bottom: var(--margin-bottom, 2em);
    padding-top: var(--padding-top, 0);
    padding-bottom: var(--padding-bottom, 0);
    padding-right: var(--padding-right, 0);
    padding-left: var(--padding-left, 0);
    padding: var(--padding, 0 0 0 0);
  }
</style>
