<script lang="ts">
  import type { Snippet } from "svelte";
  import { goto } from "$app/navigation";
  import "$lib/scss/_global.scss";
  let { children }: { children: Snippet } = $props();

</script>

{@render children()}
