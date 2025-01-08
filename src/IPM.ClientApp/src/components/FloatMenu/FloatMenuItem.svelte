<script lang="ts">
  import type { Snippet } from "svelte";

  type FloatMenuItemProps = {
    children: Snippet;
  };
  const { children }: FloatMenuItemProps = $props();
</script>

<div>
  {@render children()}
</div>

<style lang="scss">
div {
  padding: 0.7em;
}
div:not(:last-child) {
  border-bottom: 1px solid $gray-clr;
}
</style>
