<script lang="ts">
  import type { Snippet } from "svelte";
  const { children }: { children: Snippet } = $props();
</script>
<button>
  {@render children()}
</button>
<style lang="scss">
button {
  background-color: $text-clr;
  color: $primary-clr;
  padding: 0.6em;
  border-radius: 6px;
}
</style>
