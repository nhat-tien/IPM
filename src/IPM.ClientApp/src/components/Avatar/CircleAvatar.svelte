<script lang="ts">
    import type { Snippet } from "svelte";

const { children }: {children: Snippet} = $props();
</script>
<div>
  {@render children()}
</div>

<style lang="scss">
div {
  border-radius: 90%;
  width: var(--radius, 20px);
  height: var(--radius, 20px);
  background-color: var(--background-color, hsl(30, 0%, 0%));
  color: var(--color, hsl(0, 0%, 97%));
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>

