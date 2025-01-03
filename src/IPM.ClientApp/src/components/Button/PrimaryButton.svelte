<script lang="ts">
  import type { Snippet } from "svelte";
 const { children }: { children: Snippet } = $props();
</script>
<button>
  {@render children()}
</button>
<style lang="scss">
button {
  margin-top: var(--margin-top, 0);
  margin-bottom: var(--margin-bottom, 0);
  background-color: $text-clr;
  color: $primary-clr;
  padding: 0.6em;
  border-radius: 6px;
  opacity: 0.9;
}
button:hover {
  opacity: 1;
}
</style>
