<script lang="ts">
  import type { Snippet } from "svelte";

  const { children }: { children: Snippet } = $props();
</script>

<div>
  {@render children()}
</div>

<style lang="scss">
div {
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  gap: var(--gap, 0.5em);
  margin-top: var(--margin-top, 0.5em);
  margin-bottom: var(--margin-bottom, 0.5em);
}
</style>


