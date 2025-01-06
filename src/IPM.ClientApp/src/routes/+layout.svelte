<script lang="ts">
  import type { Snippet } from "svelte";
  import "$lib/scss/_global.scss";
  const { children }: { children: Snippet } = $props();
</script>

{@render children()}
