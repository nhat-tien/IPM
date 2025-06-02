<script lang="ts">
  import type { Snippet } from "svelte";

  type Props = {
    children: Snippet;
  };

  const { children }: Props = $props();
</script>

<div>
  <h3>{@render children()}</h3>
</div>

<style lang="scss">
div {
    padding-top: var(--padding-top, 0.5em);
    padding-bottom: var(--padding-bottom, 0.5em);
    padding-right: var(--padding-right, 0.5em);
    padding-left: var(--padding-left, 0.5em);
    padding: var(--padding, 1em);
}
</style>
