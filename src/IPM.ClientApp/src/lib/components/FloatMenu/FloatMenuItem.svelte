<script lang="ts">
  import type { Snippet } from "svelte";

  type FloatMenuItemProps = {
    children: Snippet;
  };
  const { children }: FloatMenuItemProps = $props();
</script>

<li>
  {@render children()}
</li>

<style lang="scss">
li:hover {
  background-color: hsl(0, 0%,97%);
  border-radius: 5px;
}
// li:not(:last-child) {
//   border-bottom: 1px solid $gray-clr;
// }
</style>
